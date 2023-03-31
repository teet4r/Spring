using UnityEngine;

public class Bee : MonoBehaviour
{
    public static Bee Instance = null;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
