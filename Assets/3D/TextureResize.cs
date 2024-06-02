using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TextureResizer : MonoBehaviour
{
    public Texture2D texture;

    public MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnValidate()
    {
        if (texture != null)
        {
            SetTexture(texture);
        }
    }

    public void SetTexture(Texture2D newTexture)
    {
        texture = newTexture;

        // Проверяем, что meshRenderer не null перед использованием
        if (meshRenderer != null)
        {
            meshRenderer.sharedMaterial.mainTexture = texture;
            ResizeToFit(texture);
        }
        else
        {
            Debug.LogError("MeshRenderer is not assigned or found on the GameObject.");
        }
    }

    private void ResizeToFit(Texture2D texture)
    {
        if (texture != null)
        {
            float aspectRatio = (float)texture.width / texture.height;
            transform.localScale = new Vector3(aspectRatio, 1, 1);
        }
    }
}