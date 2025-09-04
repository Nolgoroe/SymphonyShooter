using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicSpawner : WeaponSpawnerBase
{

    protected override void Start()
    {
        base.Start();

    }

    public override void Spawn()
    {
        base.Spawn();
        GameObject go = Instantiate(weaponSO.WeaponPrefab, transform.position, weaponSO.WeaponPrefab.transform.rotation);
        go.transform.parent = transform;

        GarlicWeapon weapon;
        go.TryGetComponent<GarlicWeapon>(out weapon);

        if (weapon)
        {
            weapon.InitWeapon(weaponSO.DMG, weaponSO.Pierce);
        }

    }
}
