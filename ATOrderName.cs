//! 用快排，按照 sibling indx 将数组重新排序然后依次命名

// using UnityEngine;
// using UnityEditor;

// /*
//     # 代表 shift  
//     & 代表 alt
//     % 代表 Ctrl
// */

// // 将选中的资源或场景中 gameobject 按顺序命名（从1开始）
// // windows : ctrl + alt + n
// // mac osx : command + alt + n
// public class ATOrderName : Editor
// {
//     [MenuItem("GameObject/Toggle Active %&n")]
//     static void BatchActivateToggle()
//     {
//         int idx = 1;
//         GameObject[] go_arr = Selection.gameObjects;
//         if(go_arr.Length < 1 || (go_arr[1] is GameObject && go_arr[1].scene != null))
//             return;

//         // int min_sib = 
//         for (int i = 0; i < go_arr.Length; i++)
//         {
            
//         }

//         foreach (GameObject go in Selection.gameObjects)
//         {
//             string name = idx.ToString();
//             go.name = name;
//             idx++;
//         }
//     }
// }