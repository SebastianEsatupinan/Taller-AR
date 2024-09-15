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

    // Botón que activa el tracking y alterna entre paneles
    public Button startButton;

    private bool isTrackingEnabled = false;  // Estado del tracking
    private int currentPanelIndex = 0;  // Índice del panel actual

    // Start es llamado al iniciar el script
    void Start()
    {
        // Desactivamos el seguimiento de imágenes al inicio
        trackedImageManager.enabled = false;

        // Mostramos el primer panel al inicio
        ShowPanel(currentPanelIndex);

        // Añadimos el listener al botón para que se active el tracking y cambie el panel cuando se presione
        startButton.onClick.AddListener(OnStartButtonPressed);
    }

    // Función llamada cuando el botón es presionado
    void OnStartButtonPressed()
    {
        // Habilitamos el AR Tracked Image Manager para comenzar el tracking de imágenes
        trackedImageManager.enabled = true;

        // Cambiamos el estado del tracking
        isTrackingEnabled = true;

        // Ocultamos el panel actual y mostramos el siguiente
        NextPanel();

        // Opcional: Deshabilitar el botón si solo necesitas activarlo una vez
        // startButton.gameObject.SetActive(false);
    }

    // Función para mostrar un panel específico por índice
    public void ShowPanel(int index)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            if (i == index)
            {
                panels[i].SetActive(true);  // Mostramos el panel en el índice
            }
            else
            {
                panels[i].SetActive(false);  // Ocultamos los demás paneles
            }
        }
    }

    // Función para ocultar el panel actual y mostrar el siguiente
    public void NextPanel()
    {
        // Ocultar el panel actual
        panels[currentPanelIndex].SetActive(false);

        // Incrementar el índice del panel (si llegamos al final volvemos al primero)
        currentPanelIndex = (currentPanelIndex + 1) % panels.Length;

        // Mostrar el siguiente panel
        panels[currentPanelIndex].SetActive(true);
    }

    // Update es llamado una vez por frame (puedes añadir lógica adicional aquí si la necesitas)
    void Update()
    {
        if (isTrackingEnabled)
        {
            // Lógica adicional mientras el tracking está habilitado
        }
    }
}
