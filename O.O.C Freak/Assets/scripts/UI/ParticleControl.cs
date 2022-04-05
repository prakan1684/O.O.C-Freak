using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    public Collider2D energyBallCollider;
    public Collider2D playerCollider;
    public GameObject bloodEffect;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.CompareTag("bullet"))
        {
            Instantiate(bloodEffect, trig.transform.position, Quaternion.identity);
        }

    }

}
