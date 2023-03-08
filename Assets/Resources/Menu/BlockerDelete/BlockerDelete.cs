using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerDelete : MonoBehaviour
{
    [SerializeField]
    private GameObject BlockerDeleteobj;

    //private GameObject[] blockerObj

    private List<GameObject> blockerObj;

    void Start() {
        BlockerDeleteobj.SetActive(false);
        blockerObj = new List<GameObject>();
    }

    void Update() {
        
        if(blockerObj.Count < GameManager.instance.maxKeyCount) {
            blockerObj.AddRange(GameObject.FindGameObjectsWithTag("Blocker"));
        }

        

        // if(dist) {
        //     BlockerDeleteobj.SetActive(true);
        // }else{
        //     BlockerDeleteobj.SetActive(false);
        // }
    }
}
