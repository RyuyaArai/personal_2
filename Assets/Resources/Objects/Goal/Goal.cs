using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameManager gm;

    private void Start(){
       
    }

    private void Update() {

       
    }

    
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") {
                gm.ChangeScene("End");
    	    }
    }

}