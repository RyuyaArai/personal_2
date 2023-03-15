using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBlocker : MonoBehaviour
{
    [System.NonSerialized]
    public static KeyBlocker instance;
    [SerializeField]
    private float blDistance;
    [SerializeField]
    private Vector3 plpos;
    [SerializeField]
    private GameObject BlockerDeleteobj;

    private GameObject playerObj;

    private bool isAlive;
    private bool isDist;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
    }

    private void Start() {
        isAlive = true;
        isDist = false;
        playerObj = GameObject.Find("Player");

        BlockerDeleteobj.SetActive(false);
    }

    private void Update() {
        
        blDistance = Vector3.Distance(transform.position,playerObj.transform.position);

        
        if(blDistance < 3 && isAlive ==true) {
            isDist = true;
            
        }
        
        if(isDist) {
            if(Input.GetMouseButtonDown(0)) {
                isAlive = false;
            }
        }


        if(isAlive == false) {
            Destroy(gameObject);
        }

    }

    public float GetBlDistance() { return blDistance; }
}
