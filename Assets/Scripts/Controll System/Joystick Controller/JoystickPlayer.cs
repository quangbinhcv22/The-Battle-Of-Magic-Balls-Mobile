using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayer : MonoBehaviour
{
    const float maxVelocityMagnitudeSpeed = 1.8f;

    public float speed;

    public VariableJoystick variableJoystick;
    new private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (rigidbody.velocity.magnitude <= maxVelocityMagnitudeSpeed)
        {
            Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
            rigidbody.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.Impulse);
        }
    }
}