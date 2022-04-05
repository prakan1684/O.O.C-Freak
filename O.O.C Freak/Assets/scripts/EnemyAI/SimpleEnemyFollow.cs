using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyFollow : MonoBehaviour
{
    public float speed;
    public float attackDistance;
    public float bufferDistance;
    public Transform player;

    Transform playerTransform;
    public Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }



    private void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rigid.rotation = angle;
        direction.Normalize();

        if (Vector2.Distance(transform.position, player.position) < bufferDistance)
        {

            moveCharacter(direction, speed);


        }
    }
    void moveCharacter(Vector2 direction, float speed)
    {
        rigid.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));

    }


}
