using Logic.Interfaces;
using UnityEngine;

namespace Logic.Enemies
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        public Health.Health Health { get; protected set; } = new Health.Health(100);

        public void Damage(int damage)
        {
            Health.Damage(damage);
        }

    }
}
