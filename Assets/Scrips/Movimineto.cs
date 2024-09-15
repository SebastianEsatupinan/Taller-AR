using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public WheelCollider rearLeftWheel;
    public WheelCollider rearRightWheel;

    public float maxMotorTorque = 1500f; // La cantidad máxima de torque aplicado a las ruedas traseras
    public float maxSteeringAngle = 30f; // El ángulo máximo de giro de las ruedas delanteras

    private float motor = 0f;
    private float steering = 0f;

    private void Update()
    {
        // Aplica el ángulo de dirección a las ruedas delanteras
        frontLeftWheel.steerAngle = steering;
        frontRightWheel.steerAngle = steering;

        // Aplica el torque del motor a las ruedas traseras
        rearLeftWheel.motorTorque = motor;
        rearRightWheel.motorTorque = motor;
    }

    // Funciones para ser llamadas desde los botones de UI
    public void OnMoveForward()
    {
        motor = maxMotorTorque;
    }

    public void OnMoveBackward()
    {
        motor = -maxMotorTorque;
    }

    public void OnSteerLeft()
    {
        steering = -maxSteeringAngle;
    }

    public void OnSteerRight()
    {
        steering = maxSteeringAngle;
    }

    public void OnStopMovement()
    {
        motor = 0f;
    }

    public void OnStopSteering()
    {
        steering = 0f;
    }
}
