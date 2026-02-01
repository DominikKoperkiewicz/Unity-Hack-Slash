using UnityEngine;

namespace UI.Outline
{
    public class OutlineManager : MonoBehaviour
    {
        private Outline currentHoveredObject = null;
        private void FixedUpdate()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layerMask = 1 << 6;


            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Outline hitObject = hit.collider.gameObject.GetComponent<Outline>();

                if (currentHoveredObject != hitObject)
                {
                    if (currentHoveredObject != null)
                    {
                        currentHoveredObject.enabled = false;
                    }

                    if (hitObject != null)
                    {
                        hitObject.enabled = true;
                    }

                    currentHoveredObject = hitObject;
                }
            }
            else
            {
                if (currentHoveredObject != null)
                {
                    currentHoveredObject.enabled = false;
                    currentHoveredObject = null;
                }
            }
        }
    }
}
