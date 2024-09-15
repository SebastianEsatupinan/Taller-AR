using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTrackingManager : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager arTrackedImageManager;

    // Lista de prefabs a colocar seg�n la imagen de referencia
    [SerializeField] private List<GameObject> modelsToPlace;  // Lista de modelos prefabricados (prefabs)

    // Diccionario para controlar el estado de los modelos (visibles o no)
    private Dictionary<string, GameObject> activeModels = new Dictionary<string, GameObject>();

    private void OnEnable()
    {
        arTrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        arTrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        // Para im�genes detectadas nuevas
        foreach (var trackedImage in eventArgs.added)
        {
            UpdateTrackedImage(trackedImage);
        }

        // Para im�genes que fueron actualizadas (posici�n, rotaci�n)
        foreach (var trackedImage in eventArgs.updated)
        {
            UpdateTrackedImage(trackedImage);
        }

        // Para im�genes que dejaron de ser detectadas
        foreach (var trackedImage in eventArgs.removed)
        {
            if (activeModels.ContainsKey(trackedImage.referenceImage.name))
            {
                activeModels[trackedImage.referenceImage.name].SetActive(false);  // Oculta el modelo
            }
        }
    }

    private void UpdateTrackedImage(ARTrackedImage trackedImage)
    {
        string imageName = trackedImage.referenceImage.name;

        // Buscar el modelo en la lista de prefabs que coincida con el nombre de la imagen
        GameObject modelPrefab = GetModelForImage(imageName);

        if (modelPrefab != null)
        {
            // Si el modelo ya est� activo, simplemente actualiza su posici�n y rotaci�n
            if (activeModels.ContainsKey(imageName))
            {
                GameObject existingModel = activeModels[imageName];
                existingModel.transform.position = trackedImage.transform.position;
                existingModel.transform.rotation = trackedImage.transform.rotation;
                existingModel.SetActive(true);  // Asegura que el modelo est� activo
            }
            else
            {
                // Si el modelo no est� activo, crea una nueva instancia en la posici�n de la imagen
                GameObject newModel = Instantiate(modelPrefab, trackedImage.transform.position, trackedImage.transform.rotation);
                activeModels.Add(imageName, newModel);  // Lo agregamos al diccionario de modelos activos
            }
        }
        else
        {
            Debug.LogWarning($"No model associated with the image: {imageName}");
        }
    }

    // M�todo para obtener el prefab asociado al nombre de la imagen
    private GameObject GetModelForImage(string imageName)
    {
        // Compara los nombres de los prefabs con el de la imagen detectada
        foreach (var model in modelsToPlace)
        {
            if (model.name == imageName)
            {
                return model;  // Devuelve el prefab que coincide con el nombre de la imagen
            }
        }
        return null;  // Si no se encuentra ning�n prefab asociado
    }
}
