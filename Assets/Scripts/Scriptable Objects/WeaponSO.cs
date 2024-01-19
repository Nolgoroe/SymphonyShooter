using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon SO", menuName = "ScriptableObjects/Weapon")]
public class WeaponSO : ScriptableObject
{

    [SerializeField] private GameObject weaponPrefab;
    [SerializeField] private float dmg;
    [SerializeField] private float speed;
    [SerializeField] private float spawnCooldown;
    [SerializeField] private int pierce;


    public GameObject WeaponPrefab { get => weaponPrefab; private set => weaponPrefab = value; }
    public float DMG { get => dmg; private set => dmg = value; }
    public float Speed { get => speed; private set => speed = value; }
    public float SpawnCooldown { get => spawnCooldown; private set => spawnCooldown = value; }
    public int Pierce { get => pierce; private set => pierce = value; }

}
