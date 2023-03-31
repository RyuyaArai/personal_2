using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject reStart;
    [SerializeField]
    private GameObject Exit;
    [System.NonSerialized]
    public static RestartMenu instance;

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
        SetActiveButton(false);
    }

    private void Update() {

        bool esc = Input.GetKeyDown(KeyCode.Escape);

        Pause(esc);
    }

    private void ReStartButtonSet(bool esc) {
        if(!reStart.activeSelf) {
            if(esc) {
                BlockerDelete.instance.SetActiveBDUI(false);
                SetActiveButton(true);
            }
        }else{
            if(esc) {
                SetActiveButton(false);
            }
        }
    }

    private void Pause(bool esc) {
        if(!isPause) {
            if(esc) {
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                isPause = true;
            }
        }else{
            if(esc) {
                Time.timeScale = 1;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                isPause = false;
            }
        }
        ReStartButtonSet(esc);
        
    }


    private void SetActiveButton(bool TF) {
        reStart.SetActive(TF);
        Exit.SetActive(TF);
    }

    public bool GetIsPause() { return isPause; }

}
