using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Mouse : MonoBehaviour
{
    Vector3 mousePosition_real;
    public Camera camera_1;
    public Rigidbody2D rigid;
    public Player_move player_movement;
    Vector2 mouse_movement;

    // Start is called before the first frame update

  
    void Start()
    {
        
        rigid = this.GetComponent<Rigidbody2D>();
        // rigid.rotation = 90f; // doesnt work
      //  transform.rotation = Quaternion.Euler(90, 90, 90);

        // camera_1 = Camera.main;
        // mousePosition_real = camera_1.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - camera_1.transform.position.z));


    }

    // Update is called once per frame
    void Update()
    {
        // mouse_movement = camera_1.ScreenToWorldPoint(Input.mousePosition);
       // rotateToCamera();
        var mouse = Input.mousePosition;
        var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        var angle = Mathf.Atan2(offset.x, -offset.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    //void rotateToCamera()
    //{
    //    mousePosition_real = camera_1.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - camera_1.transform.position.z));
    //    rigid.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((mousePosition_real.y - transform.position.y), (mousePosition_real.x - transform.position.x)) * Mathf.Rad2Deg);

    //}
    // below is possible fix to character not rotating correctly when an enemy exists(game object enemy) ** EDIT NOT POSSIBLE FIX NOTHING WAS WRONG WITH THIS SCRIPT
    //private void FixedUpdate()
    //{
    //    Vector2 look_direction = mouse_movement - rigid.position;
    //    float angle_player = Mathf.Atan2(look_direction.y, look_direction.x) *Mathf.Rad2Deg;
    //    rigid.rotation = angle_player;
    //}


}

