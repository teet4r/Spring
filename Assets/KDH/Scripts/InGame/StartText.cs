using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartText : MonoBehaviour
{
    RectTransform rectTransform;
    [SerializeField] float moveSpeed;
    [SerializeField] float scale;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.localScale = new Vector3(scale, scale, scale);
        StartCoroutine(MoveLeft1());
    }

    IEnumerator MoveLeft1()
    {
        while (true)
        {
            if (rectTransform.anchoredPosition.x - Time.deltaTime * moveSpeed <= 0)
            {
                rectTransform.anchoredPosition = Vector3.zero;
                StartCoroutine(MoveLeft2());
                yield break;
            }
            rectTransform.Translate(Vector2.left * Time.deltaTime * moveSpeed, Space.World);
            yield return null;
        }
    }

    IEnumerator MoveLeft2()
    {
        yield return new WaitForSeconds(0.66f);
        while (true)
        {
            if (rectTransform.anchoredPosition.x <= -1000f)
            {
                Destroy(this.gameObject);
            }
            rectTransform.Translate(Vector2.left * Time.deltaTime * moveSpeed, Space.World);
            yield return null;
        }
    }
}