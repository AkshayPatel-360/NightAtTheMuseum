using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Destructible2D.Examples
{
	/// <summary>This component puts the gallery gun sprite at the bottom of the screen and moves it based on the mouse position.</summary>
	[HelpURL(D2dHelper.HelpUrlPrefix + "D2dGalleryGun")]
	[AddComponentMenu(D2dHelper.ComponentMenuPrefix + "Gallery Gun")]
	public class D2dGalleryGun : MonoBehaviour
	{
		[Tooltip("How much the mouse position relates to the gun position")]
		public float MoveScale = 0.25f;

		[Tooltip("How quickly the gun moves to its atrget position")]
		public float MoveSpeed = 5.0f;

		[Tooltip("The prefab spawned at the muzzle of the gun when shooting")]
		public GameObject MuzzlePrefab;

		[Tooltip("The prefab spawned at the mouse position when shooting")]
		public GameObject BulletPrefab;

		protected virtual void Update()
		{
			var localPosition = transform.localPosition;
			var targetX       = (Input.mousePosition.x - Screen.width  / 2) * MoveScale;
			var targetY       = (Input.mousePosition.y - Screen.height / 2) * MoveScale;
			var factor        = D2dHelper.DampenFactor(MoveSpeed, Time.deltaTime);

			localPosition.x = Mathf.Lerp(localPosition.x, targetX, factor);
			localPosition.y = Mathf.Lerp(localPosition.y, targetY, factor);

			transform.localPosition = localPosition;

			// Left click?
			if (Input.GetMouseButtonDown(0) == true)
			{
				var mainCamera = Camera.main;

				if (MuzzlePrefab != null)
				{
					Instantiate(MuzzlePrefab, transform.position, Quaternion.identity);
				}

				if (BulletPrefab != null && mainCamera != null)
				{
					var position = mainCamera.ScreenToWorldPoint(Input.mousePosition);

					Instantiate(BulletPrefab, position, Quaternion.identity);
				}
			}
		}
	}
}

#if UNITY_EDITOR
namespace Destructible2D.Examples
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(D2dGalleryGun))]
	public class D2dGalleryGun_Editor : D2dEditor<D2dGalleryGun>
	{
		protected override void OnInspector()
		{
			Draw("MoveScale");
			Draw("MoveSpeed");
			Draw("MuzzlePrefab");
			Draw("BulletPrefab");
		}
	}
}
#endif