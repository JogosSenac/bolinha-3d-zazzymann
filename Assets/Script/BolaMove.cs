using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaMove : MonoBehaviour
{
    private float moveH;
    private float moveV;
    private Rigidbody rb;
    [SerializeField] private float velocidade;
    [SerializeField] private float forcaPulo;
    AudioSource pulo;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pulo = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");
        transform.position += new Vector3(moveV* velocidade * Time.deltaTime,0, -1 * moveH* velocidade * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space)){
            pulo.Play();
            rb.AddForce(transform.up * forcaPulo, ForceMode.Impulse);
        }
    }
}
