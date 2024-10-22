using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class MenuScript : MonoBehaviour
{
    public GameObject menu;
    public AudioSource audioSource;
    void Update(){
        if (Application.isPlaying&& Input.GetKeyDown(KeyCode.Escape)){
            if(menu.activeSelf){
                menu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                
            }else{
                menu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }

    }
    public void quit(){
        audioSource.Play();
        Application.Quit();
    }
    public void proximaCena(){
        audioSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}

 