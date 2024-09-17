using UnityEngine;
using UnityEngine.UI;  // Necesario para trabajar con UI

public class AparecerObjeto : MonoBehaviour
{
    public GameObject objetoParaActivar;  // Objeto dentro del prefab que se activará
    private Button boton;  // Referencia al botón que está fuera del prefab

    void Start()
    {
        // Buscar el botón en la escena con el tag "B-empezar"
        GameObject botonObj = GameObject.FindWithTag("B-empezar");

        if (botonObj != null)
        {
            boton = botonObj.GetComponent<Button>();  // Obtener el componente Button

            // Asegurarse de que el botón esté activo en la escena
            boton.gameObject.SetActive(true);

            // Asignar la función Activar() al botón
            boton.onClick.AddListener(Activar);
        }
        else
        {
            Debug.LogWarning("No se encontró un botón con el tag 'B-empezar'");
        }

        // Asegúrate de que el objeto a activar esté desactivado al inicio
        if (objetoParaActivar != null)
        {
            objetoParaActivar.SetActive(false);
        }
    }

    // Función para activar el objeto cuando se presiona el botón
    public void Activar()
    {
        if (objetoParaActivar != null)
        {
            objetoParaActivar.SetActive(true);  // Activa el objeto
        }
    }
}
