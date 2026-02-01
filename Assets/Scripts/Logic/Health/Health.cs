using UnityEngine;

namespace Logic.Health
{
    public class Health
    {
        private int currentHealth = 100;
        public int CurrentHealth { get { return currentHealth; } set { currentHealth = Mathf.Clamp(value, 0, maxHealth); } }

        private int maxHealth = 100;
        public int MaxHealth { get { return maxHealth; } set { maxHealth = Mathf.Max(1, value); } }

        public Health(int fullHealth)
        {
            MaxHealth = fullHealth;
            CurrentHealth = fullHealth;
        }

        public void Damage(int damage) { 
            CurrentHealth = CurrentHealth - damage;
        }
    }
}
