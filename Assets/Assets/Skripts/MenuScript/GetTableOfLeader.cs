using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GetTableOfLeader : MonoBehaviour
{
    public List<TMP_Text> TOP5;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeleteStats()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Delete");
        PlayerPrefs.Save();
    }

    public void TableLeader()
    {
        for (int i = 0; i < 5; i++)
        {
                TOP5[i].text = "";
        }
        for (int i = 0; i<5;i++)
        {
            if (PlayerPrefs.GetInt("Score" + i) != 0)
            {
                TOP5[i].text = PlayerPrefs.GetString("Name" + i) + " " +PlayerPrefs.GetInt("Score" + i);
            }
        }
    }
}
