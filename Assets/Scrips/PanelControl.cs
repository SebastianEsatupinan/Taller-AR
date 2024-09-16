using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;  // Para usar ARTrackedImageManager
using UnityEngine.UI;              // Para usar el bot�n

public class PanelControl : MonoBehaviour
{
    // Referencias a los GameObjects de los paneles
    public GameObject[] panels;  // Arreglo para m�ltiples paneles

    // Referencia al ARTrackedImageManager para el tracking de im�genes
    public ARTrackedImageManager trackedImageManager;

    public Button startButton;

    private bool isTrackingEnabled = false;  // Estado del tracking

    void Start()
    {
        // Desactivamos el seguimiento de im�genes al inicio
        trackedImageManager.enabled = false;

        ShowSpecificPanel(0);  // Muestra el panel con �ndice 0 al inicio

        startButton.onClick.AddListener(OnStartButtonPressed);
    }

    // Funci�n llamada cuando el bot�n es presionado
    void OnStartButtonPressed()
    {
        EnableTracking(true);

        ShowSpecificPanel(1);
    }

    // M�todo p�blico para activar o desactivar el tracking
    public void EnableTracking(bool enable)
    {
        trackedImageManager.enabled = enable;
        isTrackingEnabled = enable;
    }

    // Funci�n para mostrar un panel espec�fico por �ndice
    public void ShowSpecificPanel(int index)
    {
        HideAllPanels();  // Oculta todos los paneles primero
        if (index >= 0 && index < panels.Length)
        {
            panels[index].SetActive(true);  // Muestra el panel especificado
        }
    }

    // M�todo p�blico para ocultar todos los paneles
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
