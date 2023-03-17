using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField]
    private Transform charaTransform;

    void Start() {

    }

    void FixedUpdate()
    {
        bool isPause = RestartMenu.instance.GetIsPause();

        if(isPause) { return; }
        transform.position = charaTransform.position;        
    }
}
