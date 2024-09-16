using UnityEngine;

public class AparecerObjeto : MonoBehaviour
{
    public GameObject objetoParaActivar;

    void Start()
    {
        // Buscar objetos con el tag "B-inicio"
        GameObject[] botones = GameObject.FindGameObjectsWithTag("B-empezar");

        if (botones.Length > 0)
        {
            // Asignar el primer objeto encontrado a "objetoParaActivar"
            objetoParaActivar = botones[0];
        }

        // Asegúrate de que el objeto esté desactivado al inicio
        if (objetoParaActivar != null)
        {
            objetoParaActivar.SetActive(false);
        }
    }

    public void Activar()
    {
        // Activa el objeto cuando lo necesites
        if (objetoParaActivar != null)
        {
            objetoParaActivar.SetActive(true);
        }
    }
}
