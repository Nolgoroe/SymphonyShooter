using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSpawner : WeaponSpawnerBase
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }


    protected override void Spawn()
    {
        base.Spawn();
        GameObject go = Instantiate(weaponSO.WeaponPrefab, transform.position, weaponSO.WeaponPrefab.transform.rotation);
        KnifeWeapon weapon;
        go.TryGetComponent<KnifeWeapon>(out weapon);

        if(weapon)
        {
            weapon.InitWeapon(weaponSO.Speed, weaponSO.DMG, weaponSO.Pierce);
            weapon.SetDirection(player.ReturnLatestMoveDirection());
        }
    }
}
