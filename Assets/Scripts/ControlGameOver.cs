using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ControlGameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    private AudioSource musicControl;
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        //obtener musicControl de MusicManager
        musicControl = GameObject.Find("MusicManager").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; // Pausa el juego
        if (musicControl != null)
        {
            musicControl.Pause(); // Pausar la música
        }
    }
    public void Reinicio()
    {
        Time.timeScale = 1f; // Reinicia el tiempo del juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia la escena actual
        if (musicControl != null)
        {
            musicControl.Play();// Reproduce musica de nuevo
        }
    }
}
