using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private GameObject disparoPrefab;
    [SerializeField] private GameObject spawnPoint1;
    [SerializeField] private GameObject spawnPoint2;
    public bool destruido = false; // Variable para indicar si el enemigo ha sido destruido
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnearDisparos());
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * velocidad * Time.deltaTime);
    }
    IEnumerator SpawnearDisparos()
    {
        while (true) 
        {
            Instantiate(disparoPrefab, spawnPoint1.transform.position, Quaternion.identity);
            Instantiate(disparoPrefab, spawnPoint2.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }

    }
    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("DisparoPlayer"))
        {
           
            Destroy(elOtro.gameObject);
            DestruirEnemigo(); // Marca al enemigo como destruido
        }

    }
    public void DestruirEnemigo()
    {
        destruido = true; // Aqu� destrucci�n
        Destroy(this.gameObject);
    }
}
