using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance = null;

    public static MusicManager Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        if (instance != null && instance != this) 
        { 
            Destroy(this.gameObject); 
            return;
        } else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject); // Hace que el objeto persista entre escenas 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
