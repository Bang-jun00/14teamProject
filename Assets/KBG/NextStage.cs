using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    

    public void Nextstage()
    {
        SceneManager.LoadScene("Stage1");
    }
    
}
