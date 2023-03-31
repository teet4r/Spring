using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteController : MonoBehaviour
{
    public float SpriteHalfHeight
    {
        get => _spriteHalfHeight;
    }

    public float SpriteHalfWidth
    {
        get => _spriteHalfWidth;
    }

    [SerializeField] Transform _transform = default;

    [SerializeField] SpriteRenderer _spriteRenderer = default;

    float _spriteHalfHeight;

    float _spriteHalfWidth;



    void Awake()
    {
        _spriteHalfHeight = _spriteRenderer.sprite.bounds.size.y / 2 * _transform.localScale.y;
        _spriteHalfWidth = _spriteRenderer.sprite.bounds.size.x / 2 * _transform.localScale.x;
    }

    public void FlipX(bool flip)
    {
        _spriteRenderer.flipX = flip;
    }
}
