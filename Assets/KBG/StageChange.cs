using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageChange : MonoBehaviour
{
    //public void Nextstage()
    //{
    //    SceneManager.LoadScene("Stage2test");
    //}
    //
    //{
    public int currentStage = 1;

    public void Nextstage()
    {
        currentStage++;

        if (currentStage == 2)
        {
            Debug.Log("2스테이지 시작");
            SceneManager.LoadScene("Stage2test");
        }
        if (currentStage == 3)
        {
            Debug.Log("3스테이지 시작");
            SceneManager.LoadScene("Stage3test");
        }
        if (currentStage > 3)
        {
            currentStage = 1;
            Debug.Log("1스테이지 시작");
            SceneManager.LoadScene("Stage1test");
        }

    }
    
}

