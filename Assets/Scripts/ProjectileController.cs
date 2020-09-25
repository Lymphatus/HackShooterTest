using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed = 50.0f;
    public float damage = 3.0f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.rotation * Vector3.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall") || other.CompareTag("Enemy")) {
            Destroy(gameObject);

            if (other.CompareTag("Enemy")) {
                other.GetComponent<EnemyController>().TakeDamage(damage);
            }
        }
    }
}
