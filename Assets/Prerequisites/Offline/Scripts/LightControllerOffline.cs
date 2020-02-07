using UnityEngine;

public class LightControllerOffline : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player == null) return;

        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(lookDirection); // Implicitly using Vector.up
    }
}
