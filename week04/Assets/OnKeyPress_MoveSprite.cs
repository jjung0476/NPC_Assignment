using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 키를 누르면 스프라이트가 이동한다
public class OnKeyPress_MoveSprite : MonoBehaviour
{

    public float speed = 2; 

    float vx = 0;
    float vy = 0;
    bool leftFlag = false;

    void Update()
    { 
        vx = 0;
        vy = 0;
        if (Input.GetKey("right"))
        {
            vx = speed; 
            leftFlag = false;
        }
        if (Input.GetKey("left"))
        {
            vx = -speed; 
            leftFlag = true;
        }
        if (Input.GetKey("up"))
        {
            vy = speed; 
        }
        if (Input.GetKey("down"))
        {
            vy = -speed; 
        }
    }
    void FixedUpdate()
    {
        this.transform.Translate(vx / 50, vy / 50, 0);
        this.GetComponent<SpriteRenderer>().flipX = leftFlag;
    }
}
