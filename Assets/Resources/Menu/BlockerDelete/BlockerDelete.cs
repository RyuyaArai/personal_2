using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerDelete : MonoBehaviour
{
    [System.NonSerialized]
    public static BlockerDelete instance;
    [SerializeField]
    private GameObject BlockerDeleteUI;
    [SerializeField]
    private List<GameObject> blockerObj;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
    }

    private void Start() {
        BlockerDeleteUI.SetActive(false);
        blockerObj = new List<GameObject>();
    }

    private void FixedUpdate() {
        
        bool isPause = RestartMenu.instance.GetIsPause();

        if(isPause) { return; }

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
        
        BlockerDeleteUI.SetActive(false);
        
        if(blockerObj[0].GetComponent<KeyBlocker>().GetBlDistance() < 3 && blockerObj[0].GetComponent<KeyBlocker>().GetBlDistance() != 0) {
            BlockerDeleteUI.SetActive(true);
        }
    }

    public void SetActiveBDUI(bool TF) { BlockerDeleteUI.SetActive(TF); }

}
