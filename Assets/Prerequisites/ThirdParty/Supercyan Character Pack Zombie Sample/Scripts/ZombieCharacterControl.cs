using UnityEngine;

public class ZombieCharacterControl : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private Rigidbody m_rigidBody;

    public float moveSpeed = 1;
    public float destroyDelaySeconds = 10;

    private Transform target;
    private float attackDist = 1;

    void Awake()
    {
        if(!m_animator) { gameObject.GetComponent<Animator>(); }
        if(!m_rigidBody) { gameObject.GetComponent<Animator>(); }
    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        if (target == null) return;

        Vector3 lookDirection = (target.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
        m_animator.SetFloat("MoveSpeed", moveSpeed);

        if (Vector3.Distance(target.position, transform.position) < attackDist)
        {
            m_animator.SetTrigger("Attack");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Shot")
        {
            // Kill self but leave the game object for a few moments
            m_animator.SetTrigger("Dead");
            Destroy(this);
            Destroy(gameObject, destroyDelaySeconds);

            // Stop the shot
            Destroy(collision.gameObject);
        }
        else if (collision.collider.tag == "Player")
        {
            Debug.Log($"Game over man");
            Destroy(collision.gameObject);
        }
    }
}
