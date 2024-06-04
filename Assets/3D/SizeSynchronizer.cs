using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeSynchronizer : MonoBehaviour
{
    public GameObject targetObject; // Объект, размер которого нужно копировать

    private void Start()
    {
        SyncSize();
    }

    // Метод для синхронизации размеров
    public void SyncSize()
    {
        if (targetObject != null)
        {
            // Получаем размеры targetObject
            Vector3 targetSize = GetObjectSize(targetObject);
            
            // Получаем исходный размер текущего объекта
            Vector3 originalSize = GetObjectSize(gameObject);
            
            // Считаем масштаб для синхронизации размеров
            Vector3 scale = new Vector3(
                targetSize.x / originalSize.x,
                targetSize.y / originalSize.y,
                targetSize.z / originalSize.z
            );

            // Применяем новый масштаб
            transform.localScale = new Vector3(
                transform.localScale.x * scale.x,
                transform.localScale.y * scale.y,
                transform.localScale.z * scale.z
            );
        }
    }

    // Метод для получения реального размера объекта
    private Vector3 GetObjectSize(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            return renderer.bounds.size;
        }
        else
        {
            Debug.LogError("Renderer not found on " + obj.name);
            return Vector3.one;
        }
    }

    // Метод для теста в редакторе
    private void OnValidate()
    {
        SyncSize();
    }
}


