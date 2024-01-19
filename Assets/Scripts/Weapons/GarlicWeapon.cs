using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicWeapon : MeleeWeaponBase
{
    [SerializeField] List<GameObject> markedEnemies;

    protected override void Start()
    {
        base.Start();

        markedEnemies = new List<GameObject>();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !markedEnemies.Contains(collision.gameObject))
        {
            EnemyBase enemy;
            collision.TryGetComponent<EnemyBase>(out enemy);

            if (enemy)
            {
                enemy.TakeDMG(currentDMG);
            }

            markedEnemies.Add(collision.gameObject);
        }
    }
}
