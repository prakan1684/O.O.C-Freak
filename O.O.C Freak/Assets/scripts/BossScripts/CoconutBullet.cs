using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoconutBullet : MonoBehaviour
{
    
    public Slider playerSlider;

    public Vector2 velocity;
    public float speed;
    public float rotation;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("it's moving");
        transform.Translate(velocity * speed * Time.deltaTime);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
           if(other.CompareTag("Player"))
        {
           // Debug.Log("should hit");
        }
    }
}
