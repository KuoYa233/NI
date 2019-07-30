using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int hp = 100;
    public GameObject playerExplosion;
    public AudioClip playerExplosionAudio;
    public Slider hpSlider;
    private int hpTotal = 100;


    // Start is called before the first frame update
    void Start()
    {
        hp = hpTotal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage()//扣血

    {
        print("进入TakeDamage方法");
        if (hp <= 0) return;
        hp -= Random.Range(10, 20);
        hpSlider.value = (float) hp / hpTotal;
        if (hp <= 0)

        {
            //血量为0时播放死亡效果
            AudioSource.PlayClipAtPoint(playerExplosionAudio, transform.position);
            GameObject.Instantiate(playerExplosion, transform.position + Vector3.up, transform.rotation);
            GameObject.Destroy(this.gameObject);
        }
    }
}
