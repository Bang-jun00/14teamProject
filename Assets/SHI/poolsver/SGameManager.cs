using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGameManager : MonoBehaviour
{
    public static SGameManager instance;
    //public Player player;
    public PoolManager pool;
    public GameObject player;
    [SerializeField] public float Gametime =5f;
    [SerializeField] public float Maxgametime =20f;

   // public int level;
    //public int kill;
    //public int exp;
    //public int[] nextexp = { 10, 30, 60, 100, 150, 210, 280, 360, 450, 600 };

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        Gametime += Time.deltaTime;
       

        if( Gametime > Maxgametime )
        {
            Gametime = Maxgametime;
        }
    }


}
