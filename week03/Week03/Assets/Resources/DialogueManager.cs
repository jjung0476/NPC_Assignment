using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public DialogueLoader loader;
    public string eventName;
    List<DialogueData> dialogueList;
    int index = 0;

    void Start()
    {
        StartDialogue();
    }

    void StartDialogue()
    {
        dialogueList = loader.GetDialogue(eventName); //해당 event의 대화 리스트 전부 가져옴
        index = 0; //첫 대사부터 시작하도록 초기화
        ShowDialogue(); //척 대사 출력
    }

    void ShowDialogue()
    {
        string name = dialogueList[index].name;
        string text = dialogueList[index].text.Replace("\\n", "\n");
        Debug.Log(name + " : " + text); //콘솔창에 "이름 : 대사"형태로 출력
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //마우스 왼쪽 클릭(0번)시
            NextDialogue(); //다음 대사로 넘어가기
    }

    void NextDialogue()
    {
        index++; 

        if (index < dialogueList.Count) // Length는 크기가 정해져 있는 배열만, List는 가변
            ShowDialogue(); 
    }
}
