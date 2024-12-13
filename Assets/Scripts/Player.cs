using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float radioDisparo;
    [SerializeField] private GameObject disparoPrefab;
    [SerializeField] private GameObject spawnPoint1;
    [SerializeField] private GameObject spawnPoint2;
    [SerializeField] private TextMeshProUGUI scoreText; // Referencia al texto que muestra el puntaje
    private int score = 0; // Variable para almacenar el puntaje
    private float temporizador = 0.5f;
    [SerializeField] private ControlRellenoVida controlVida;
    [SerializeField] ControlGameOver controlGameOver;

    // Start is called before the first frame update
    void Start()
    {
        controlVida = GetComponent<ControlRellenoVida>();
        if (controlVida != null ) 
        {
            controlVida.Curar(controlVida.maxVida); // Inicializa con vida completa
        }
        
        ActualizarScoreText(); // Actualiza el texto del puntaje al inicio
    }

    // Update is called once per frame
    void Update()
    {
        // se saca y se ingresa en un metodo "Movimiento"
        //float inputH = Input.GetAxisRaw("Horizontal");
        //float inputV = Input.GetAxisRaw("Vertical");
        //transform.Translate(new Vector2(inputH, inputV).normalized * velocidad * Time.deltaTime);

        //El codigo a continuacion se ingresa en un metodo "DelimitarMovimiento"
        // Mathf.Clamp limita posicion para evitar salir de zona de juego.
        //float xClamped = Mathf.Clamp(transform.position.x, -8.3f, 8.3f);
        // float yClamped = Mathf.Clamp(transform.position.y, -4.3f, 4.3f);
        // transform.position = new Vector3(xClamped, yClamped, 0);

        Movimiento();
        DelimitarMovimiento();
        Disparar();

    }
    void Movimiento()
    {
        float inputH = Input.GetAxisRaw("Horizontal");
        float inputV = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector2(inputH, inputV).normalized * velocidad * Time.deltaTime);

    }
    void DelimitarMovimiento()
    {
        // Mathf.Clamp limita posicion para evitar salir de zona de juego.
        float xClamped = Mathf.Clamp(transform.position.x, -8.3f, 8.3f);
        float yClamped = Mathf.Clamp(transform.position.y, -4.3f, 4.3f);
        transform.position = new Vector3(xClamped, yClamped, 0);

    }
    void Disparar()
    {
        temporizador += 1 * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && temporizador > radioDisparo)
        {
            Instantiate(disparoPrefab, spawnPoint1.transform.position, Quaternion.identity);
            Instantiate(disparoPrefab, spawnPoint2.transform.position, Quaternion.identity);
            temporizador = 0;
        }


    }
    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("DisparoEnemigo") || elOtro.gameObject.CompareTag("Enemigo"))
        {
            controlVida.RecivirDaño(10); // Reduce la vida
            Destroy(elOtro.gameObject);

            if (controlVida != null && controlVida.vidaActual <= 0)
            {
                // Llamar a la función GameOver
                controlGameOver.GameOver();
                // Opcional: efectos de muerte del jugador
                Destroy(this.gameObject);
            }
        }
        else if (elOtro.gameObject.CompareTag("Enemigo"))
        {
            Enemigo enemigo = elOtro.GetComponent<Enemigo>();
            if (enemigo != null)
            {

                if (enemigo.destruido)
                {

                    IncrementarScore(); // Incrementa el puntaje cuando se destruye un enemigo
                    Destroy(elOtro.gameObject);

                }
            } 
        }
    }
    private void IncrementarScore()
    {
        score += 10;
        ActualizarScoreText();
    }
    private void ActualizarScoreText()
    {
        if(scoreText != null)
        {
            scoreText.text = "score: " + score;
        }

    }
}
