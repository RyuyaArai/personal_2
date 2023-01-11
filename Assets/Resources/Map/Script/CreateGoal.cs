using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGoal : MonoBehaviour
{
    [SerializeField]    
    private GameObject goal;
    [SerializeField]
    private GameObject light;

    private float mapDepth;
    private float mapWidth;

    private bool isGoalAct;

    // Start is called before the first frame update
    void Start() {
        mapDepth = CreateCubeMap.instance.GetDepth();
        mapWidth = CreateCubeMap.instance.GetWidth();
        isGoalAct = false;
    }

    // Update is called once per frame
    void Update()
    {
        int kCount = GameManager.instance.keyCount;
        int mkCount = GameManager.instance.maxKeyCount;

        if(kCount >= mkCount && isGoalAct == false){
            Vector3 pos = new Vector3(mapWidth / 2, 20,mapDepth / 2);
            GameObject obj = Instantiate(goal, pos, Quaternion.identity);
            GameObject lightObj = Instantiate(light,pos,Quaternion.identity);
            lightObj.transform.SetParent(obj.transform);
            isGoalAct = true;
        }
    }
}
