using UnityEngine;
using UnityEditor;
using System.IO;

public class WordListImporter
{
    [MenuItem("Tools/Populate WordListData From TXT")]

    //This script will get the text file provided for valid words and populate the data in the ValidWordsList asset
    public static void PopulateWordListData()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("wordlist");
        if (textAsset == null)
        {
            return;
        }
        string[] words = textAsset.text.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        ValidWordsList wordListData = AssetDatabase.LoadAssetAtPath<ValidWordsList>("Assets/Data/ValidWordsList.asset");

        if (wordListData == null)
        {
            return;
        }
        wordListData.words = new System.Collections.Generic.List<string>(words);
        EditorUtility.SetDirty(wordListData);
        AssetDatabase.SaveAssets();
    }
}