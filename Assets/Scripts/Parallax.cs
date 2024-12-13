using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Vector3 direccion;
    [SerializeField] private float anchoImagen;

    private Vector3 posicionInicial;
    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float espacio = velocidad * Time.time;
        // resto = cuanto me queda de recorrido de la imagen para alacanzar nuevo ciclo
        float resto = espacio % anchoImagen;
        // Lo anterior se resume con la siguiente codigo
        // float resto = (velocidad * Time.time) % anchoImagen;

        //Mi pósicion se va refrescando desde la inicial Sumando tanto como resto 
        // me quede en la direccion deseada
        transform.position = posicionInicial + resto * direccion;

    }
}
