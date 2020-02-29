using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;

/*
 * 将儿子们的 localPosition 打印到文件
 *
 * 
 */

public class ATChildrenPosPrinter : Editor
{
    [MenuItem("GameObject/LTH/LogChildPos")]
    static void Medhod()
    {
        GameObject go = Selection.activeGameObject;
        if (go != null && go.scene != null)
        {
            LogToFile(go);
        }
    }
    //static string logPath = Application.dataPath.Replace("/Assets", "") + "/LogFile/";
    static string filePath = Application.dataPath + "/Editor/Resources/";
    const string defaultFile = "MyLog.txt";
    public static void LogToFile(GameObject go)
    {
        Debug.Log("filePath :: " + filePath);
        StreamWriter sw;
        FileStream fs = null;
        string path = filePath + go.name + "_children_localposition.lua";
        if (!File.Exists(path))
        {
            sw = File.CreateText(path);
        }
        else
        {
            fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            sw = new StreamWriter(fs, Encoding.UTF8);
        }
        sw.WriteLine("local pos = {");
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < go.transform.childCount; i++)
        {
            Transform child = go.transform.GetChild(i);
            float x = child.localPosition.x;
            float y = child.localPosition.y;
            sb.Clear();
            sb.Append("\t[");
            sb.Append(i);
            sb.Append("] = { x = ");
            sb.Append(x);
            sb.Append(", y = ");
            sb.Append(y);
            sb.Append("},");
            Debug.Log(sb.ToString());
            sw.WriteLine(sb.ToString());
        }
        sw.WriteLine("}\nreturn pos");
        sw.Close();
        if (fs != null)
            fs.Close();
    }
}