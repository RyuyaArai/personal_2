using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    //[SerializeField]
    //private GameManager gm;
    [SerializeField]
    private GameObject key;


    private void Start(){
        //GameObject managerObject = GameObject.Find("GameManager");
        //gm = managerObject.GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision other) {
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
