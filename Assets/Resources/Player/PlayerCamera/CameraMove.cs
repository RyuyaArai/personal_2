using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
 //　キャラクターのTransform
    [SerializeField]
    private GameObject PLObject;
    [SerializeField]
    private GameObject CamObject;
    //　カメラの移動スピード
    [SerializeField]
    private float cameraMoveSpeed;
    //　カメラの回転スピード
    [SerializeField]
    private float cameraRotateSpeed;
    //　カメラのキャラクターからの相対値を指定
    [SerializeField]
    private Vector3 offset = new Vector3(0f, 2f, 4f);
    // 障害物とするレイヤー
    [SerializeField]
    private LayerMask obstacleLayer;
 
    private bool isPause;

    private Vector3 charaPos;

    private void Start() {
        CamObject = Camera.main.gameObject;
        PLObject = GameObject.Find("Player");
    }

    private void Update() {
        isPause = MenuManager.instance.GetIsPause();
        if(!isPause) {
            //　通常のカメラ位置を計算
            //var cameraPos = charaLookAtPosition.position + (-charaLookAtPosition.forward * basePos.z) + (Vector3.up * basePos.y);
            //　カメラの位置をキャラクターの後ろ側に移動させる
            //transform.position = Vector3.Lerp(transform.position, cameraPos, cameraMoveSpeed * Time.deltaTime);
            //transform.LookAt(charaLookAtPosition.position);
            //transform.position += charaLookAtPosition.position - charaPos;
            //charaPos = charaLookAtPosition.position;

            // // X方向に一定量移動していれば横回転
            // if (Mathf.Abs(mx) > 0.00001f)
            // {
            //     // 回転軸はワールド座標のY軸
            //     _x = charaLookAtPosition.position.x + Mathf.Cos(mx * Time.deltaTime) * 5;
            //     //transform.RotateAround(charaPos, Vector3.up, mx * Time.deltaTime * 200f);
            //     //transform.position.x = charaLookAtPosition.position.x + Mathf.Cos(mx *Time.deltaTime) * 5;
            // }
    
            // // Y方向に一定量移動していれば縦回転
            // if (Mathf.Abs(my) > 0.00001f)
            // {
            //     // 回転軸はカメラ自身のX軸
            //     _y = charaLookAtPosition.position.y + Mathf.Sin(my * Time.deltaTime) * 2;
            //     //transform.RotateAround(charaPos, transform.right, -my * Time.deltaTime * 200f);
            //     //transform.position.y = charaLookAtPosition.position.y + Mathf.Sin(Mathf.PI * my / 180) * 2;
            // }

            // transform.position = new Vector3(_x,_y,0);

            
            //　スピードを考慮する場合
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(charaLookAtPosition.position - transform.position), cameraRotateSpeed * Time.deltaTime);
            //transform.LookAt(charaLookAtPosition.position);

            // // // マウスの移動量を取得
            // float mx = Input.GetAxis("Mouse X");
            // float my = Input.GetAxis("Mouse Y");

            RotateCam();

            // RaycastHit hit;
            // //　キャラクターとカメラの間に障害物があったら障害物の位置にカメラを移動させる
            // if (Physics.Linecast(PLObject.transform.position, CamObject.transform.position, out hit, obstacleLayer)) {
            //     CamObject.transform.position = hit.point;
            // }
            //　レイを視覚的に確認
            Debug.DrawLine(PLObject.transform.position, CamObject.transform.position, Color.red, 0f, false);
    
        }
    }
    private void RotateCam(){
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * cameraRotateSpeed + offset.x,Input.GetAxis("Mouse Y") * cameraRotateSpeed + offset.y,offset.z);

        CamObject.transform.RotateAround(PLObject.transform.position,Vector3.up,angle.x);
        CamObject.transform.RotateAround(PLObject.transform.position,transform.right,angle.y);
    }

}
