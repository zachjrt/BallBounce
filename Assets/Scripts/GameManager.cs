using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int score;
    public Text scoreText;
    public GameObject gameStartUI;
    

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    
    }

    public void Gamestart()
    {
        gameStartUI.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }


    public void Restart()
    {
        SceneManager.LoadScene("BallBounce");
    }

    public void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
    }
   

}
