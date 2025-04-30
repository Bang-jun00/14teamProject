using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameOvered)
        {
            //ReturnPool;
        }
        if (GameManager.Instance.IsGameCleared)
        {
            //ReturnPool;
        }
    }
}
