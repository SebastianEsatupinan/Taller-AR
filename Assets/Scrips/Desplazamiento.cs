using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;  // Importa para usar IPointerDownHandler y IPointerUpHandler

public class Desplazamiento : MonoBehaviour
{
    public float moveSpeed = 5.0f;  // Velocidad de movimiento
    public float leftLimit = -5.0f;  // L�mite izquierdo
    public float rightLimit = 5.0f;  // L�mite derecho
    public float smoothTime = 0.2f;  // Tiempo de suavizado

    private Vector3 initialPosition;  // Posici�n inicial del objeto
    private Vector3 targetPosition;  // Posici�n objetivo hacia donde se mueve el objeto
    private Vector3 velocity = Vector3.zero;  // Velocidad para SmoothDamp

    private bool isMovingLeft = false;  // �Est� movi�ndose a la izquierda?
    private bool isMovingRight = false;  // �Est� movi�ndose a la derecha?

    private GameObject botonIzquierda;  // Bot�n de mover a la izquierda
    private GameObject botonDerecha;  // Bot�n de mover a la derecha

    void Start()
    {
        // Almacena la posici�n inicial
        initialPosition = new Vector3(0, transform.position.y, transform.position.z);
        transform.position = initialPosition;  // Establece la posici�n inicial
        targetPosition = transform.position;  // Fija la posici�n objetivo inicial

        // Encuentra los botones con los tags "B-izquierda" y "B-derecha"
        botonIzquierda = GameObject.FindGameObjectWithTag("B-izquierda");
        botonDerecha = GameObject.FindGameObjectWithTag("B-derecha");

        // Aseg�rate de que los botones existen y a�ade los eventos de UI correspondientes
        if (botonIzquierda != null)
        {
            // A�adir eventos al bot�n de la izquierda
            EventTrigger triggerIzquierda = botonIzquierda.AddComponent<EventTrigger>();
            AddEventTrigger(triggerIzquierda, EventTriggerType.PointerDown, OnPointerDownLeft);
            AddEventTrigger(triggerIzquierda, EventTriggerType.PointerUp, OnPointerUpLeft);
        }

        if (botonDerecha != null)
        {
            // A�adir eventos al bot�n de la derecha
            EventTrigger triggerDerecha = botonDerecha.AddComponent<EventTrigger>();
            AddEventTrigger(triggerDerecha, EventTriggerType.PointerDown, OnPointerDownRight);
            AddEventTrigger(triggerDerecha, EventTriggerType.PointerUp, OnPointerUpRight);
        }
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

        // Mueve el objeto suavemente hacia la posici�n objetivo
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    // Funci�n que a�ade eventos al bot�n
    private void AddEventTrigger(EventTrigger trigger, EventTriggerType eventType, System.Action action)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry { eventID = eventType };
        entry.callback.AddListener((eventData) => { action(); });
        trigger.triggers.Add(entry);
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
        float newX = transform.position.x - moveSpeed * Time.deltaTime;
        if (newX >= leftLimit)
        {
            targetPosition = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }

    // Funci�n para moverse a la derecha
    private void MoveRight()
    {
        float newX = transform.position.x + moveSpeed * Time.deltaTime;
        if (newX <= rightLimit)
        {
            targetPosition = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }

    // Funci�n opcional para restablecer la posici�n inicial
    public void ResetPosition()
    {
        targetPosition = initialPosition;
        transform.position = initialPosition;
    }
}
