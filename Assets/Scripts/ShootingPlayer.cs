using System;
using UnityEngine;
using Fusion;

public class ShootingPlayer : NetworkBehaviour
{
    public GameObject bulletPrefab;
    public Transform firepoint;
    public float forceShoot;
    public float fireRate = 0.2f;
    private bool isShoot;

    private void Update()
    {
        if (Input.GetMouseButton(0)) isShoot = true;
        else isShoot = false;

    }

    public override void FixedUpdateNetwork()
    {
        if(isShoot) Shoot();
    }

    void Shoot()
    {
        if (Runner.IsSharedModeMasterClient)
        {
            Runner.Spawn(bulletPrefab, firepoint.position, firepoint.rotation, null,
                (runner, obj) =>
                {
                    obj.GetComponent<Rigidbody>()?.AddForce(transform.forward * forceShoot, ForceMode.Impulse);
                });
            isShoot = false;
        }
    }

}
