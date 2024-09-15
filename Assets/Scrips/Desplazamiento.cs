using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;  // Importa para usar IPointerDownHandler y IPointerUpHandler

public class Desplazamiento : MonoBehaviour
{
    // Distancia que el coche se mover� con cada bot�n
    public float moveSpeed = 5.0f;

    // L�mites de movimiento en el eje X, modificables desde el Inspector
    public float leftLimit = -5.0f;  // L�mite izquierdo
    public float rightLimit = 5.0f;  // L�mite derecho

    // Suavidad del movimiento
    public float smoothTime = 0.2f;  // Tiempo de suavizado

    // Posici�n inicial del objeto
    private Vector3 initialPosition;

    // Variables para la interpolaci�n
    private Vector3 targetPosition;  // Posici�n a la que se est� moviendo el objeto
    private Vector3 velocity = Vector3.zero;  // Velocidad utilizada por el suavizado

    // Variables para detectar si se est� presionando un bot�n de UI
    private bool isMovingLeft = false;
    private bool isMovingRight = false;

    private void Start()
    {
        // Almacena la posici�n inicial en el eje Y y Z, y fija el eje X en 0
        initialPosition = new Vector3(0, transform.position.y, transform.position.z);

        // Restablece la posici�n del objeto a la posici�n inicial
        transform.position = initialPosition;

        // Establece la posici�n objetivo inicial como la actual
        targetPosition = transform.position;
    }

    void Update()
    {
        // Detecta si se est� presionando los botones de UI para moverse
        if (isMovingLeft)
        {
            MoveLeft();
        }
        else if (isMovingRight)
        {
            MoveRight();
        }

        // Mueve el objeto de forma suave hacia la posici�n objetivo
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    // Funci�n que ser� llamada cuando el bot�n "Izquierda" est� presionado
    public void OnPointerDownLeft()
    {
        isMovingLeft = true;
    }

    // Funci�n que ser� llamada cuando se suelte el bot�n "Izquierda"
    public void OnPointerUpLeft()
    {
        isMovingLeft = false;
    }

    // Funci�n que ser� llamada cuando el bot�n "Derecha" est� presionado
    public void OnPointerDownRight()
    {
        isMovingRight = true;
    }

    // Funci�n que ser� llamada cuando se suelte el bot�n "Derecha"
    public void OnPointerUpRight()
    {
        isMovingRight = false;
    }

    // Funci�n para moverse a la izquierda
    private void MoveLeft()
    {
        // Calcula la nueva posici�n en el eje X
        float newX = transform.position.x - moveSpeed * Time.deltaTime;

        // Aseg�rate de que no sobrepase el l�mite izquierdo
        if (newX >= leftLimit)
        {
            // Establece la nueva posici�n objetivo si est� dentro de los l�mites
            targetPosition = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }

    // Funci�n para moverse a la derecha
    private void MoveRight()
    {
        // Calcula la nueva posici�n en el eje X
        float newX = transform.position.x + moveSpeed * Time.deltaTime;

        // Aseg�rate de que no sobrepase el l�mite derecho
        if (newX <= rightLimit)
        {
            // Establece la nueva posici�n objetivo si est� dentro de los l�mites
            targetPosition = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }

    // Funci�n opcional para restablecer manualmente la posici�n si lo necesitas
    public void ResetPosition()
    {
        // Restablece la posici�n del objeto a la posici�n inicial (en X = 0)
        targetPosition = initialPosition;
        transform.position = initialPosition;
    }
}
