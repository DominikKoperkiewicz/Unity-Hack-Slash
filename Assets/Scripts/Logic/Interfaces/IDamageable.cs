using UnityEngine;

namespace Logic.Interfaces
{
    public interface IDamageable
    {
        Transform transform { get; }
        Health.Health Health { get; }

        void Damage(int damage);
    }
}
