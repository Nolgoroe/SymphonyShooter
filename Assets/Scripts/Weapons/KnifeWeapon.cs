using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeWeapon : ProjectileWeaponBase
{
    protected override void Start()
    {
        base.Start();

    }

    protected override void Update()
    {
        base.Update();

        transform.position += direction * currentSpeed * Time.deltaTime;
    }
}
