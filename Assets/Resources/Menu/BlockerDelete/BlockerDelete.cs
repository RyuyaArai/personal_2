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
        
        //リストにblockerオブジェクトを入れる
        if(blockerObj.Count < GameManager.instance.maxKeyCount) {
            blockerObj.AddRange(GameObject.FindGameObjectsWithTag("Blocker"));
        }
        //近い順にソート
        //ソートの方法考え中

        
        /*
        近い順にソートする
        一番近いやつとプレイヤーで距離とる
        一定距離以内で表示
        */

        // if(dist) {
        //     BlockerDeleteobj.SetActive(true);
        // }else{
        //     BlockerDeleteobj.SetActive(false);
        // }
    }
}
