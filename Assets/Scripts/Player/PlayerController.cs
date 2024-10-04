using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform StartShoot;
    [SerializeField] private GameObject Button;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Image IconHealth;
    [SerializeField] private Sprite[] Health;
    [SerializeField] private Image[] IconLife;
    public TMP_Text ScoreText;
    [SerializeField] private Rigidbody2D Rigidbody;
    public int HealthValue;
    private int LifeValue;
    public int Score;
    private float InputAction;
    [SerializeField] private float Speed;

    void Start()
    {
        Score = 0;
        LifeValue = IconLife.Length;
        Time.timeScale = 1;
    }

    void Update()
    {
        Movement();
        Shoot();
        PlayerUi();
    }

    void Movement()
    {
        InputAction = Input.GetAxis("Horizontal");
        Rigidbody.velocity = new Vector2(InputAction * Speed, 0);
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject CurrentBulet = Instantiate(Bullet, StartShoot.position, Quaternion.identity);
            CurrentBulet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        }
    }

    void PlayerUi()
    {
        IconHealth.sprite = Health[HealthValue];
        if (HealthValue <= 0 && LifeValue != 0)
        {
            HealthValue = 5;
            LifeValue--;
            Destroy(IconLife[LifeValue]);
        }
        else if (HealthValue <= 0 && LifeValue == 0)
        {
            Button.SetActive(true);
            Time.timeScale = 0;
        }
        ScoreText.text = Score.ToString();
    }
}
