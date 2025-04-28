using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover : MonoBehaviour
{
    bool isCleared = false;
    bool gameOver = false;
    int hp;
    int killCount;
    int playTime;
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
    void Clear()
    {

    }
    void fail()
    {

    }
}
