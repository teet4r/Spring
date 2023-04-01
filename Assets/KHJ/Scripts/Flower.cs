using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;

    [SerializeField] int _score;



    void OnEnable()
    {
        _rigidbody.position = MainCamera.Instance.GetRandomPositionInCamera();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bee bee))
        {
            Debug.Log("µµ·Î·Õ Á¡¼ö È¹µæ!!");
            //ScoreManager.instance.AddScore(_score);

            Destroy(gameObject);
        }
    }
}
