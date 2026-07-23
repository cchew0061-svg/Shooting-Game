using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCounterScript : MonoBehaviour
{
    public int killCounter = 0;
    public TextMeshProUGUI killCounterDisplay;

    //shows text on screen to represent the number of kills
    void Update()
    {
      if(killCounterDisplay!= null)
      {
        killCounterDisplay.text = $"Kill Count: {killCounter}";
      }
    }
}
