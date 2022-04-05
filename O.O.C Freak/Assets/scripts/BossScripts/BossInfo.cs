using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossInfo : MonoBehaviour
{
    public int BossHp;
    private bool stage1;
    private bool stage2;
    public Slider BossHealthBar;
    public SpriteRenderer sprite;
    public GameObject projectile;
    public Transform firingPoint;

    

    //private bool forwards = false;
    //private Vector2 startPosition;

    public float shootingCooldown = 0;

    private bool dirRight = true;
    public float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        BossHealthBar.value = BossHp;
        
        sprite = GetComponent<SpriteRenderer>();
        stage1 = true;
        stage2 = false;
    }

    // Update is called once per frame
    void Update()
    {
      //  Move();

        CheckHP();
        if(stage1 == true)
        {
            BossShoot();

            if (dirRight)
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            else
                transform.Translate(-Vector2.right * speed * Time.deltaTime);

            if (transform.position.x >= 4.0f)
            {
                dirRight = false;
            }

            if (transform.position.x <= -4)
            {
                dirRight = true;
            }
        }



       
    }

    void CheckHP()
    {
        if(BossHp >= 400)
        {
            stage1 = true;
        }

        //else if (BossHp < 500)
        //{
        //    stage2 = true;
        //    stage1 = false;
        //}

        else if(BossHp <= 0)
        {
            Destroy(gameObject); // destroy itself
        }
    }

    

    void BossShoot()
    {
        shootingCooldown -= Time.deltaTime;
        if (shootingCooldown <= 0 )
        {
           // Debug.Log("it's spawning");
            Instantiate(projectile, firingPoint.position, Quaternion.identity); // spawns at the boss
            shootingCooldown = 1f;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player_weapon")
        {
            StartCoroutine(FlashRed());
            BossHp -= 10;
            BossHealthBar.value -= 10;

        }
        
    }

    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }

    
}
