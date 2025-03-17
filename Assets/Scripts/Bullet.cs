using System;
using UnityEngine;
using Fusion;

public class Bullet : NetworkBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Runner.Despawn(other.gameObject.GetComponent<NetworkObject>());
        }
    }
}
