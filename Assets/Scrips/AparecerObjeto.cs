using UnityEngine;
using UnityEngine.UI;  // Necesario para trabajar con UI

public class AparecerObjeto : MonoBehaviour
{
    public GameObject objetoParaActivar;  // Objeto dentro del prefab que se activar�
    private Button boton;  // Referencia al bot�n que est� fuera del prefab

    void Start()
    {
        // Buscar el bot�n en la escena con el tag "B-empezar"
        GameObject botonObj = GameObject.FindWithTag("B-empezar");

        if (botonObj != null)
        {
            boton = botonObj.GetComponent<Button>();  // Obtener el componente Button

            // Asegurarse de que el bot�n est� activo en la escena
            boton.gameObject.SetActive(true);

            // Asignar la funci�n Activar() al bot�n
            boton.onClick.AddListener(Activar);
        }
        else
        {
            Debug.LogWarning("No se encontr� un bot�n con el tag 'B-empezar'");
        }

        // Aseg�rate de que el objeto a activar est� desactivado al inicio
        if (objetoParaActivar != null)
        {
            objetoParaActivar.SetActive(false);
        }
    }

    // Funci�n para activar el objeto cuando se presiona el bot�n
    public void Activar()
    {
        if (objetoParaActivar != null)
        {
            objetoParaActivar.SetActive(true);  // Activa el objeto
        }
    }
}
