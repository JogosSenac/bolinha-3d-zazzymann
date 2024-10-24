using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class BolaMove : MonoBehaviour
{
    private float moveH;
    private float moveV;
    private Rigidbody rb;
    [SerializeField] private float velocidade;
    [SerializeField] private float forcaPulo;
    private bool puloAutorizado = true;
    [SerializeField] private int moedas;
    private List<GameObject> moedasTotal;
    private Camera cam;
    private AudioSource pulo;
    public TextMeshProUGUI moedasTexto;

    void Start()
    {
        moedasTotal = GameObject.FindGameObjectsWithTag("moeda").ToList<GameObject>();
        rb = GetComponent<Rigidbody>();
        pulo = GetComponent<AudioSource>();
        moedasTexto = GameObject.FindGameObjectWithTag("TextoMoedas").GetComponent<TextMeshProUGUI>();
        cam = Camera.main;
        AtualizarTextoMoedas();
    }

    void FixedUpdate()
    {
        MoverBola();
        Pular();
    }

    private void MoverBola()
    {
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");
        if(cam != null){
            Vector3 direcao = cam.transform.right * moveH + cam.transform.forward * moveV;
            direcao.y = 0;
            direcao.Normalize();
            rb.velocity = new Vector3(direcao.x * velocidade, rb.velocity.y, direcao.z * velocidade);

        if (direcao.magnitude > 0)
        {
            Quaternion rotacaoAlvo = Quaternion.LookRotation(direcao);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoAlvo, Time.deltaTime * 10);
        }
        }else{
            transform.position += new Vector3(moveV * velocidade * Time.deltaTime, 0, -moveH * velocidade * Time.deltaTime);
        }
    }

    private void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Space) && puloAutorizado)
        {
            pulo.Play();
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            puloAutorizado = false; // Desativa o pulo
        }

        AtualizarTextoMoedas();
    }

    private void AtualizarTextoMoedas()
    {
        moedasTexto.text = $"{moedas}/{moedasTotal.Count}";
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("chao"))
        {
            puloAutorizado = true; // Ativa o pulo ao colidir com o chão
        } else{
            puloAutorizado = false;
        }
        if (other.gameObject.CompareTag("agua"))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("moeda"))
        {
            moedas++;
            Destroy(other.gameObject);
            AtualizarTextoMoedas();
        }

        VerificarTrocaDeCena(other);
    }

    private void VerificarTrocaDeCena(Collider other)
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            if (other.gameObject.CompareTag("Void") && moedas >= moedasTotal.Count)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        
    }

    // Verifica se a bola está no chão
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("chao"))
        {
            puloAutorizado = true; // Permite pular enquanto está em contato com o chão
        }
    }
}
