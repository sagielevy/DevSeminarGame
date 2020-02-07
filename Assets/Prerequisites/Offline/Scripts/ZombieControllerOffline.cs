using UnityEngine;

public class ZombieControllerOffline : MonoBehaviour
{
    public float moveSpeed = 1;
    private Transform target;

    void Start()
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
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Shot")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else if (collision.collider.tag == "Player")
        {
            Debug.Log("Game over man. Game over");
            Destroy(collision.gameObject);
        }
    }
}
