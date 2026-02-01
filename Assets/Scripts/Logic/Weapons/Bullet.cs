using Logic.Interfaces;
using UnityEngine;

namespace Logic.Weapons
{
    public class Bullet : MonoBehaviour
    {
        private float speed = 1.0f;
        private int damage = 1;
        private IDamageable target;
        private bool alreadyHit = false;

        void Update()
        {
            if(target == null) return;
            Vector3 distanceToTarget = target.transform.position - transform.position;

            transform.position += Vector3.Scale( (distanceToTarget).normalized * speed * Time.deltaTime, new Vector3(1.0f, 1.0f, 0.0f) );

            if(distanceToTarget.magnitude < 2.0f * speed * Time.deltaTime && !alreadyHit)
            {
                target.Damage(damage);
                alreadyHit = true;
                Destroy(gameObject, 0.0f);
            }
        }

        public void SetOptions(float speed, int damage, IDamageable target) { 
            this.speed = speed;
            this.damage = damage;
            this.target = target;
        }
    }
}
