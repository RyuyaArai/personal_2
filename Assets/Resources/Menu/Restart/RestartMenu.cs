using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject reStart;
    [System.NonSerialized]
    public static RestartMenu instance;

    public GameObject Exit;


    private bool isPause;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
    }

    private void Start() {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isPause = false;
        Exit.SetActive(false);
    }

    private void Update() {
        Pause();
    }

    private void ReStartButtonSet() {
        if(!reStart.activeSelf) {
            if(Input.GetKeyDown(KeyCode.Escape)) {
            reStart.SetActive(true);
            Exit.SetActive(true);
            }
        }else{
            if(Input.GetKeyDown(KeyCode.Escape)) {
            reStart.SetActive(false);
            Exit.SetActive(false);
            }
        }
    }

    private void Pause() {
        if(!isPause) {
            if(Input.GetKeyDown(KeyCode.Escape)) {
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                isPause = true;
            }
        }else{
            if(Input.GetKeyDown(KeyCode.Escape)) {
                Time.timeScale = 1;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                isPause = false;
            }
        }
        ReStartButtonSet();
        
    }


    public bool GetIsPause() { return isPause; }

}
