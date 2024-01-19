using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private EnemySO enemySO; // get rid of this later when we have an enemy spawner.
    Transform player;

    [SerializeField] float currentMoveSpeed;
    [SerializeField] float currentHealth;
    [SerializeField] float currentDMG;

    private void Awake()
    {
        // this will be moved to an init funciton so we can get rid of the enemySO variable here
        currentMoveSpeed = enemySO.Speed;
        currentHealth = enemySO.MaxHP;
        currentDMG = enemySO.DMG;
    }
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySO.Speed * Time.deltaTime);
    }


    public void TakeDMG(float amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        Destroy(gameObject);
    }
}
