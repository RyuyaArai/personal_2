using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [System.NonSerialized]
    public static GameManager instance;

    public int keyCount;
    public int maxKeyCount;
    public Text textComponent;
    public Text maxKey;
    public GameObject inductionText;

    private void Awake() {
        if(instance == null){
            instance = this;
        }    
    }

    private void Start(){
        Screen.SetResolution(1920,1080,false);
        Application.targetFrameRate=60;
        keyCount=0;
        string activeSceneName = SceneManager.GetActiveScene().name;
        if(activeSceneName=="GameTwo"){
            Cursor.visible = false;
            Cursor.lockState=CursorLockMode.Locked;
        }else{
            Cursor.visible = true;
            Cursor.lockState=CursorLockMode.None;
        }
        
    }

    private void Update(){
        if(keyCount >= maxKeyCount){
            if(inductionText.activeSelf==false){
                inductionText.SetActive(true);
            }
        }


    }

    public void AddKeyCount(){
        keyCount++;
        if(keyCount > maxKeyCount){
            keyCount = maxKeyCount;
        }
        textComponent.text = "KeyCount : "+ keyCount;
    }

    public void GameEnd(){
        Application.Quit();
    }

    public void AddMaxKeyCount(){
        maxKeyCount++;
        maxKey.text = " / "+ maxKeyCount;
    }
    
    public void SceneReset(){
        string activeSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeSceneName);
    }

    public void ChangeScene(string nextScene){
        SceneManager.LoadScene(nextScene);
    }
}
