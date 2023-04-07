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
    private BlockType BlMyType;
     
    private void Awake() {
        if(instance == null){
            instance = this;
        }
    }

    private void Start() {
        isAlive = true;
        playerObj = GameObject.Find("Player");
        var temp = Random.value * 3;
        BlMyType = (BlockType)Mathf.RoundToInt(temp);
        BlockerDeleteobj.SetActive(false);
    }

    private void Update() {

        bool isPause = RestartMenu.instance.GetIsPause();

        if(isPause) { return; }

        blDistance = Vector3.Distance(transform.position,playerObj.transform.position);

        AttriJudge();
    }

    private void AttriJudge() {
        if(blDistance < 3 && isAlive ==true) {
            if((int)BlMyType == Player.instance.GetAttackType()){
                if(Input.GetMouseButtonDown(0)) {
                    Destroy(gameObject);
                }
            }
        }
    }
    //処理ギミックの準備
    public float GetBlDistance() { return blDistance; }
}
