using UnityEngine;

public class Bee : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        var item = collision.GetComponent<IUsable>();

        item?.Use(this);

        Destroy(collision.gameObject);
    }
}
