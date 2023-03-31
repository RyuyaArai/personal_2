using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBlocker : MonoBehaviour
{
    private enum BlockType {
        normal = 1,
        grass,
        mud
    };
    
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

    private BlockType myType;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
    }

    private void Start() {
        isAlive = true;
        playerObj = GameObject.Find("Player");

        //float tempType = Random.value * 3;
        //myType = Mathf.RoundToInt(tempType);
    }

    private void Update() {

        bool isPause = RestartMenu.instance.GetIsPause();

        

        if(isPause) { return; }

        blDistance = Vector3.Distance(transform.position,playerObj.transform.position);

        if(blDistance < 3 && isAlive ==true) {
            if(Input.GetMouseButtonDown(0)) {
                Destroy(gameObject);
            }
        }
    }

    public float GetBlDistance() { return blDistance; }
}
