using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageChange : MonoBehaviour
{
    public void Nextstage()
    {
        SceneManager.LoadScene("Stage1");
    }
}
