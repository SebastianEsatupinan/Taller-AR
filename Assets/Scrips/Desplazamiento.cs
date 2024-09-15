using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;  // Importa para usar IPointerDownHandler y IPointerUpHandler

public class Desplazamiento : MonoBehaviour
{
    // Distancia que el coche se moverá con cada botón
    public float moveSpeed = 5.0f;

    // Límites de movimiento en el eje X, modificables desde el Inspector
    public float leftLimit = -5.0f;  // Límite izquierdo
    public float rightLimit = 5.0f;  // Límite derecho

    // Suavidad del movimiento
    public float smoothTime = 0.2f;  // Tiempo de suavizado

    // Posición inicial del objeto
    private Vector3 initialPosition;

    // Variables para la interpolación
    private Vector3 targetPosition;  // Posición a la que se está moviendo el objeto
    private Vector3 velocity = Vector3.zero;  // Velocidad utilizada por el suavizado

    // Variables para detectar si se está presionando un botón de UI
    private bool isMovingLeft = false;
    private bool isMovingRight = false;

    private void Start()
    {
        // Almacena la posición inicial en el eje Y y Z, y fija el eje X en 0
        initialPosition = new Vector3(0, transform.position.y, transform.position.z);

        // Restablece la posición del objeto a la posición inicial
        transform.position = initialPosition;

        // Establece la posición objetivo inicial como la actual
        targetPosition = transform.position;
    }

    void Update()
    {
        // Detecta si se está presionando los botones de UI para moverse
        if (isMovingLeft)
        {
            MoveLeft();
        }
        else if (isMovingRight)
        {
            MoveRight();
        }

        // Mueve el objeto de forma suave hacia la posición objetivo
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    // Función que será llamada cuando el botón "Izquierda" esté presionado
    public void OnPointerDownLeft()
    {
        isMovingLeft = true;
    }

    // Función que será llamada cuando se suelte el botón "Izquierda"
    public void OnPointerUpLeft()
    {
        isMovingLeft = false;
    }

    // Función que será llamada cuando el botón "Derecha" esté presionado
    public void OnPointerDownRight()
    {
        isMovingRight = true;
    }

    // Función que será llamada cuando se suelte el botón "Derecha"
    public void OnPointerUpRight()
    {
        isMovingRight = false;
    }

    // Función para moverse a la izquierda
    private void MoveLeft()
    {
        // Calcula la nueva posición en el eje X
        float newX = transform.position.x - moveSpeed * Time.deltaTime;

        // Asegúrate de que no sobrepase el límite izquierdo
        if (newX >= leftLimit)
        {
            // Establece la nueva posición objetivo si está dentro de los límites
            targetPosition = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }

    // Función para moverse a la derecha
    private void MoveRight()
    {
        // Calcula la nueva posición en el eje X
        float newX = transform.position.x + moveSpeed * Time.deltaTime;

        // Asegúrate de que no sobrepase el límite derecho
        if (newX <= rightLimit)
        {
            // Establece la nueva posición objetivo si está dentro de los límites
            targetPosition = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }

    // Función opcional para restablecer manualmente la posición si lo necesitas
    public void ResetPosition()
    {
        // Restablece la posición del objeto a la posición inicial (en X = 0)
        targetPosition = initialPosition;
        transform.position = initialPosition;
    }
}
