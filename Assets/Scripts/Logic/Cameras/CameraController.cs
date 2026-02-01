using UnityEngine;

namespace Logic.Cameras
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private GameObject target;

        [SerializeField] float cameraSpeed = 15.0f;
        [SerializeField] float edgeThreshold = 50.0f;

        [SerializeField] private Vector3 positionFar;
        [SerializeField] private Quaternion rotationFar;
        [SerializeField] private Vector3 positionClose;
        [SerializeField] private Quaternion rotationClose;

        [SerializeField] private float targetPositionOnPath = 1.0f;
        private float positionOnPath = 1.0f;
        private bool isLocked = true;


        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space)) { isLocked = !isLocked; }

            if(!isLocked) { EdgeMovement();  return; }

            targetPositionOnPath -= Input.mouseScrollDelta.y * 0.1f;
            targetPositionOnPath = Mathf.Clamp01(targetPositionOnPath);

            //transform.position = target.transform.position + positionFar;
            positionOnPath = Mathf.Lerp(positionOnPath, targetPositionOnPath, Time.deltaTime * 4.0f);
            transform.position = target.transform.position + Vector3.Lerp(positionClose, positionFar, positionOnPath);
            transform.rotation = Quaternion.Lerp(rotationClose, rotationFar, positionOnPath);
        }

        void EdgeMovement() {

            Vector3 moveDirection = Vector3.zero;
            Vector3 mousePosition = Input.mousePosition;

            // Get the screen size
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;

            // Check if the mouse is near the edges of the screen and set movement direction
            if (mousePosition.x < edgeThreshold)
            {
                moveDirection.x = -1;  // Move left
            }
            else if (mousePosition.x > screenWidth - edgeThreshold)
            {
                moveDirection.x = 1;   // Move right
            }

            if (mousePosition.y < edgeThreshold)
            {
                moveDirection.z = -1;  // Move up
            }
            else if (mousePosition.y > screenHeight - edgeThreshold)
            {
                moveDirection.z = 1;   // Move down
            }

            // Move the camera based on the direction and speed
            transform.position += moveDirection * cameraSpeed * Time.deltaTime;
        }
    }
}
