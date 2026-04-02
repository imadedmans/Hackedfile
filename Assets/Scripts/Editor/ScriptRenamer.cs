using UnityEngine;
using UnityEditor;

public class ScriptRenamer : EditorWindow
{
    Object script;
    string nameReplacement;

    [MenuItem("Game Tools/Rename Script")]
    static void OpenWindow()
    {
        ScriptRenamer window  = (ScriptRenamer)EditorWindow.GetWindow(typeof(ScriptRenamer));
    }

    void OnGUI()
    {
        // string scriptDes = "Insert your script here:";
        // string replaceDes = "Type in a replacement name for your script:";

        // script = EditorGUILayout.ObjectField(scriptDes, script, typeof(MonoBehaviour));
        // nameReplacement = EditorGUILayout.TextField(replaceDes, nameReplacement);

        // if(GUILayout.Button("Press to change name!"))
        // {
        //     if(nameReplacement == "")
        //     {
        //         Debug.Log("You haven't typed in a name yet!");
        //     }
        //     else
        //     {
        //         Debug.Log("Name has been assigned to " + script.name);
        //     }
        // }
    }
}
