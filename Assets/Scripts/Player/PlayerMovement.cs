using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed;

    private PlayerActions actions;
    private Rigidbody2D body;
    private Vector2 moveDir;

    private void Awake()
    {
        this.actions = new PlayerActions();
        this.body = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        this.ReadMovement();
    }
    private void FixedUpdate()
    {
        this.Move();
    }

    private void Move()
    {
        this.body.MovePosition(this.body.position + this.moveDir * (this.speed * Time.fixedDeltaTime));
    }
    private void ReadMovement()
    {
        this.moveDir = this.actions.Movement.Move.ReadValue<Vector2>().normalized;
    }

    private void OnEnable()
    {
        this.actions.Enable();
    }
    private void OnDisable()
    {
        this.actions.Disable();
    }
}
