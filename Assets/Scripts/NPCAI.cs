using UnityEngine;

public class NPCAI : MonoBehaviour
{
    private Rigidbody rb;
    [Header("Movement Options")]
    [SerializeField]
    private float moveForce = 0f;
    [SerializeField]
    private float rotationSpeed = 0f;



    [Header("Patrol Routes")]
    [SerializeField]
    private GameObject[] waypoints = null;

    private int currentWaypoint;
    private Vector3 moveDir;



    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(moveDir * moveForce);
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (waypoints.Length > 0)
        {
            if (Vector3.Distance(this.transform.position, waypoints[currentWaypoint].transform.position) >= 2f)
            {
                Vector3 direction = waypoints[currentWaypoint].transform.position - this.transform.position;
                direction.y = 0f;

                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed);

                if (direction.magnitude > 0.8f)
                {
                    moveDir = direction.normalized;
                }
            }

            else
            {
                moveDir = Vector3.zero;
                currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            }
        }
    }
}
