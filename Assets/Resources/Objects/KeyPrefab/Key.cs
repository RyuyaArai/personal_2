using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    //[SerializeField]
    //private GameManager gm;
    [SerializeField]
    private GameObject key;
    [SerializeField]
    private GameObject keyBlocker;

    private bool onGround;
    private float createCount;

    private void Start(){
        //GameObject managerObject = GameObject.Find("GameManager");
        //gm = managerObject.GetComponent<GameManager>();
        onGround = false;
    }

    private void Update() {
        if(onGround == true) {
            if(createCount == 0){
                Vector3 pos = new Vector3(
                    transform.position.x,
                    transform.position.y + 1,
                    transform.position.z);
                GameObject keyBlockObj = 
                    Instantiate(keyBlocker,pos,Quaternion.identity);
                createCount++;
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Ground") {
            onGround=true;
        }
        
        if(other.gameObject.tag == "Player") {
            GameManager.instance.AddKeyCount();
            Destroy(gameObject);
        }
    }

    // private void OnTriggerEnter(Collider other){
    //     if(other.gameObject.tag == "Player") {
    //         GameManager.instance.AddKeyCount();
    //         Destroy(gameObject);
    //     }
    // }
    
}
