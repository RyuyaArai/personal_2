using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateKey : MonoBehaviour
{
    [SerializeField]
    private GameObject key;
    [SerializeField]
    private GameObject light;
    [System.NonSerialized]
    public static CreateKey instance;

    private float mapDepth;
    private float mapWidth;
    private float mapMag;

    private float pickUpKey;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
    }

    private void Start() {
        pickUpKey = Random.value * 4 + 1;
        pickUpKey = Mathf.RoundToInt(pickUpKey);

        mapDepth = CreateCubeMap.instance.GetDepth();
        mapWidth = CreateCubeMap.instance.GetWidth();
        mapMag = CreateCubeMap.instance.GetMagnification();

        CreateKeyAll();
    }


    private void CreateKeyAll() {
        for(int i = 0; i < pickUpKey; i++){
            Vector3 pos = new Vector3(Random.value * (mapDepth - 5) * mapMag + 5, 25, Random.value * (mapWidth - 5) * mapMag + 5);
            GameObject keyObj = Instantiate(key,pos,Quaternion.identity);
            GameObject lightObj = Instantiate(light,pos,Quaternion.identity);
            keyObj.transform.SetParent(transform);     //keyを子オブジェクトにする
            lightObj.transform.SetParent(keyObj.transform);
            GameManager.instance.AddMaxKeyCount();

        }
    }
}
