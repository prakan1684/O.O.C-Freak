using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Missile : MonoBehaviour
{
    public float m_Speed = 10f;   // this is the projectile's speed
    public float m_Lifespan = 3f; // this is the projectile's lifespan (in seconds)
    private Transform enemyRanged;
    private Transform enemyMelee;
    private Vector2 targetRanged;
    private Vector2 targetMelee;
    public HurtPlayer playerHurt;
    public PlayerHealthManager playerHealth;
    private Rigidbody2D m_Rigidbody;

    public int damage = 5; // < -- this doesnt matter bc we change slider.value
    // Start is called before the first frame update
    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
        enemyRanged = GameObject.FindGameObjectWithTag("rangedEnemy").transform;
        enemyMelee = GameObject.FindGameObjectWithTag("meleeEnemy").transform;
        targetRanged = new Vector2(enemyRanged.position.x, enemyRanged.position.y);
        targetMelee = new Vector2(enemyMelee.position.x, enemyMelee.position.y);

    }

    // Update is called once per frame
    void Update()
    {

        if ((transform.position.x == targetRanged.x && transform.position.y == targetRanged.y) || (transform.position.x == targetMelee.x && transform.position.y == targetMelee.y))
        {
           Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
       if (other.CompareTag("meleeEnemy") || other.CompareTag("SolidObjects") || other.CompareTag("rangedEnemy"))
       {
               DestroyProjectile();

       }
      
        


    }
    void DestroyProjectile()
    {
       Destroy(gameObject, m_Lifespan);
    }

}
