using Logic.Interfaces;
using UnityEngine;

namespace Logic.Health
{
    public class HealthBar : MonoBehaviour
    {
        private float tickInterval = 100.0f;
        [SerializeField]
        private Object healthBarOwnerTransform;
        private IDamageable healthBarOwner;
        [SerializeField]
        private RectTransform healthBar;
        [SerializeField]
        private RectTransform healthBarTrace;
        [SerializeField]
        private RectTransform healthBarBackground;
    
        [SerializeField]
        private GameObject tickPrefab;

        private void Awake()
        {
            healthBarOwner = healthBarOwnerTransform.GetComponent<IDamageable>(); //healthBarOwnerTransform as IDamageable;
        }

        private void Start()
        {
            GenerateTicks();
        }

        private void Update()
        {
            if (healthBarOwner != null)
            {
                healthBar.sizeDelta = new Vector2(100 * healthBarOwner.Health.CurrentHealth / healthBarOwner.Health.MaxHealth, 100.0f);
                healthBarTrace.sizeDelta = new Vector2( Mathf.Max(healthBar.sizeDelta.x, healthBarTrace.sizeDelta.x - 30.0f * Time.deltaTime), 100.0f); //new Vector2( Mathf.Lerp(barBackground.sizeDelta.x, bar.sizeDelta.x, 0.5f * Time.deltaTime), 100.0f);
                Debug.Log(healthBarOwner.Health.CurrentHealth);
            }
            else
            {
                Debug.LogError("HealthBar has wrong object reference");
            }
        
        }

        void LateUpdate()
        {
            transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
        }


        void GenerateTicks()
        {
            float healthBarWidth = healthBarBackground.rect.width;  // Width of the health bar
            float tickSpacing = healthBarWidth / (healthBarOwner.Health.MaxHealth / tickInterval);  // Spacing between each tick

            int numberOfTicks = (int)(healthBarOwner.Health.MaxHealth / tickInterval);
            // Generate tick marks
            for (int i = 1; i <= numberOfTicks; i++)
            {
                // Instantiate a new tick
                GameObject newTick = Instantiate(tickPrefab, healthBarBackground);

                // Position the tick mark
                RectTransform tickRect = newTick.GetComponent<RectTransform>();
                tickRect.anchoredPosition = new Vector2(i * tickSpacing - healthBarWidth / 2, 20.0f);
            }
        }
    }
}
