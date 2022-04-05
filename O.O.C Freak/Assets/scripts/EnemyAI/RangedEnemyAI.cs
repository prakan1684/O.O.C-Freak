using UnityEngine;

public class RangedEnemyAI : MonoBehaviour
{
    
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    public float attackRange; // added

    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;
    

    public Transform player;
    private Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        
    }

    // Update is called once per frame
    void Update()
    {

        
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rigid.rotation = angle + 90;
        direction.Normalize();

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {

            moveCharacter(direction, speed);


        } else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        } else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            moveCharacter(direction, -(speed / 2));
        }


        if(timeBtwShots <= 0 && Vector2.Distance(transform.position, player.position) < attackRange)
        {
            //Debug.Log("attacking with ball");
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        } else
        {
            timeBtwShots -= Time.deltaTime;
        }



    }
    void moveCharacter(Vector2 direction, float speed)
    {
        rigid.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));

    }
    
}
