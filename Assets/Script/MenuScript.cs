using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using Cursor = UnityEngine.Cursor;
using System;

public class MenuScript : MonoBehaviour
{
    
    public GameObject menu;
    public GameObject creditos;
    public AudioSource audioSource;
    void Start(){
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0)){
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("Cursor destravado inicianmente");
        }else{
            Debug.Log("Cursor travado inicialmente");
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0)){
                Cursor.lockState = CursorLockMode.None;
            }else{
                if(menu.activeSelf){
                    Debug.Log("Cursor travado");
                    menu.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                }else{
                    Debug.Log("Cursor destravado");
                    menu.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                }
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
    public void creditosF(){
        audioSource.Play();
        if(creditos.activeSelf){
            creditos.SetActive(false);
        }else{
            creditos.SetActive(true);
        }
    }
}

 