using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMScript : MonoBehaviour
{

    bool isWaweEnd = true;
    float level = 1.2f;
    float baseDelay = 3.5f;
    int baseHP = 2;
    float baseSpeed = 10;
    int baseArmyCounter = 2;
    float TechnikalDelay = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isWaweEnd && TechnikalDelay <= 0)
        {
            GetComponentInChildren<King>().InitTheWawe(baseDelay/level, Convert.ToInt32(baseArmyCounter*level),baseSpeed*level,Convert.ToInt32(baseHP*level));
            level = level + 0.2f;
            TechnikalDelay = 10;
            isWaweEnd=false;
        }
        else if (isWaweEnd)  
        {
            TechnikalDelay = TechnikalDelay - Time.deltaTime;

        }
    }

    public void WaweIsEnd()
    {
        isWaweEnd = true;
    }
    public float GetLevel()
    {
        return ((level-1)*10)/2;
    }

    public float GetDelay()
    {
        if (isWaweEnd)
        {
            return (TechnikalDelay)-TechnikalDelay%1;
        }
        return 0.0f;
        
    }
}
