using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class MenuScript : MonoBehaviour
{
    public void quit(){
        Application.Quit();
    }
    public void proximaCena(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
