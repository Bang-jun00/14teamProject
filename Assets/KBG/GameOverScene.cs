using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    public int hp = 100;

    void Update()
    {
        if (hp <= 0)
        {
            GoToGameOver();
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
    }

    void GoToGameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
