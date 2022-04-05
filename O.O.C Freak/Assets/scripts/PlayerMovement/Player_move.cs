using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    public bool player_moving = false;
    public float speed_p;
    private Vector3 movement;
    public bool canMove = true;
    public Animator animator;



    public Rigidbody2D myRigidbody;
    // NEED TO CHANGE TO RIGIDBODY VELOCITY 
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        //movement_p();
        
    }
    private void FixedUpdate()
    {
       movement_p();
    }

    void ProcessInput()
    {
       movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0);
        if(movement.magnitude > 1)
        {
            movement.Normalize();
        }

        animator.SetFloat("Speed", movement.magnitude);
    }
    void movement_p()
    {
        if (canMove == true)
        {

            myRigidbody.velocity = new Vector2(movement.x * speed_p, movement.y * speed_p);

        }

        else
        {
            myRigidbody.velocity = Vector2.zero;
        }
        //transform.position += new vector3(input.getaxisraw("horizontal"), input.getaxisraw("vertical")) * speed_p * time.deltatime;
        //if (input.getkey(keycode.w)) 
        //{
        //    transform.translate(vector3.up * speed_p * time.deltatime, space.world);

        //}
        //if (input.getkey(keycode.s)) 
        //{
        //    transform.translate(vector3.down * speed_p * time.deltatime, space.world);

        //}
        //if (input.getkey(keycode.a)) 
        //{
        //    transform.translate(vector3.left * speed_p * time.deltatime, space.world);

        //}
        //if (input.getkey(keycode.d))
        //{
        //    transform.translate(vector3.right * speed_p * time.deltatime, space.world);

        //}
        //if(input.getkey (keycode.d) != true && input.getkey(keycode.a)!= true && input.getkey(keycode.s) != true && input.getkey(keycode.w) != true)
        //{
        //    player_moving = false;
        //}
        
    }

    // void OnCollisionEnter2D(Collision2D collision_other)
    //{
    //    if(collision_other.gameObject.tag == "testEnemy" || collision_other.gameObject.name == "Solid_Objects")
    //    {
    //        Debug.Log("dont move");
            
    //        myRigidbody.velocity = Vector2.zero;
    //        myRigidbody.angularVelocity = 0f;

    //    }
    //}
}
