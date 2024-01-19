using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBase : MonoBehaviour
{
    [SerializeField] protected Vector3 direction;
    [SerializeField] private float destrroyAfterSeconds;

    [SerializeField] protected float currentSpeed;
    [SerializeField] protected float currentDMG;
    [SerializeField] protected int currentPierce;

    protected virtual void Start()
    {
        Destroy(gameObject, destrroyAfterSeconds);
    }

    protected virtual void Update()
    {
    }


    public void InitWeapon(float _speed, float _DMG, int _pierec)
    {
        currentSpeed = _speed;
        currentDMG = _DMG;
        currentPierce = _pierec;
    }


    public void SetDirection(Vector3 dir)
    {
        direction = dir;

        float dirX = direction.x;
        float dirY = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if(dirX < 0 &&dirY == 0) //left
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
        }
        else if(dirX == 0 && dirY < 0) // down
        {
            scale.y = scale.y * -1;
        }
        else if(dirX == 0 && dirY > 0) // up
        {
            scale.x = scale.x * -1;
        }
        else if(dirX > 0 && dirY > 0) // right up
        {
            rotation.z = 0;
        }
        else if(dirX > 0 && dirY < 0) // right down
        {
            rotation.z = -90;
        }
        else if(dirX < 0 && dirY > 0) // left up
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = -90;
        }
        else if(dirX < 0 && dirY < 0) // left down
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = 0;
        }

        transform.localScale = scale;

        transform.rotation = Quaternion.Euler(rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyBase enemy;
            collision.TryGetComponent<EnemyBase>(out enemy);

            if(enemy)
            {
                enemy.TakeDMG(currentDMG);
            }

            ReducePierce();
        }
    }

    private void ReducePierce()
    {
        currentPierce--;
        if(currentPierce <= 0)
        {
            Destroy(gameObject);
        }
    }
}
