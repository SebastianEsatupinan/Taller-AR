using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;  // Agrega la referencia a ARFoundation si es necesario

public class ReiniciarEscena : MonoBehaviour
{
    public Camera mainCamera;
    public ARTrackedImage arTrackedImage;  // Cambié SimulatedTrackedImage por ARTrackedImage

    public void Reiniciar()
    {
        // Revisa si las referencias aún existen
        if (mainCamera != null)
        {
            // Lógica para la cámara si es necesario
        }

        if (arTrackedImage != null)
        {
            // Lógica para la imagen rastreada si es necesario
        }

        // Carga la escena actual para reiniciarla
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
