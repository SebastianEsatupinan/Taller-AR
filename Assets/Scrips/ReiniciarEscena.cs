using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarEscena : MonoBehaviour
{
    public void Reiniciar()
    {
        // Carga la escena actual para reiniciarla
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
