using Logic.Interfaces;
using UnityEngine;

namespace Logic.Weapons
{
    public class DefaultGun : Weapon
    {
        [SerializeField]
        private Transform bulletPrefab;
        private float cooldown = 0.0f;

        private void Update()
        {
            cooldown -= Time.deltaTime;
        }

        public override void Attack(IDamageable attackTarget) {
            if (cooldown > 0f) return;

            cooldown = 1.00f;
            Transform bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            bullet.gameObject.GetComponent<Bullet>()?.SetOptions( 30.0f, 30, attackTarget);

        }
    }
}
