using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueData
{
    public string name;
    public string text;

    public DialogueData(string name, string text)
    {
        this.name = name;
        this.text = text;
    }
}