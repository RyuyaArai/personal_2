using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerDelete : MonoBehaviour
{
    [SerializeField]
    private GameObject BlockerDeleteobj;

    private GameObject blObj;

    private List<GameObject> BlockerObj;

    void Start() {
        BlockerDeleteobj.SetActive(false);
        BlockerObj = new List<GameObject>();
    }

    void Update() {
        
        

        dist = KeyBlocker.instance.GetKBDist();
        if(dist) {
            BlockerDeleteobj.SetActive(true);
        }else{
            BlockerDeleteobj.SetActive(false);
        }
    }
}
