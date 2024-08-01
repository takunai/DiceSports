using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int diceResult = 1; // デフォルトのダイスの目

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}