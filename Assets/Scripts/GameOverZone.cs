using UnityEngine;

public class GameOverZone : MonoBehaviour
{
    [SerializeField] private GameObject Button;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Button.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
