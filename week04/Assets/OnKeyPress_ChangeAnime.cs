using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 키를 누르면 애니메이션을 전환한다 
public class OnKeyPress_ChangeAnime : MonoBehaviour
{

    public string upAnime = "";     
    public string downAnime = "";   
    public string rightAnime = "";  
    public string leftAnime = "";   

    string nowMode = "";
    string oldMode = "";

    void Start()
    {
        nowMode = downAnime;
        oldMode = "";
    }

    void Update()
    {
        if (Input.GetKey("up"))
        {
            nowMode = upAnime;
        }
        if (Input.GetKey("down"))
        {
            nowMode = downAnime;
        }
        if (Input.GetKey("right"))
        {
            nowMode = rightAnime;
        }
        if (Input.GetKey("left"))
        {
            nowMode = leftAnime;
        }
    }
    void FixedUpdate() // 계속 시행한다(일정 시간마다)
    {
        if (nowMode != oldMode)
        {
            oldMode = nowMode;
            Animator animator = this.GetComponent<Animator>();
            animator.Play(nowMode);
        }
    }
}
