using UnityEngine;

namespace Enemies
{
    public class LittleEnemy : Enemy
    {
        protected override void ReactToLaser()
        { 
            _parameters.UpdatePoints(_points);
            Destroy(gameObject);
        }

        protected override void ReactToPlayer()
        {
            _parameters.UpdateHealth(-_damage);
            Destroy(gameObject);
        }
    }
}