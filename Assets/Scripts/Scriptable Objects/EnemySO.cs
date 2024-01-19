using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy SO", menuName = "ScriptableObjects/Enemy")]
public class EnemySO : ScriptableObject
{
    [SerializeField] private GameObject enemyPreafb;
    [SerializeField] private float speed;
    [SerializeField] private float maxHP;
    [SerializeField] private float dmg;

    public GameObject EnemyPrefab { get => enemyPreafb; private set => enemyPreafb = value; }
    public float Speed { get => speed; private set => speed = value; }
    public float MaxHP { get => maxHP; private set => maxHP = value; }
    public float DMG { get => dmg; private set => dmg = value; }
}
