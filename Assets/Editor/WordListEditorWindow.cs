using UnityEditor;
using UnityEngine;

public class WordListEditorWindow : EditorWindow
{

    //This script will allow user to Populate the word in the scriptable object we could directly load the txt file everytime but that would take uneccessary time and memory.
 

    [MenuItem("WordBoggle/Word List Tool")]
    public static void ShowWindow()
    {
        GetWindow<WordListEditorWindow>("Word List Tool");
    }

    void OnGUI()
    {
        GUILayout.Label("Word List Management", EditorStyles.boldLabel);

        if (GUILayout.Button("Populate Word List From TXT"))
        {
            WordListImporter.PopulateWordListData();
        }
    }
}