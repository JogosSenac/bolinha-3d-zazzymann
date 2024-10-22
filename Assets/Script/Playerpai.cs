using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Playerpai : MonoBehaviour
{
    public GameObject telaMorte;
    public GameObject player;
    public GameObject playerFab;
    private Vector3 posInicial;
    private GameObject[] moedasT;
    private Vector3[] moedasL;
    public GameObject moedaFeb;
    public CinemachineVirtualCamera camerap;
    
    // Start is called before the first frame update
    void Start()
    {
        buscarPlayerEMoedas();
        
        posInicial = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null){
            //Debug.Log("Player: "+player.name);
            telaMorte.gameObject.SetActive(false);
        }else{
            Cursor.lockState = CursorLockMode.None;
            telaMorte.gameObject.SetActive(true);
            player = GameObject.FindWithTag("Player");
        }
    }
    public void ReSpawn(){
        Debug.LogWarning("Botao ReSpawn Apertado");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void buscarPlayerEMoedas(){
        moedasT = GameObject.FindGameObjectsWithTag("moeda");
        player = GameObject.FindWithTag("Player");
         if(moedasT == null){
            Debug.Log("Não achou as moedas");
        }else{
            Debug.Log("Achou as: ");
            for (int i = 0; i < moedasT.Length; i++){
                 Debug.Log("Achou a moeda: "+moedasT[i].name);
            }
        }
    }
}
