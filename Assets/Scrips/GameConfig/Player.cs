using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoSingleton<Player>
{    
    public int Score =0;
    public int Target;
    public float Strenght = 1f;
    public int Bomb = 3;    
    public float Time = 60.5f;
    public int MoveSpeed = 1;
    public bool RockCollection = false;
    public bool DiamondCollection = false;    
    public bool Weed = false;

    public int Level = 0;

    public bool isMoveable =true;

    public void ResetPlayerStats()
    {        
        Strenght = 1;
        MoveSpeed = 1;
        RockCollection = false;
        DiamondCollection = false;
        Weed = false;
        Time = 60.5f;
    }

    public void PlayAgain()
    {
        Target = 0;
        Score = 0;
        Level = 0;
        Bomb = 3;

        Strenght = 1;
        MoveSpeed = 1;
        RockCollection = false;
        DiamondCollection = false;
        Weed = false;
        Time = 60.5f;
    }    
}
