using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform StartPosition;
    [SerializeField] private GameObject Bullet;
    private GameObject Player;
    public int Health;
    [SerializeField] private int Score;
    private float TimeCheck;
    [SerializeField] private float TimeNextCheck;
    private float TimeShoot;
    [SerializeField] private float TimeNextShoot;
    [SerializeField] private float TimeNextShootMax;
    [SerializeField] private float TimeNextShootMin;

    void Start()
    {
        TimeShoot += Time.time + UnityEngine.Random.Range(TimeNextShootMin, TimeNextShootMax);
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Movement();
        Shoot();
        EnemyUi();
    }

    void Movement()
    {
        if (Time.time >= TimeCheck)
        {
            TimeCheck = Time.time + TimeNextCheck;
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
        }
    }

    void Shoot()
    {
        RaycastHit2D Hit = Physics2D.Raycast(StartPosition.position, Vector3.down, 1f);
        if (Hit.collider == null)
        {
            if (Time.time >= TimeShoot)
            {
                TimeShoot += Time.time + UnityEngine.Random.Range(TimeNextShootMin, TimeNextShootMax);
                GameObject CurrentBulet = Instantiate(Bullet, StartPosition.position, Quaternion.identity);
                CurrentBulet.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 5, ForceMode2D.Impulse);
            }
        }
        Debug.DrawRay(StartPosition.position, Vector3.down);
    }

    void EnemyUi()
    {
        if (Health <= 0)
        {
            Player.GetComponent<PlayerController>().Score += Score;
            Destroy(gameObject);
        }
    }
}
