using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerFloat : MonoBehaviour
{
    public float radian = 0.1f; // 弧度  
    float perRadian = 0.5f; // 每次变化的弧度，上下浮动
    public float radius = 0.1f; // 半径  
    float dy = 0;// dy是平行于y轴的分量
    //Vector3 oldPos; // 开始时候的位置坐标
    private Rigidbody rd;
    public float speed = 1;
    public float angularSpeed = 5;
    public float number = 1;

    bool isMove = false;
    // Start is called before the first frame update
    
        //================注意：直接用这个脚本就可以实现移动和浮动功能=================
    void Start()
    {
        //oldPos = transform.position;
        rd = GetComponent<Rigidbody>();
        //transform.GetComponent<Rigidbody>().freezeRotation = true;
    }

    public void StaticFloat()
    {
            radian += perRadian;
            dy = Mathf.Sin(radian) * radius; //sin，tan都可以  
            transform.position = rd.position + new Vector3(0, dy, 0);
        
        //else
        //{
        //    radian = 7;
        //    radian -= perRadian;
        //    dy = Mathf.Sin(radian) * radius; //sin，tan都可以  
        //    transform.position = oldPos - new Vector3(0, dy, 0);
        //}

        
    }
// Update is called once per frame
    void Update()
    {
        //float h = Input.GetAxis("HorizontalPlayer"+number);
        //float v = Input.GetAxis("VerticalPlayer" + number);
        float v = Input.GetAxis("VerticalPlayer" + number);
        GetComponent<Rigidbody>().velocity = transform.forward * v * speed;
        float h = Input.GetAxis("HorizontalPlayer" + number);
        GetComponent<Rigidbody>().angularVelocity = transform.up * h * angularSpeed;

        //rd.MovePosition(transform.position + new Vector3(h, 0, v) * speed * Time.deltaTime);
        if (number == 1)//Player1，没移动就浮动
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                isMove = true;
                //print("方向键被按下");

            }
            else
            {
                isMove = false;
                StaticFloat();
                //print("方向键都没被按下");
            }
        }
        else//Player2
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
            {
                isMove = true;
                //print("方向键被按下");

            }
            else
            {
                isMove = false;
                StaticFloat();
                //print("方向键都没被按下");
            }
        }
    }
}
