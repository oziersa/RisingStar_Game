using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [Header("Dialogue Information")]
    [SerializeField] public string dialogueName;
    [TextArea(3, 10)]
    [SerializeField] public string[] sentences;


}
