using Logic.Interfaces;
using UnityEngine;

namespace Logic.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        private float damage;
        private float range;
        private float attackSpeed;

        public abstract void Attack(IDamageable attackTarget);
    }
}
