using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponBase : MonoBehaviour
{
    [SerializeField] private float destrroyAfterSeconds;

    protected float currentDMG;
    protected int currentPierce;


    protected virtual void Start()
    {
        Destroy(gameObject, destrroyAfterSeconds);
    }

    public void InitWeapon(float _DMG, int _pierec)
    {
        currentDMG = _DMG;
        currentPierce = _pierec;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyBase enemy;
            collision.TryGetComponent<EnemyBase>(out enemy);

            if (enemy)
            {
                enemy.TakeDMG(currentDMG);
            }
        }
    }
}
