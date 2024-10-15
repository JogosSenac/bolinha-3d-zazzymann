using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BolaMove : MonoBehaviour
{
    private float moveH;
    private float moveV;
    private Rigidbody rb;
    [SerializeField] private float velocidade;
    [SerializeField] private float forcaPulo;
    private bool puloAutorized = true;
    int moedas;
    AudioSource pulo;
    public string moedasT;
    public TextMeshProUGUI moedastexto;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pulo = GetComponent<AudioSource>();
        moedasT = GameObject.FindGameObjectsWithTag("moeda").Length.ToString();
        moedastexto = GameObject.FindGameObjectWithTag("TextoMoedas").GetComponent<TextMeshProUGUI>();
    }

        void Update()
    {
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");

        // Movimento da bola
        transform.position += new Vector3(moveV * velocidade * Time.deltaTime, 0, -moveH * velocidade * Time.deltaTime);

        // Rotacionar a bola
        if (moveH != 0 || moveV != 0)
        {
            Vector3 direction = new Vector3(moveV, 0, -moveH).normalized;
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 360 * Time.deltaTime);
        }

        // Pulo
        if (Input.GetKeyDown(KeyCode.Space) && puloAutorized)
        {
            pulo.Play();
            rb.AddForce(transform.up * forcaPulo, ForceMode.Impulse);
            puloAutorized = false;
        }
        moedastexto.text = $"{moedas}/{moedasT}";
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("chao"))
        {
            puloAutorized = true;
        }else if(other.gameObject.CompareTag("agua")){
            Destroy(this.gameObject);
        }else if (other.gameObject.CompareTag("Void")){
            if (moedas <= 2)
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("moeda"))
        {
            moedas++;
            Destroy(other.gameObject); 
        }
    }
}
