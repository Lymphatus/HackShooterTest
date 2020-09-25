using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : PawnController
{
    public float speed = 5.0f;
    private static readonly int Color = Shader.PropertyToID("_Color");
    public Transform objective;

    public UiHealthController healthBar;
    protected override float MaxHealth { get; } = 10.0f;
    protected override float CurrentHealth { get; set; } = 10.0f;

    void Start()
    {
        objective = GameObject.FindGameObjectWithTag("Player").transform;
        healthBar.SetMax(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (objective) {
            transform.position = Vector3.MoveTowards(transform.position, objective.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            objective.GetComponent<TopDownCharacterController>().TakeDamage(10.0f);
            Destroy(gameObject);
        }
    }

    protected override void OnTakeDamage()
    {
        var renderer = GetComponent<Renderer>();
        renderer.material.SetColor(Color, new Color(1 - CurrentHealth / MaxHealth, 0, 0));
        
        healthBar.SetValue(CurrentHealth);
    }
}