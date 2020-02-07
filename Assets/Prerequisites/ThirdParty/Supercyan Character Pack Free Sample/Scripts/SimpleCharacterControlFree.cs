using UnityEngine;

public class SimpleCharacterControlFree : MonoBehaviour
{
    [SerializeField] private Animator m_animator;

    public float rotationSpeed = 4;
    public float moveSpeed = 5;
    public float shotCooldownTime = 0.2f;
    public GameObject shotPrefab;

    private float lastShotFiredTime;
    private float initOffset = 0.5f;
    private float currentDirection;
    
    void Awake()
    {
        if(!m_animator) { gameObject.GetComponent<Animator>(); }
        m_animator.SetBool("Grounded", true);
    }

	void Update ()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        float v = Input.GetAxis("Vertical"); // Value is 1,-1 or 0 for no input
        float h = Input.GetAxis("Horizontal"); // Value is 1,-1 or 0 for no input

        currentDirection += h * Time.deltaTime * rotationSpeed;

        transform.rotation = Quaternion.Euler(0, currentDirection * Mathf.Rad2Deg, 0);
        transform.position += transform.forward * v * moveSpeed * Time.deltaTime;
        m_animator.SetFloat("MoveSpeed", v);
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastShotFiredTime > shotCooldownTime)
        {
            Instantiate(shotPrefab, transform.position + transform.forward * initOffset,
                transform.rotation);
        }
    }
}
