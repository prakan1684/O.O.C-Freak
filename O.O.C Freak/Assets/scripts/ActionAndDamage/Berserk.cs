using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Berserk : MonoBehaviour
{

    public Transform berserkPos;
    public float berserkRange;
    public int berserkBar = 0;
    int berserkLimit = 5;
    Rigidbody2D playerbody;
    private GameObject weapon;
    private WeaponDamageEnemy hammerHitEnemy;

    public Slider playerhpbar; // added

    public bool invincible = false; // added

    public SpriteRenderer playerSprite;




    public LayerMask allEnemies;
    
   

    // Start is called before the first frame update
    void Start()
    {
        
        playerbody = this.GetComponent<Rigidbody2D>();

         weapon = GameObject.Find("SledgehammerV1");
        
         hammerHitEnemy = weapon.GetComponent<WeaponDamageEnemy>();
        playerSprite = GetComponent<SpriteRenderer>();
       // float originalHp = playerhpbar.value;
        
    }

    // Update is called once per frame
    void Update()
    {
        berserkMode();
        

    }
    
     void berserkMode()
    {
        //GameObject weapon = GameObject.Find("SledgehammerV1");

        // WeaponDamageEnemy hammerHitEnemy = weapon.GetComponent<WeaponDamageEnemy>();
        //float originalHp = playerhpbar.value;
        if (hammerHitEnemy.hurtEnemy == true)
        {
            ++berserkBar;
            Debug.Log("rage increase by 1");
            hammerHitEnemy.hurtEnemy = false;
            
        }

        if (berserkBar >= berserkLimit && Input.GetKey(KeyCode.B)) // berserkLimit is 5 right now
        {
            invincible = true;
            berserkBar = 0;
            Debug.Log("Nothing personal kid.");
            Collider2D[] killEnemies = Physics2D.OverlapCircleAll(berserkPos.position, berserkRange, allEnemies);

          
            StartCoroutine(killingAllEnemies(killEnemies));
            //for (int i = 0; i < killEnemies.Length; ++i)
            //{
            //    Debug.Log("you killed them you monster.");

            //    killEnemies[i].GetComponent<SpriteRenderer>().color = Color.blue;  // can be used for debugging or make enemy gray when they die cause game logic lololol
            //    killEnemies[i].GetComponent<EnemyHealthManager>().TakeDamage(100); // can change 100 to whatever value
            //}

        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(berserkPos.position, berserkRange);
    }

    private IEnumerator killingAllEnemies(Collider2D[] killEnemies)  // process for killing them
    {
        Debug.Log("invincible status is " + invincible);
        playerSprite.color = Color.black;
        float originalHp2 = playerhpbar.value;
        Debug.Log("the length is" + killEnemies.Length);
        Debug.Log("player cant move"); 

        Player_move moving_script = playerbody.GetComponent<Player_move>();
        moving_script.canMove = false;

        Vector2 originalPosition = playerbody.position;

        //foreach(Collider2D enemy in killEnemies)
        //{
        //    Debug.Log("killing");
        //   // playerbody.position = (Vector2)enemy.transform.position; /// for each enemy i teleport to their position
        //    yield return new WaitForSeconds(.2f);
        //}


        Debug.Log("killing all, invincible");
        playerhpbar.value = originalHp2;


        yield return new WaitForSeconds(1.5f);  // change time constraint so that I teleport and then kill all of them?????

        for(int i = 0; i < killEnemies.Length; ++i)
        {
            Debug.Log("you killed them you monster");
            if (killEnemies[i].GetComponent<EnemyHealthManager>() != null)
            {
                killEnemies[i].GetComponent<EnemyHealthManager>().TakeDamage(100);
            }

            else
            {
                moving_script.canMove = true;
            }
             // instant killing all enemies

            
        }

        // RESET EVERYTHING BACK TO NORMAL
        Debug.Log("player can move now and is vulnerable");
        moving_script.canMove = true;

        invincible = false;
        Debug.Log("invincible status is" + invincible);
        playerbody.position = originalPosition;
        playerSprite.color = Color.white;
        
     
    }

}

