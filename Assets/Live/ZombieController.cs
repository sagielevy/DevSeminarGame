using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public float moveSpeed = 1;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        transform.rotation = Quaternion.LookRotation((player.transform.position - transform.position).normalized);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Destroy(collision.collider.gameObject);
        }
        else if (collision.collider.tag == "Shot")
        {
            Destroy(gameObject);
            Destroy(collision.collider.gameObject);
        }
    }
}
