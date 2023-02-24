using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject reStart;
    [System.NonSerialized]
    public static RestartMenu instance;

    public GameObject confirmationPanel;


    private bool isPause;

    void Awake() {
        if(instance == null){
            instance = this;
        }
    }

    void Start() {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isPause = false;
        confirmationPanel.SetActive(false);
    }

    void Update() {
        Pause();
        
    }

    private void CreateButton() {
        //GameObject button = GameObject.CreatePrimitive();
    }

    private void ReStartButtonSet() {
        if(!reStart.activeSelf) {
            if(Input.GetKeyDown(KeyCode.Escape)) {
            reStart.SetActive(true);
            confirmationPanel.SetActive(true);
            }
        }else {
            if(Input.GetKeyDown(KeyCode.Escape)) {
            reStart.SetActive(false);
            confirmationPanel.SetActive(false);
            }
        }
    }

    private void Pause() {
        if(!isPause){
            if(Input.GetKeyDown(KeyCode.Escape)) {
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                isPause = true;
            }
        }else {
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
