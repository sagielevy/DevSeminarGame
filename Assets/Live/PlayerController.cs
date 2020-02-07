using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2;
    public float rotateSpeed = 240;
    private float currentDirection;

    public GameObject shot;
    private float lastShotTime;
    public float shotDelay = 0.2f;

    void Start()
    {
        lastShotTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        currentDirection += h * rotateSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, currentDirection, 0);
        transform.position += transform.forward * v * moveSpeed * Time.deltaTime;

        Shoot();
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > lastShotTime + shotDelay)
        {
            Instantiate(shot, transform.position + transform.forward * 0.5f, transform.rotation);
            lastShotTime = Time.time;
        }
    }
}
