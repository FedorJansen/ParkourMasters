using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool fake = false;
    public class Timer
    {
        internal static float Start;
        internal static float End;
        internal static float LevelTime;
        internal static float pauzeTime;
    }
    // Start is called before the first frame update
    void Start()
    {
        Timer.Start = Time.time;


    }

    // Update is called once per frame
    void Update()
    {
        
        //als je het einde hebt aangeraakt
        if (fake)
        {
            if (Timer.LevelTime == 0)
            {
            Timer.End = Time.time;
            Timer.LevelTime = Timer.End - Timer.Start - Timer.pauzeTime;
            Debug.Log(Timer.LevelTime);
            }

        }
    }
}
