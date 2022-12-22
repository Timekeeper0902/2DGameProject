using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Timekeeper
{
    /// This just exposes the Sorting Layer / Order in MeshRenderer since it's there
    /// but not displayed in the inspector. Getting MeshRenderer to render in front
    /// of a SpriteRenderer is pretty hard without this.
    [CustomEditor(typeof(MeshRenderer))]
    public class MeshRendererSortingEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            MeshRenderer renderer = target as MeshRenderer;


            var layers = SortingLayer.layers;

            EditorGUILayout.BeginHorizontal();
            EditorGUI.BeginChangeCheck();
            int newId = DrawSortingLayersPopup(renderer.sortingLayerID);
            if (EditorGUI.EndChangeCheck())
            {
                renderer.sortingLayerID = newId;
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUI.BeginChangeCheck();
            int order = EditorGUILayout.IntField("Sorting Order", renderer.sortingOrder);
            if (EditorGUI.EndChangeCheck())
            {
                renderer.sortingOrder = order;
            }
            EditorGUILayout.EndHorizontal();

        }

        int DrawSortingLayersPopup(int layerID)
        {
            var layers = SortingLayer.layers;
            var names = layers.Select(l => l.name).ToArray();
            if (!SortingLayer.IsValid(layerID))
            {
                layerID = layers[0].id;
            }
            var layerValue = SortingLayer.GetLayerValueFromID(layerID);
            var newLayerValue = EditorGUILayout.Popup("Sorting Layer", layers.ToList().FindIndex(l => l.id == layerID), names);
            return layers[newLayerValue].id;
        }
    }
}
