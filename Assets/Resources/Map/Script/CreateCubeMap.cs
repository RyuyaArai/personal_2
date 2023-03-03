using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateCubeMap : MonoBehaviour
{
    [SerializeField]
    private GameManager gm;
    [SerializeField]
    private PhysicMaterial pm;
    [System.NonSerialized]
    public static CreateCubeMap instance;


    [SerializeField]
    private float width = 50;   //横
    [SerializeField]
    private float depth = 50;   //奥行き
    [SerializeField]
    private float height = 15;  //高さ
    [SerializeField]
    private float relief = 15f; //起伏
    [SerializeField]
    private float magnification = 2; //大きさ


    private float seedX,seedZ;
    private int positionY;              //高さを整数に変換するやつ
    private bool needToCollider = true; //当たり判定つけるか消すか

    private void Awake() {
        CreateCubeMapAll();
        height = (Random.value * 20) + 5;
        height = Mathf.RoundToInt(height);

        if(instance == null){
            instance = this;
        }
    }
    
    private void Update() {
        if(Input.GetKeyDown(KeyCode.P)){
            gm.ChangeScene(SceneManager.GetActiveScene().name);

        }
    }

    private void SetY(GameObject cube) {
        float y = 0;
        float xSample = (cube.transform.localPosition.x + seedX) / relief;  //パーリンノイズで使う値を求める 
        float zSample = (cube.transform.localPosition.z + seedZ) / relief;  //パーリンノイズで使う値を求める
        float noise = Mathf.PerlinNoise(xSample, zSample);                  //ノイズをパーリンノイズで出した値にする
        y = height * noise;              //yを最大の高さ*noiseの値にする
        positionY = Mathf.RoundToInt(y);    //PositionYをyを四捨五入
        cube.transform.localPosition = new Vector3(cube.transform.localPosition.x, positionY, cube.transform.localPosition.z);

        Color color = Color.black;  //岩盤っぽい色

        if (y > height * 0.3f) {
            ColorUtility.TryParseHtmlString("#006400", out color);  //草っぽい色
        }

        else if (y > height * 0.0f) {
            ColorUtility.TryParseHtmlString("#4169e1", out color);  //水っぽい色
        }

        cube.GetComponent<MeshRenderer>().material.color = color;
    }


    private void CreateCubeMapAll(){
        seedX = Random.value * 100f;    //X座標ランダム
        seedZ = Random.value * 100f;    //Y座標ランダム

        //キューブ生成
        for (int x = 0; x < width; x++) {
            for (int z = 0; z < depth; z++) {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);                   //新しいキューブ作成
                cube.transform.localPosition = new Vector3(x * magnification, 0, z * magnification);    //地面に置く
                cube.transform.SetParent(transform);                //キューブを子オブジェクトにする

                if (!needToCollider) {
                    Destroy(cube.GetComponent<BoxCollider>());  //コライダーを消す
                }

                SetY(cube); //高さの設定をする
                cube.tag = "Ground";
                cube.transform.localScale = new Vector3(1 * magnification, 4, 1 * magnification);
                cube.GetComponent<BoxCollider>().material = pm;
            }
        }
    }

    public float GetWidth() { return width; }

    public float GetDepth() { return depth; }

    public float GetMagnification() { return magnification; }



}
