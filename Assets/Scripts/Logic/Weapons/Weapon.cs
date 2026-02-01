using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    private float damage;
    private float range;
    private float attackSpeed;

    public abstract void Attack(IDamageable attackTarget);
}
