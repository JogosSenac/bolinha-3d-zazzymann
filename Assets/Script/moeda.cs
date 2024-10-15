using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moeda : MonoBehaviour
{
    [SerializeField]float x,y,z;
    [SerializeField] float velocidade;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(x*velocidade*Time.deltaTime,y*velocidade*Time.deltaTime,z*velocidade*Time.deltaTime);
    }
}
