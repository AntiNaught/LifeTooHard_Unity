using UnityEditor;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class ATResDependencyChecker : Editor
{
        // 忽略路径
        const string ignore_txt_path = "path_ignore"; 

        [MenuItem("GameObject/Log Res Dependencies")]
        static void Method()
        {
            GameObject go = Selection.activeGameObject;
            string path = AssetDatabase.GetAssetPath(go);
            string[] path_arr = AssetDatabase.GetDependencies(path);

            TextAsset txt = Resources.Load(ignore_txt_path) as TextAsset;
            string txt_str = txt.ToString();

            string[] ignore_dir = txt_str.Split('\n');
            List<Regex> r_arr = new List<Regex>();
            for (int i = 0; i < ignore_dir.Length; i++)
            {
                string s = ignore_dir[i].Trim();
                if(s.Length > 0 && !s.StartsWith("--"))
                {
                    string pattern = @"\b" + s;
                    r_arr.Add(new Regex(@"\b" + ignore_dir[i]));
                    Debug.Log("[ignore]:" + s);
                }
            }

            Debug.Log("↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓ 下面是筛选出来的依赖资源路径 ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓");

            for (int i = 0; i < path_arr.Length; i++)
            {
                bool match = false;

                for (int j = 0; j < r_arr.Count; j++)
                {
                    Regex r = r_arr[j];
                    // Debug.Log(r_arr[j] == null);
                    if(r_arr[j].IsMatch(path_arr[i]))
                    {
                        match = true;
                        break;
                    }
                }

                if(!match)
                {
                    Debug.Log(string.Format("<color=#FF0000>{0}</color>", path_arr[i]));
                }
            }
        }
}
