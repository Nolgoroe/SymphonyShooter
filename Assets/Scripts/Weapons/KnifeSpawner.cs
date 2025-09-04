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


    public override void Spawn()
    {
        base.Spawn();
        GameObject go = Instantiate(weaponSO.WeaponPrefab, transform.position, weaponSO.WeaponPrefab.transform.rotation);
        KnifeWeapon weapon;
        go.TryGetComponent<KnifeWeapon>(out weapon);

        if(weapon)
        {
            weapon.InitWeapon(weaponSO.Speed, weaponSO.DMG, weaponSO.Pierce);

            // Get mouse position in world space
            Vector3 mouseScreenPos = Input.mousePosition;
            mouseScreenPos.z = Camera.main.nearClipPlane; // or adjust for depth if needed
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            mouseWorldPos.z = 0f; // flatten Z for 2D games

            // Calculate direction
            Vector3 direction = (mouseWorldPos - transform.position).normalized;

            // Set the direction to the weapon
            weapon.SetDirection(direction);
            //weapon.SetDirection(player.ReturnLatestMoveDirection());
        }
    }
}
