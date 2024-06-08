using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TextureResizer))]
public class TextureResizerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TextureResizer textureResizer = (TextureResizer)target;

        if (GUILayout.Button("Update Size"))
        {
            textureResizer.SetTexture(textureResizer.texture);
        }
    }
}
