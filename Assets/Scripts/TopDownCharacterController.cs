using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : PawnController
{
    public float velocity = 10.0f;
    public float rotationSpeed = 1000.0f;
    public new Camera camera;
    public UiHealthController healthBar;
    
    private Rigidbody rb;
    private Vector3 direction;
    private Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.zero;
        rb = this.GetComponent<Rigidbody>();
        healthBar.SetMax(MaxHealth);
        healthBar.SetValue(CurrentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
        LookAt();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void GetInputs()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    private void LookAt()
    {
        Quaternion originalRotation = transform.rotation;
        Vector3 lookDir = Input.mousePosition;
        lookDir.z = Mathf.Abs(camera.transform.position.y - transform.position.y);
        lookDir = camera.ScreenToWorldPoint(lookDir);
        transform.LookAt(lookDir);
        transform.rotation = Quaternion.RotateTowards(originalRotation,
            Quaternion.Euler(originalRotation.x, transform.eulerAngles.y, transform.eulerAngles.z),
            rotationSpeed * Time.deltaTime);
    }

    private void MoveCharacter()
    {
        rb.velocity = direction * velocity;
    }

    protected override void OnTakeDamage()
    {
        healthBar.SetValue(CurrentHealth);
    }
}