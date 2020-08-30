//  ==================================================================================================================
//  <description>NestAnimClips.cs - Nesting AnimationClips inside an AnimationContoller.</description>
//  <author>ZombieGorilla for Unity Forums, Modified by K-Res.</author>
//  <version>1.0</version>
//  <date>2016-02-14</date>
//  ==================================================================================================================

using UnityEngine;
using UnityEditor;

public class NestAnimClips : MonoBehaviour
{
    [MenuItem("Assets/Nest AnimClips in Controller")]
    static public void nestAnimClips()
    {
        UnityEditor.Animations.AnimatorController anim_controller = null;
        AnimationClip[] clips = null;

        if (Selection.activeObject.GetType() == typeof(UnityEditor.Animations.AnimatorController))
        {
            anim_controller = (UnityEditor.Animations.AnimatorController)Selection.activeObject;
            clips = anim_controller.animationClips;

            if (anim_controller != null && clips.Length > 0)
            {
                foreach (AnimationClip ac in clips)
                {
                    var acAssetPath = AssetDatabase.GetAssetPath(ac);
                    // Check if this ac is not in the controller
                    if (acAssetPath.EndsWith(".anim"))
                    {
                        var new_ac = Object.Instantiate(ac) as AnimationClip;
                        new_ac.name = ac.name;

                        AssetDatabase.AddObjectToAsset(new_ac, anim_controller);
                        AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(new_ac));
                        AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(ac));
                    }
                }
                Debug.Log("<color=orange>Added " + clips.Length.ToString() + " clips to controller: </color><color=yellow>" + anim_controller.name + "</color>");
            }
            else
            {
                Debug.Log("<color=red>Nothing done. Select a controller that has anim clips to nest.</color>");
            }
        }

    }
}