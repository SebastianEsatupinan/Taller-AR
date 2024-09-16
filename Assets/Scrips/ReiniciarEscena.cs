using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;  // Agrega la referencia a ARFoundation si es necesario

public class ReiniciarEscena : MonoBehaviour
{
    public Camera mainCamera;
    public ARTrackedImage arTrackedImage;  // Cambi� SimulatedTrackedImage por ARTrackedImage

    public void Reiniciar()
    {
        // Revisa si las referencias a�n existen
        if (mainCamera != null)
        {
            // L�gica para la c�mara si es necesario
        }

        if (arTrackedImage != null)
        {
            // L�gica para la imagen rastreada si es necesario
        }

        // Carga la escena actual para reiniciarla
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
