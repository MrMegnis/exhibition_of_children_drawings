using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ProportionalSizeSynchronizer : MonoBehaviour
{
    public GameObject targetObject; // Объект, размер которого нужно копировать
    private Vector3 initialScale; // Начальный масштаб текущего объекта
    private Vector3 targetInitialScale; // Начальный масштаб targetObject

    private void Start()
    {
        if (targetObject != null)
        {
            initialScale = transform.localScale;
            targetInitialScale = targetObject.transform.localScale;
        }
        else
        {
            Debug.LogError("Target object is not assigned.");
        }
    }

    private void Update()
    {
        SyncSize();
    }

    private void SyncSize()
    {
        if (targetObject != null)
        {
            Vector3 targetCurrentScale = targetObject.transform.localScale;
            Vector3 scaleRatio = new Vector3(
                targetCurrentScale.x / targetInitialScale.x,
                targetCurrentScale.y / targetInitialScale.y,
                targetCurrentScale.z / targetInitialScale.z
            );

            transform.localScale = new Vector3(
                initialScale.x * scaleRatio.x,
                initialScale.y * scaleRatio.y,
                initialScale.z * scaleRatio.z
            );
        }
    }

    // Метод для теста в редакторе
    private void OnValidate()
    {
        if (!Application.isPlaying)
        {
            Start();
            SyncSize();
        }
    }
}


