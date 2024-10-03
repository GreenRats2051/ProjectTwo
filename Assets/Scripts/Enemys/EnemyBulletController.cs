using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    void Update()
    {
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().HealthValue--;
            Destroy(gameObject);
        }
    }
}
