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

    // Bot�n que activa el tracking y alterna entre paneles
    public Button startButton;

    private bool isTrackingEnabled = false;  // Estado del tracking
    private int currentPanelIndex = 0;  // �ndice del panel actual

    // Start es llamado al iniciar el script
    void Start()
    {
        // Desactivamos el seguimiento de im�genes al inicio
        trackedImageManager.enabled = false;

        // Mostramos el primer panel al inicio
        ShowPanel(currentPanelIndex);

        // A�adimos el listener al bot�n para que se active el tracking y cambie el panel cuando se presione
        startButton.onClick.AddListener(OnStartButtonPressed);
    }

    // Funci�n llamada cuando el bot�n es presionado
    void OnStartButtonPressed()
    {
        // Habilitamos el AR Tracked Image Manager para comenzar el tracking de im�genes
        trackedImageManager.enabled = true;

        // Cambiamos el estado del tracking
        isTrackingEnabled = true;

        // Ocultamos el panel actual y mostramos el siguiente
        NextPanel();

        // Opcional: Deshabilitar el bot�n si solo necesitas activarlo una vez
        // startButton.gameObject.SetActive(false);
    }

    // Funci�n para mostrar un panel espec�fico por �ndice
    public void ShowPanel(int index)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            if (i == index)
            {
                panels[i].SetActive(true);  // Mostramos el panel en el �ndice
            }
            else
            {
                panels[i].SetActive(false);  // Ocultamos los dem�s paneles
            }
        }
    }

    // Funci�n para ocultar el panel actual y mostrar el siguiente
    public void NextPanel()
    {
        // Ocultar el panel actual
        panels[currentPanelIndex].SetActive(false);

        // Incrementar el �ndice del panel (si llegamos al final volvemos al primero)
        currentPanelIndex = (currentPanelIndex + 1) % panels.Length;

        // Mostrar el siguiente panel
        panels[currentPanelIndex].SetActive(true);
    }

    // Update es llamado una vez por frame (puedes a�adir l�gica adicional aqu� si la necesitas)
    void Update()
    {
        if (isTrackingEnabled)
        {
            // L�gica adicional mientras el tracking est� habilitado
        }
    }
}
