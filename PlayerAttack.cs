using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject shellPrefab;
    public KeyCode fireKey = KeyCode.Space;
    private Transform firePosition;
    public float shellSpeed = 15;
    public AudioClip shotAudio;
    // Start is called before the first frame update
    void Start()
    {
        firePosition = transform.Find("FirePosition");//获取子弹实例化位置
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(fireKey)) //判断空格是否被按下
        {
            AudioSource.PlayClipAtPoint(shotAudio, transform.position);
            GameObject go = GameObject.Instantiate(shellPrefab, firePosition.position, firePosition.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = 0.5f * go.transform.forward * shellSpeed;//给子弹以z轴为前进方向的速度

        }
    }
}
