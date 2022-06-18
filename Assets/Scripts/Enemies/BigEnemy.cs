using System.Collections;
using UnityEngine;

public class BigEnemy : Enemy
{
    [SerializeField] private int _health;
    
    protected override void ReactToLaser()
    {
        _health -= 1;
        if (_health <= 0)
        {
            _parameters.UpdatePoints(_points);
            Destroy(gameObject);
        }
    }

    protected override void ReactToPlayer()
    {
        _parameters.UpdateHealth(-_damage);
        Destroy(gameObject);
    }
}
