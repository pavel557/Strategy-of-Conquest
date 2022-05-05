using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private FixedJoystick fixedJoystick;
    [SerializeField] private float currentSpeed;
    

    private Vector2 velocity;

    public float CurrentSpeed { get => currentSpeed; set => currentSpeed = value; }

    private void Start()
    {
        velocity = new Vector2(0f, 0f);
    }

    //private void Update()
    //{
    //    rb.velocity = velocity;
    //    if ((fixedJoystick.Horizontal != 0)||(fixedJoystick.Vertical != 0))
    //    {
    //        velocity.x = fixedJoystick.Horizontal * currentSpeed;
    //        velocity.y = fixedJoystick.Vertical * currentSpeed;
    //        return;
    //    }
    //    velocity.x = 0;
    //    velocity.y = 0;
    //}

    private void FixedUpdate()
    {

        if (fixedJoystick.Horizontal != 0)
        {
            velocity.x = fixedJoystick.Horizontal * currentSpeed;
        }
        if (fixedJoystick.Vertical != 0)
        {
            velocity.y = fixedJoystick.Vertical * currentSpeed;
        }
        if ((fixedJoystick.Horizontal == 0) && (fixedJoystick.Vertical == 0) && ((velocity.x != 0) || (velocity.y != 0)))
        {
            velocity.x = velocity.x * 0.9f;
            velocity.y = velocity.y * 0.9f;
            if (Mathf.Abs(velocity.x) < currentSpeed * 0.01f)
            {
                velocity.x = 0;
            }
            if (Mathf.Abs(velocity.y) < currentSpeed * 0.01f)
            {
                velocity.y = 0;
            }
        }
        rb.velocity = velocity;
    }

    public float ChangeSpeed(float newSpeed)
    {
        float speed = currentSpeed;
        currentSpeed = newSpeed;
        return speed;

    }

}
