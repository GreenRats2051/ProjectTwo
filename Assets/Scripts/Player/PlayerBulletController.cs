using UnityEngine;

public class PlayerBulletController : MonoBehaviour
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
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().Health--;
            Destroy(gameObject);
        }
    }
}
