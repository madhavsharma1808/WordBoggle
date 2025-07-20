using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ValidWordsList", menuName = "Scriptable Objects/ValidWordsList")]

//The scriptable object used for valid word check
public class ValidWordsList : ScriptableObject
{
     public List<string> words;
}
