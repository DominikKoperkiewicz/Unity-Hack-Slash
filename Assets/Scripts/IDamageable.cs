using UnityEngine;

public interface IDamageable
{
    Transform transform { get; }
    Health Health { get; }

    void Damage(int damage);
}
