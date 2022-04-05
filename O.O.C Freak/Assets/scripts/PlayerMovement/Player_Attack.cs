using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
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
        p_animator.SetTrigger("Attack");
    }
}

