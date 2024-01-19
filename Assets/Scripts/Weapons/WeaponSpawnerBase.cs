using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawnerBase : MonoBehaviour
{
    [SerializeField] protected WeaponSO weaponSO;

    protected Player player;

    private float currentCooldown;

    protected virtual void Start()
    {
        player = FindAnyObjectByType<Player>();

        currentCooldown = weaponSO.SpawnCooldown;
    }

    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0)
        {
            Spawn();
        }
    }

    protected virtual void Spawn()
    {
        currentCooldown = weaponSO.SpawnCooldown;
    }
}
