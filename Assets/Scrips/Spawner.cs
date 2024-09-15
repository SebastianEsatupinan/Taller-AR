using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timeToSpawn = 1.5f;  // Tiempo entre cada spawn, modificable desde el Inspector
    public List<GameObject> obsPref;  // Lista de prefabs de objetos para spawnear, modificable desde el Inspector
    public int r;  // Variable para almacenar un valor aleatorio
    public Vector3 spawnDirection = Vector3.left;  // Dirección del spawn (contraria), modificable desde el Inspector

    // Inicialización
    void Start()
    {
        Spawn();  // Llama a la función de spawn al inicio
    }

    // Función que se encarga de hacer spawn de los objetos
    void Spawn()
    {
        r = Random.Range(0, obsPref.Count);  // Selecciona un índice aleatorio de la lista
        GameObject spawnedObject = Instantiate(obsPref[r], transform.position, transform.rotation);  // Instancia el prefab seleccionado en la posición y rotación actuales

        // Si el objeto tiene un Rigidbody, aplicamos una fuerza en la dirección contraria (Vector3.left)
        Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(spawnDirection * 10f, ForceMode.Impulse);  // Aplica una fuerza hacia el lado contrario
        }

        // Llama nuevamente a Spawn después del tiempo definido
        Invoke("Spawn", timeToSpawn);
    }
}
