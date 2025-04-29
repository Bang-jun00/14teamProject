using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Gameover : MonoBehaviour
{
    public void PlayerDiedScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    


    private bool isCleared = false;
    private bool gameOver = false;
    private int hp;
    private int killCount;
    private int playTime;
    void Update()
    {
        if (gameOver == true && isCleared == false)
        {
            //depeat
        }
        else if (gameOver == true && isCleared == true)
        {
            //victory
        }
        else
        {
            if (killCount == 100)
            {
                gameOver = true;
                isCleared = true;
            }
            if (playTime == 0)
            {
                gameOver = true;
                isCleared = true;
            }
            if (hp <= 0)
            {
                gameOver = true;
            }
        }

    }
    public void GameOver()
    {

    }
    

}
