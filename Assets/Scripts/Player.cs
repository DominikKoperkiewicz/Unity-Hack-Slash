using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1.0f;
    private NavMeshAgent agent;
    private Animator playerAnimator;

    [SerializeField]
    private Weapon weapon;
    private IDamageable attackTarget;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerAnimator = GetComponent<Animator>();
    }


    void Update()
    {
        this.Walking();
        this.Shooting();
    }

    private void Walking()
    {
        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;
            int layerMask = 1 << 3;

            if (Physics.Raycast(ray, out hitPoint, Mathf.Infinity, layerMask))
            {
                agent.SetDestination(hitPoint.point);
                agent.isStopped = false;
            }
        }

        if (agent.velocity != Vector3.zero)
        {
            playerAnimator.SetBool("isWalking", true);
        }
        else if (agent.velocity == Vector3.zero)
        {
            playerAnimator.SetBool("isWalking", false);
        }
    }

    private void Shooting()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;
            int layerMask = 1 << 6;

            if (Physics.Raycast(ray, out hitPoint, Mathf.Infinity, layerMask))
            {

                attackTarget = hitPoint.collider.GetComponent<IDamageable>();
            }
            else
            {
                attackTarget = null;
            }
        }

        if (attackTarget != null)
        {
            agent.isStopped = true;

            Quaternion LookAtTargetRotation = Quaternion.LookRotation(attackTarget.transform.position - this.transform.position);
            float rotationSpeed = 10.0f;

            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, LookAtTargetRotation, rotationSpeed * Time.deltaTime);
            weapon?.Attack(attackTarget);
        }
    }

}
