using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBlocker : MonoBehaviour
{

    [SerializeField]
    private Transform playerObj;
    [System.NonSerialized]
    public static KeyBlocker instance;


    bool isAlive;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
    }

    private void Start() {
        isAlive=true;
    }

    // Update is called once per frame
    private void FixedUpdate() {

        var distance = Vector3.Distance(transform.position,playerObj.position);

        if(isAlive==false) {
            Destroy(gameObject);
        }
        
        if(distance <= 3){
            if(Input.GetMouseButton(0)) {
                isAlive = false;
            }
        }    
    }

    // private void OnCollisionStay(Collision other) {
    //     if(other.gameObject.tag == "Player") {
    //         if(Input.GetMouseButton(0)) {
    //             isAlive = false;
    //         }
    //     }
    // }
}
