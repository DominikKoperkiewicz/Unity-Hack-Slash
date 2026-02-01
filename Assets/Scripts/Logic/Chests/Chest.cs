using Logic.Interfaces;
using UnityEngine;

namespace Logic.Chests
{
    public class Chest : MonoBehaviour, IInteractable, IDamageable
    {
        public Health.Health Health { get; private set; } = new Health.Health(350);

        public void Damage(int damage)
        {
            Health.Damage(damage);
        }

        public void Interact()
        {
            Debug.Log("Chest open");
        }

    
    }
}
