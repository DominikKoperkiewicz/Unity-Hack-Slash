using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public Health Health { get; protected set; } = new Health(100);

    public void Damage(int damage)
    {
        Health.Damage(damage);
    }

}
