using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ShowMassage : MonoBehaviour
{
    string Message;

    GameObject dm;
    GameObject player;

    float delay;
    // Start is called before the first frame update
    void Start()
    {
        delay = 3;
        dm = GameObject.FindGameObjectWithTag("DM");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ShowWaweNumber();
        ShowMoney();

        if (delay >= 0)
        {
           transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text=Message;
            delay = delay - Time.deltaTime;
        }
        else
            GetComponentInChildren<TMP_Text>().text = "";
    }

    public void ShowMessage(string t)
    {
        Message = t;
        delay = 3;
    }

    public void ShowWaweNumber()
    {
        transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = "Level " +Convert.ToInt32(dm.GetComponent<DMScript>().GetLevel() - 1);
    }

    public void ShowMoney()
    {
        transform.GetChild(2).gameObject.GetComponent<TMP_Text>().text = "Money " + player.GetComponent<PlayerStates>().money;
    }
}
