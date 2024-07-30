using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject Player;
    public GameObject GameOverCanvas;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(!Player)
        {
            GameOverCanvas.SetActive(true);
        }
    }
    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
