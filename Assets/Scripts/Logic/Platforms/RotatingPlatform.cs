using UnityEngine;

namespace Logic.Platforms
{
    public class RotatingPlatform : MonoBehaviour
    {
        public float rotationSpeed = 3000f;  

        private float mouseX;

        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
                transform.Rotate(Vector3.up, -mouseX, Space.World);
            }
        }
    }
}
