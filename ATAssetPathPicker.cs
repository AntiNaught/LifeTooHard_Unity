using UnityEditor;
using UnityEngine;

// 将选中的asset 的路径Log到 console ，并复制到剪切板
// windows : ctrl + j
// mac osx : command + j
public class ATPathPicker : Editor
{
    [MenuItem("GameObject/Print Selected Object Location %j")]
    static void CopyAssetLocations()
    {
        string path = string.Empty;
        Object o = Selection.activeObject;
        if (o != null)
        {
            if(o is GameObject)
            {
                GameObject go = (GameObject)o;
                if (go != null)
                {
                    if(go.scene.name != null)       // 场景中的 gameobject
                    {
                        path += go.name;
                        while (go.transform.parent != null)
                        {
                            string parentName = go.transform.parent.name;
                            path = parentName + "/" + path;
                            if (parentName == "board")
                            {
                                break;
                            }
                            else
                            {
                                go = go.transform.parent.gameObject;
                            }
                        }
                    }
                    else                            // prefab
                    {
                        path += AssetDatabase.GetAssetPath(o);
                    }
                }
            }
            else
            {
                path += AssetDatabase.GetAssetPath(o);
            }
        }
        Debug.Log(path);
        EditorGUIUtility.systemCopyBuffer = path;
    }
}