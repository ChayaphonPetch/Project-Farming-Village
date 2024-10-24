using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Item))]
public class ItemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Item item = (Item)target;

        // Draw default inspector
        DrawDefaultInspector();

        // Only show price if the item is sellable
        if (item.sellable)
        {
            item.price = EditorGUILayout.IntField("Price", item.price);
        }

        // Apply changes
        if (GUI.changed)
        {
            EditorUtility.SetDirty(item);
        }
    }
}
