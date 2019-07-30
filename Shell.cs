using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public AudioClip shellExplosionAudio;
    public GameObject shellExplosionPrefab;
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider collider)
    {
        AudioSource.PlayClipAtPoint(shellExplosionAudio, transform.position);
        GameObject.Instantiate(shellExplosionPrefab, transform.position, transform.rotation);//实例化爆炸特效
        //GameObject.Destroy(this.gameObject);
        if (collider.tag == "Player")
        { collider.SendMessage("TakeDamage"); }
    }
}
