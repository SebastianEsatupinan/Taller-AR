using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;  // Para usar ARTrackedImageManager
using UnityEngine.UI;              // Para usar el botón

public class PanelControl : MonoBehaviour
{
    // Referencias a los GameObjects de los paneles
    public GameObject[] panels;  // Arreglo para múltiples paneles

    // Referencia al ARTrackedImageManager para el tracking de imágenes
    public ARTrackedImageManager trackedImageManager;

    public Button startButton;

    private bool isTrackingEnabled = false;  // Estado del tracking

    void Start()
    {
        // Desactivamos el seguimiento de imágenes al inicio
        trackedImageManager.enabled = false;

        ShowSpecificPanel(0);  // Muestra el panel con índice 0 al inicio

        startButton.onClick.AddListener(OnStartButtonPressed);
    }

    // Función llamada cuando el botón es presionado
    void OnStartButtonPressed()
    {
        EnableTracking(true);

        ShowSpecificPanel(1);
    }

    // Método público para activar o desactivar el tracking
    public void EnableTracking(bool enable)
    {
        trackedImageManager.enabled = enable;
        isTrackingEnabled = enable;
    }

    // Función para mostrar un panel específico por índice
    public void ShowSpecificPanel(int index)
    {
        HideAllPanels();  // Oculta todos los paneles primero
        if (index >= 0 && index < panels.Length)
        {
            panels[index].SetActive(true);  // Muestra el panel especificado
        }
    }

    // Método público para ocultar todos los paneles
    public void HideAllPanels()
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
    }
    void Update()
    {
        if (isTrackingEnabled)
        {

        }
    }
}
