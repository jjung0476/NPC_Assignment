using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLoader : MonoBehaviour
{
    public Dictionary<string, List<DialogueData>> dialogueDict 
        = new Dictionary<string, List<DialogueData>>();

    void Awake()
    {
        LoadCSV();
    }

    void LoadCSV()
    {
        TextAsset csv = Resources.Load<TextAsset>("Dialogue");

        string[] lines = csv.text.Split('\n');
        string currentEvent = "";
        List<DialogueData> currentList = null;

        for (int i = 1; i < lines.Length; i++)
        {
            string[] row = lines[i].Split(',');
            string eventName = row[0].Trim();
            string name = row.Length > 1 ? row[1].Trim() : "";
            string text = "";
            if (row.Length > 2)
                text = string.Join(",", row, 2, row.Length - 2).Trim();

            if (eventName == "end")
            {
                if (currentEvent != "")
                    dialogueDict[currentEvent] = currentList; //리스트를 최종 저장

                currentEvent = ""; //다음 이벤트를 위해 초기화
                currentList = null;
                continue; 
            }

            if (eventName != "")
            {
                currentEvent = eventName; //새로운 이벤트 이름 설정
                currentList = new List<DialogueData>(); //새 리스트 생성
            }

            if (currentList != null && text != "")
                currentList.Add(new DialogueData(name, text)); 
        } 
    }

    public List<DialogueData> GetDialogue(string eventName)
    {
        return dialogueDict[eventName];
    }
}
