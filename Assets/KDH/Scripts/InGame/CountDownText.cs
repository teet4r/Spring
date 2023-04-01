using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownText : MonoBehaviour
{
    Text text;
    RectTransform rectTransform;
    [SerializeField] float scale;

    private void Awake()
    {
        text = GetComponent<Text>();
        rectTransform = GetComponent<RectTransform>();
        rectTransform.localScale = new Vector3(scale, scale, scale);
    }
    public void SetText(string _str)
    {
        text.text = _str;
    }

    private void Start()
    {
        Destroy(this.gameObject, 1f);
        StartCoroutine(PlayText());
    }

    IEnumerator PlayText()
    {
        Color color = text.color;
        float _scale;
        while (true)
        {
            yield return null;
            _scale = scale * Time.deltaTime;
            color.a -= Time.deltaTime;
            text.color = color;
            rectTransform.localScale -= new Vector3(_scale, _scale, _scale);
        }
    }
}