using UnityEngine;

public class ShotOffline : MonoBehaviour
{
    public float moveSpeed = 10;
    public float maxDistance = 150;

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * moveSpeed;

        if (transform.position.magnitude > maxDistance)
        {
            Destroy(gameObject);
        }
    }
}
