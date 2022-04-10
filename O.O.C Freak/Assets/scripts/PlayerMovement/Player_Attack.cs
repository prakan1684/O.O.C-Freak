using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public float speed;

    [SerializeField] private GameObject Missile;
    [SerializeField] private Transform rocketLauncherEndPoint;


    public Animator p_animator;
    // Start is called before the first frame update
    void Start()
    {
        p_animator = GetComponent<Animator>();
    
 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        
    }

    void Attack()
    {
        Vector3 shootDirection;
        shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection-transform.position;
        //...instantiating the rocket
        Rigidbody2D bulletInstance = Instantiate(Missile.GetComponent<Rigidbody2D>(), transform.position, rocketLauncherEndPoint.rotation);
        bulletInstance.velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);



    }
}

