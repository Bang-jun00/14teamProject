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
            Debug.Log("2�������� ����");
            SceneManager.LoadScene("Stage2test");
        }
        if (currentStage == 3)
        {
            Debug.Log("3�������� ����");
            SceneManager.LoadScene("Stage3test");
        }
        if (currentStage > 3)
        {
            currentStage = 1;
            Debug.Log("1�������� ����");
            SceneManager.LoadScene("Stage1test");
        }

    }
    
}

