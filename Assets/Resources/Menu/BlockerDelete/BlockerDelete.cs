using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerDelete : MonoBehaviour
{
    [System.NonSerialized]
    public static BlockerDelete instance;
    [SerializeField]
    private GameObject BlockerDeleteobj;

    //private GameObject[] blockerObj
    [SerializeField]
    private List<GameObject> blockerObj;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
    }

    void Start() {
        BlockerDeleteobj.SetActive(false);
        blockerObj = new List<GameObject>();
    }

    void FixedUpdate() {
        
        //参照しなおすためにリセット
        blockerObj.Clear();

        //リストにblockerオブジェクトを入れる
        if(blockerObj.Count < GameManager.instance.maxKeyCount - GameManager.instance.keyCount) {
            blockerObj.AddRange(GameObject.FindGameObjectsWithTag("Blocker"));
        }

        //近い順にソート
        blockerObj.Sort(
            (a, b) => {
                float temp = a.GetComponent<KeyBlocker>().GetBlDistance() - b.GetComponent<KeyBlocker>().GetBlDistance();
                return (int)temp;
            }
        );
        
        BlockerDeleteobj.SetActive(false);
        
        if(blockerObj[0].GetComponent<KeyBlocker>().GetBlDistance() < 3 && blockerObj[0].GetComponent<KeyBlocker>().GetBlDistance() != 0) {
            BlockerDeleteobj.SetActive(true);
        }
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
