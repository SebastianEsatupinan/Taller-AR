using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoMov : MonoBehaviour
{
    public float minSpeed = 3f;  // Velocidad m�nima, modificable desde el Inspector
    public float maxSpeed = 8f;  // Velocidad m�xima, modificable desde el Inspector
    private float speed;         // Velocidad actual que se calcular� de manera aleatoria
    public float health = 5;     // Salud del objeto, modificable desde el Inspector

    public float lifetime = 10f; // Tiempo de vida antes de destruir el objeto, modificable desde el Inspector

    void Start()
    {
        // Asigna una velocidad aleatoria dentro del rango definido
        speed = Random.Range(minSpeed, maxSpeed);

        // Inicia el temporizador para destruir el objeto despu�s de un tiempo
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Mueve el objeto hacia adelante continuamente
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // Se llama cuando el objeto colisiona con otro objeto con un collider
    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto con el que colisiona tiene el tag "Obstacle"
        if (other.CompareTag("Obstacle")) // Cambia el tag seg�n tus necesidades
        {
            TakeDamage(1);  // Reduce la salud en 1 (por ejemplo)
        }
    }

    // Funci�n para gestionar el da�o y verificar la salud
    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            AutoDestruction();  // Destruye el objeto si la salud es 0 o menos
        }
    }

    // Destruye el objeto
    private void AutoDestruction()
    {
        Destroy(gameObject);
    }
}
