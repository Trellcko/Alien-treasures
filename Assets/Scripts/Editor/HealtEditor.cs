using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Health))]
public class HealtEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Health healt = (Health)target;
        base.OnInspectorGUI();
        if(GUILayout.Button("TakeDamage"))
        {
            healt.TakeDamage(25f);
        }
    }
}
