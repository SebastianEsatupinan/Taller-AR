using UnityEngine;

public class AparecerObjeto : MonoBehaviour
{
    public GameObject objetoParaActivar;  // El objeto que quieres activar

    void Start()
    {
        // Asegúrate de que el objeto esté desactivado al inicio
        objetoParaActivar.SetActive(false);
    }

    public void Activar()
    {
        // Activa el objeto cuando lo necesites
        objetoParaActivar.SetActive(true);
    }
}
