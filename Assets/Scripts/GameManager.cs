using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float firstColonSpeed = 15;
    public static float secondColonSpeed = 15;
    public static float thirdColonSpeed = 15;
    public static float fourthColonSpeed = 15;

    public static string FirstKey = "Alpha1";
    public static string SecondKey = "Alpha2";
    public static string ThirdKey = "Alpha3";
    public static string FourthKey = "Alpha4";


    public static int CorrectTimeLocked = 25;
    public static int IncorrectTimeLocked = 1;




   

  

    private void Start()
    {
        System.IO.StreamWriter streamWriter = new System.IO.StreamWriter("SlotsConfig.txt");
        streamWriter.Write(JsonUtility.ToJson(this));
        streamWriter.Close();
    }
}
