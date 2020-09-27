using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent onTriggerInvoke;

    private void OnTriggerEnter(Collider other)
    {
        onTriggerInvoke.Invoke();
    }
}
