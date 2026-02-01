using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable, IDamageable
{
    public Health Health { get; private set; } = new Health(350);

    public void Damage(int damage)
    {
        Health.Damage(damage);
    }

    public void Interact()
    {
        Debug.Log("Chest open");
    }

    
}
