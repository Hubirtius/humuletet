using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Map))]
public class MapEditor : Editor
{
 /*   public override void OnInspectorGUI () 
    {
        serializedObject.Update();

        Map Ref = target as Map;

        DrawDefaultInspector();

        if(GUILayout.Button("Spawn Tiles")) 
        {
            Ref.Editor_SpawnMap();

            serializedObject.ApplyModifiedProperties();

            EditorUtility.SetDirty(Ref);
        }
    }
 */
}
