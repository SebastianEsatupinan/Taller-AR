using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;  // Importa para usar IPointerDownHandler y IPointerUpHandler

public class Desplazamiento : MonoBehaviour
{
    public float moveSpeed = 5.0f;  // Velocidad de movimiento
    public float leftLimit = -5.0f;  // Límite izquierdo
    public float rightLimit = 5.0f;  // Límite derecho
    public float smoothTime = 0.2f;  // Tiempo de suavizado

    private Vector3 initialPosition;  // Posición inicial del objeto
    private Vector3 targetPosition;  // Posición objetivo hacia donde se mueve el objeto
    private Vector3 velocity = Vector3.zero;  // Velocidad para SmoothDamp

    private bool isMovingLeft = false;  // ¿Está moviéndose a la izquierda?
    private bool isMovingRight = false;  // ¿Está moviéndose a la derecha?

    private GameObject botonIzquierda;  // Botón de mover a la izquierda
    private GameObject botonDerecha;  // Botón de mover a la derecha

    void Start()
    {
        // Almacena la posición inicial
        initialPosition = new Vector3(0, transform.position.y, transform.position.z);
        transform.position = initialPosition;  // Establece la posición inicial
        targetPosition = transform.position;  // Fija la posición objetivo inicial

        // Encuentra los botones con los tags "B-izquierda" y "B-derecha"
        botonIzquierda = GameObject.FindGameObjectWithTag("B-izquierda");
        botonDerecha = GameObject.FindGameObjectWithTag("B-derecha");

        // Asegúrate de que los botones existen y añade los eventos de UI correspondientes
        if (botonIzquierda != null)
        {
            // Añadir eventos al botón de la izquierda
            EventTrigger triggerIzquierda = botonIzquierda.AddComponent<EventTrigger>();
            AddEventTrigger(triggerIzquierda, EventTriggerType.PointerDown, OnPointerDownLeft);
            AddEventTrigger(triggerIzquierda, EventTriggerType.PointerUp, OnPointerUpLeft);
        }

        if (botonDerecha != null)
        {
            // Añadir eventos al botón de la derecha
            EventTrigger triggerDerecha = botonDerecha.AddComponent<EventTrigger>();
            AddEventTrigger(triggerDerecha, EventTriggerType.PointerDown, OnPointerDownRight);
            AddEventTrigger(triggerDerecha, EventTriggerType.PointerUp, OnPointerUpRight);
        }
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

        // Mueve el objeto suavemente hacia la posición objetivo
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    // Función que añade eventos al botón
    private void AddEventTrigger(EventTrigger trigger, EventTriggerType eventType, System.Action action)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry { eventID = eventType };
        entry.callback.AddListener((eventData) => { action(); });
        trigger.triggers.Add(entry);
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
        float newX = transform.position.x - moveSpeed * Time.deltaTime;
        if (newX >= leftLimit)
        {
            targetPosition = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }

    // Función para moverse a la derecha
    private void MoveRight()
    {
        float newX = transform.position.x + moveSpeed * Time.deltaTime;
        if (newX <= rightLimit)
        {
            targetPosition = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }

    // Función opcional para restablecer la posición inicial
    public void ResetPosition()
    {
        targetPosition = initialPosition;
        transform.position = initialPosition;
    }
}
