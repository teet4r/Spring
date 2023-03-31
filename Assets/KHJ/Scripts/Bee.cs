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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            Deactivate();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
