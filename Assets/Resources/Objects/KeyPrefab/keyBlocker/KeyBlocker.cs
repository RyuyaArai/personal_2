using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBlocker : MonoBehaviour
{
    bool isAlive;
    // Start is called before the first frame update
    void Start()
    {
        isAlive=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive==false) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay(Collision other) {
        if(other.gameObject.tag == "Player") {
            if(Input.GetMouseButton(0)) {
                isAlive = false;
            }
        }
    }
}
