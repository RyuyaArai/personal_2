using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerDelete : MonoBehaviour
{
    [SerializeField]
    private GameObject BlockerDeleteobj;

    private GameObject blObj;

    void Start() {
        BlockerDeleteobj.SetActive(false);
        
    }

    void Update() {

        bool dist = KeyBlocker.instance.GetKBDist();
        if(dist) {
            BlockerDeleteobj.SetActive(true);
        }else{
            BlockerDeleteobj.SetActive(false);
        }
    }
}
