using UnityEngine;

public class Bee : MonoBehaviour, IDamageable
{
    [SerializeField] MovementController _movementController;

    

    void OnTriggerEnter2D(Collider2D collision)
    {
        var item = collision.GetComponent<IUsable>();

        item?.Use(this);

        Destroy(collision.gameObject);
    }

    public void GetDamage(int damage)
    {
        HeartManager.instance.GetDamaged();
    }
}
