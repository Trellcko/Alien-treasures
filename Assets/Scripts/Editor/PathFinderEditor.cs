using UnityEngine;
using UnityEditor;
using PathFinding;

[CustomEditor(typeof(PathFinder))]
public class PathFinderEditor : Editor
{

    public override void OnInspectorGUI()
    {
        PathFinder pathFinder = (PathFinder)target;
        base.OnInspectorGUI();
        if(GUILayout.Button("Debug Grid"))
        {
            pathFinder.DrawGrid();
        }
    }

}
