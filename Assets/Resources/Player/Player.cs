using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private GameObject go;

    private Vector3 startPos;

    private float inputHorizontal;
    private float inputVertical;
    private float moveSpeed = 5f;
    private float jumpPower = 250f;
    private bool isJump;

    private float mapDepth;
    private float mapWidth;
    private float mapMag;


    void Start(){
    	rb = GetComponent<Rigidbody>();
        isJump = true;
        mapDepth = CreateCubeMap.instance.GetDepth();
        mapWidth = CreateCubeMap.instance.GetWidth();
        mapMag = CreateCubeMap.instance.GetMagnification();
        startPos = new Vector3(Random.value * (mapDepth - 5) * mapMag + 5, 25, Random.value * (mapWidth - 5) * mapMag + 5);
        go.transform.position = startPos;
    }

    void Update() {
    inputHorizontal = Input.GetAxisRaw("Horizontal");
    inputVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() {
        bool isPause = RestartMenu.instance.GetIsPause();

        if(isPause){return;}
        
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;
    
    	// 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0)  + Camera.main.transform.right * inputHorizontal * moveSpeed;
        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero) {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
        if(isJump==false){
            if (Input.GetKeyDown(KeyCode.Space)) {
                rb.AddForce(Vector3.up * (jumpPower * 2));
                isJump=true;
    	    }
        }

        if(transform.position.y < 0f){
            transform.position = startPos;
        }else{
            if(isJump){
                rb.AddForce(Vector3.up * (-jumpPower / 10));
            }
        }
        
    }

    private void OnCollisionEnter(Collision other){
        if(isJump == true) {
            if (other.gameObject.tag == "Ground") {
	        	isJump = false;
    	    }
        }
    }

    private void OnTriggerEnter(Collider other) {

    }
}
