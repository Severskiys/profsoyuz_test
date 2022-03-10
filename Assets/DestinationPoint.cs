using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestinationPoint : MonoBehaviour
{
    public event UnityAction Reached;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Cart cart))
        {
            Reached?.Invoke();
        }
    }
}
