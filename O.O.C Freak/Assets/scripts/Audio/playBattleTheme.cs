using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playBattleTheme : MonoBehaviour
{
    public AudioSource audioSource;

    public float delay = .5f;

    
    // Start is called before the first frame update
    void Start()
    {
         audioSource.loop = true;
        
    }

    // Update is called once per frame
    //void Update()
    //{

    //}



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !audioSource.isPlaying)
        {
            Debug.Log("music plays");
            audioSource.Play();
            
        }
    }
    
}
