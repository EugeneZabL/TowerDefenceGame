using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SaveProgress : MonoBehaviour
{
    
    private void Start()
    {
        PlayerPrefs.DeleteAll();
        for(int i = 0; i<3; i++)
        {
            PlayerPrefs.SetString("Name" + i, SystemInfo.deviceName);
            PlayerPrefs.SetInt("Score" + i, i);
            PlayerPrefs.Save();

            Debug.Log(PlayerPrefs.GetString("Name" + i));
        }
    }


}
