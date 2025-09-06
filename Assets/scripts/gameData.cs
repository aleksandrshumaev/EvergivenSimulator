using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class gameData
{
   public float meters;
    public int Year;
    public int Month;
    public int Day;
    public int Hour;
    public int Minutes;
    public int Seconds;
    public int state;
    public gameData(gameLogic states)
    {
        meters=states.meters;
        Year=states.Year;
        Month=states.Month;
        Day=states.Day;
        Hour=states.Hour;
        Minutes=states.Minutes;
        Seconds=states.Seconds;
        state=states.state;
    }
}
