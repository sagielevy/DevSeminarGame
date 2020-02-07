using UnityEngine;

public class PlayerControllerOffline : MonoBehaviour
{
    public float moveSpeed = 2;
    public float rotationSpeed = 240;
    public float shotCooldownTime = 0.2f;
    public GameObject shotPrefab;

    private float currentDirection;
    private float lastShotFiredTime;

    void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        float v = Input.GetAxis("Vertical"); // Value is 1,-1 or 0 for no input
        float h = Input.GetAxis("Horizontal"); // Value is 1,-1 or 0 for no input

        currentDirection += h * Time.deltaTime * rotationSpeed;

        transform.rotation = Quaternion.Euler(0, currentDirection, 0);
        transform.position += transform.forward * v * moveSpeed * Time.deltaTime;
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > shotCooldownTime + lastShotFiredTime)
        {
            Instantiate(shotPrefab, transform.position + transform.forward * 0.5f,
                transform.rotation);
        }
    }
}
