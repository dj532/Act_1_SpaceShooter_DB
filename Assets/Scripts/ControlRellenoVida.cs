using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlRellenoVida : MonoBehaviour
{
    public Image fill; // Asigna la imagen del relleno desde el inspector
    public float maxVida = 100;
    public float vidaActual;

    // Start is called before the first frame update
    void Start()
    {
        vidaActual = maxVida;
        actualizarVida();

    }
    // M�todo para actualizar la barra de vida
    private void actualizarVida()
    {
        if (fill != null)
        {
        fill.fillAmount = vidaActual / maxVida;
        }
    }
    // M�todo para recivir da�o
    public void RecivirDa�o(float da�o)
    {
        vidaActual -= da�o;
        if (vidaActual < 0) vidaActual = 0;
        actualizarVida();
        
        if (vidaActual <= 0)
        {
            // Opcional: maneja la muerte del objeto aqu�
            Debug.Log("Game over");
        }
    }
    // M�todo para curar vida
    public void Curar(float cantidad)
    {
        vidaActual += cantidad;
        if (vidaActual > maxVida) vidaActual = maxVida;
        actualizarVida();

    }
}
