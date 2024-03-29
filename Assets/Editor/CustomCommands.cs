﻿#if (UNITY_EDITOR)

using UnityEngine;
using UnityEditor;

public class CustomCommands : Editor
{

    // Activate or Deactivate Objects
    // =============================================== Activate or Deactivate Objects
    [MenuItem("Custom Commands/Activate or Deactivate _a")]
    static void ActivateSelection()
    {
        if (EditorWindow.mouseOverWindow.GetInstanceID() != 15558)
        {
            if (Selection.activeTransform != null)
            {
                GameObject[] objs;
                objs = Selection.gameObjects;

                int _active = 0;
                int _objectCount = 0;

                // Count how many objects there are
                foreach (GameObject go in objs)
                {
                    if (go.activeInHierarchy == true)
                        _active++;

                    _objectCount++;
                }

                // Get Active Percent
                float _activePercent = _active * 100 / _objectCount;
                //Debug.Log("Activate = " + _activePercent + "%");

                // Decide to activate or deactivate
                if (_activePercent >= 50)
                {
                    // Deativate
                    foreach (GameObject go in objs)
                        if (go.activeInHierarchy == true)
                        {
                            Undo.RecordObject(go, "Disabled MeshRenderer");
                            go.SetActive(false);
                        }
                }

                else
                {
                    // Activate
                    foreach (GameObject go in objs)
                        if (go.activeInHierarchy == false)
                        {
                            Undo.RecordObject(go, "Disabled MeshRenderer");
                            go.SetActive(true);
                        }
                }
            }
        }
            
    }


    // Reset Position
    // =============================================== Reset Position
    [MenuItem("Custom Commands/Reset Position _s")]
    static void ResetPosition()
    {
        if (EditorWindow.mouseOverWindow.GetInstanceID() != 15558)
        {
            if (Selection.activeTransform != null)
            {
                GameObject[] objs;
                objs = Selection.gameObjects;

                foreach (GameObject go in objs)
                {
                    Undo.RecordObject(go.transform, "Reset object local position");
                    go.transform.position = Vector3.zero;
                }
            }
        }
            
    }

    // Reset Local Position
    [MenuItem("Custom Commands/Reset Local Position #s")]
    static void ResetLocalPosition()
    {
        if (EditorWindow.mouseOverWindow.GetInstanceID() != 15558)
        {
            if (Selection.activeTransform != null)
            {
                GameObject[] objs;
                objs = Selection.gameObjects;

                foreach (GameObject go in objs)
                {
                    Undo.RecordObject(go.transform, "Reset object local position");
                    go.transform.localPosition = Vector3.zero;
                }
            }
        }
    }


    // Enable & Disable MeshRenderer
    // =============================================== Enable & Disable MeshRenderer
    [MenuItem("Custom Commands/Enable or Disable MeshRenderer _d")]
    static void EnableMeshRenderer()
    {
        if (EditorWindow.mouseOverWindow.GetInstanceID() != 15558)
        {
            if (Selection.activeTransform != null)
            {
                GameObject[] objs;
                objs = Selection.gameObjects;

                int _enabled = 0;
                int _objectCount = 0;

                // Count how many objects there are
                foreach (GameObject go in objs)
                {
                    if (go.GetComponent<MeshRenderer>() == true)
                    {
                        if (go.GetComponent<MeshRenderer>().enabled == true)
                            _enabled++;

                        _objectCount++;
                    }
                }

                // Get Active Percent
                float _enablePercent = _enabled * 100 / _objectCount;
                //Debug.Log("Enabled = " + _enablePercent + "%");

                // Decide to activate or deactivate
                if (_enablePercent >= 50)
                {
                    // Disable
                    foreach (GameObject go in objs)
                    {
                        if (go.GetComponent<MeshRenderer>() == true)
                        {
                            MeshRenderer _meshRend = go.GetComponent<MeshRenderer>();

                            if (_meshRend.enabled == true)
                            {
                                Undo.RecordObject(_meshRend, "Disabled MeshRenderer");
                                _meshRend.enabled = false;
                            }
                        }
                    }
                }

                else
                {
                    // Enable
                    foreach (GameObject go in objs)
                    {
                        if (go.GetComponent<MeshRenderer>() == true)
                        {
                            MeshRenderer _meshRend = go.GetComponent<MeshRenderer>();

                            if (_meshRend.enabled == false)
                            {
                                Undo.RecordObject(_meshRend, "Enabled MeshRenderer");
                                _meshRend.enabled = true;
                            }
                        }
                    }
                }
            }
        }
    }

    [MenuItem("Custom Commands/Check window _v")]
    static void CheckWindow()
    {
        Debug.Log("<color=yellow>" + EditorWindow.mouseOverWindow.GetInstanceID() + "</color>");

        if (EditorWindow.mouseOverWindow.GetInstanceID() == 15558)
            Debug.Log("<color=orange>Found it!</color>");
    }

    
}
#endif
