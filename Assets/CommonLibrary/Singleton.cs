using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance
    {
        get
        {
            if (_instance == null && Time.timeScale != 0f)
            {
                // ���̾��Ű�� ���� ��� ����
                var newObj = new GameObject();
                _instance = newObj.AddComponent<T>();
            }
            return _instance;
        }
    }

    static T _instance = null;



    protected virtual void Awake()
    {
        // ���̾��Ű�� �̹� ������� ��� ����
        if (_instance == null)
        {
            _instance = this as T;
            name = typeof(T).ToString();
            DontDestroyOnLoad(_instance);
        }
        else
            Destroy(gameObject);
    }

    protected virtual void OnApplicationQuit()
    {
        Time.timeScale = 0f;
    }
}