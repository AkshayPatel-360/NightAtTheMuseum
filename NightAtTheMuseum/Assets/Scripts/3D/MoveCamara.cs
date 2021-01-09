
 using UnityEngine;

public class MoveCamara : MonoBehaviour
{

    public Transform player;

    void Update()
    {
        transform.position = player.transform.position;
    }
}

