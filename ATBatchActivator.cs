using UnityEditor;
using UnityEngine;

/*
*按 Ctrl + Shift + A 来 De/Activate 批量选择的 GameObejct
*/

public class ATBatchActivator : Editor
{
    [MenuItem("GameObject/Toggle Active %#a")]
    static void BatchActivateToggle()
    {
        foreach (GameObject go in Selection.gameObjects)
        {
            string undoText;

            if (go.activeSelf)
            {
                undoText = "Deactive";
            }
            else
            {
                undoText = "Active";
            }
            Undo.RecordObject(go, undoText + " " + go.name);
            go.SetActive(!go.activeSelf);
            Debug.Log(undoText.TrimEnd('e') + "ing" + go.name + ".");
        }
    }
}