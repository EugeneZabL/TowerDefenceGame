using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Main_hp : MonoBehaviour
{
    private int hp = 20;
    private int Score = 0;
    [SerializeField] GameObject DefeatMenu;
    [SerializeField] GameObject HPBase;
    [SerializeField] GameObject UIDelay;
    GameObject DM;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("Music")==0)
            GameObject.FindGameObjectWithTag("MassOfTurr").GetComponent<AudioSource>().Stop();
        else
            GameObject.FindGameObjectWithTag("MassOfTurr").GetComponent<AudioSource>().Play();
        DM = GameObject.FindGameObjectWithTag("DM");
    }

    // Update is called once per frame
    void Update()
    {
        HPBase.GetComponentInChildren<TMP_Text>().text = hp + "";

        if (hp <= 0)
        {
            Cursor.lockState = CursorLockMode.Confined;
            DefeatMenu.gameObject.SetActive(true);
            DefeatMenu.transform.GetChild(1).transform.GetChild(0).GetComponent<TMP_Text>().text = Convert.ToString(Score);
            DeactivatorTurrets();
            GameObject.FindGameObjectWithTag("KING").GetComponent<King>().PlayerIsDead();
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStates>().enabled = false;
        }
        if (DM.GetComponent<DMScript>().GetDelay() > 0)
            UIDelay.GetComponentInChildren<TMP_Text>().text = Convert.ToString(DM.GetComponent<DMScript>().GetDelay());
        else
            UIDelay.GetComponentInChildren<TMP_Text>().text = "";   
        }
    public void addScore()
    {
        Debug.Log("Score" + Score);
        Score++;
    }

    public void minusHP()
    {
        hp--;
    }

    public void DeactivatorTurrets()
    {
       GameObject[] T = GameObject.FindGameObjectsWithTag("ZonaRange");
        foreach(GameObject i in T)
        {
            i.GetComponent<CatsColidder>().enabled = false;
        }
    }

    public void WriteResult()
    {
        if (PlayerPrefs.GetInt("Score1") == 0)
        {
            PlayerPrefs.SetString("Name1", SystemInfo.deviceName);
            PlayerPrefs.SetInt("Score1", Score);
        }
        else if (PlayerPrefs.GetInt("Score2") == 0)
        {
            PlayerPrefs.SetString("Name2", SystemInfo.deviceName);
            PlayerPrefs.SetInt("Score2", Score);
        }
        else if (PlayerPrefs.GetInt("Score3") == 0)
        {
            PlayerPrefs.SetString("Name3", SystemInfo.deviceName);
            PlayerPrefs.SetInt("Score3", Score);
        }
        else if (PlayerPrefs.GetInt("Score4") == 0)
        {
            PlayerPrefs.SetString("Name4", SystemInfo.deviceName);
            PlayerPrefs.SetInt("Score4", Score);
        }
        else if (PlayerPrefs.GetInt("Score5") == 0)
        {
            PlayerPrefs.SetString("Name5", SystemInfo.deviceName);
            PlayerPrefs.SetInt("Score5", Score);
        }
        else
        {
            if (PlayerPrefs.GetInt("Score1") < Score)
            {
                PlayerPrefs.SetString("Name1", SystemInfo.deviceName);
                PlayerPrefs.SetInt("Score1", Score);
            }
            else if (PlayerPrefs.GetInt("Score2") < Score)
            {
                PlayerPrefs.SetString("Name2", SystemInfo.deviceName);
                PlayerPrefs.SetInt("Score2", Score);
            }
            else if (PlayerPrefs.GetInt("Score3") < Score)
            {
                PlayerPrefs.SetString("Name3", SystemInfo.deviceName);
                PlayerPrefs.SetInt("Score3", Score);
            }
            else if (PlayerPrefs.GetInt("Score4") < Score)
            {
                PlayerPrefs.SetString("Name4", SystemInfo.deviceName);
                PlayerPrefs.SetInt("Score4", Score);
            }
            else if (PlayerPrefs.GetInt("Score5") < Score)
            {
                PlayerPrefs.SetString("Name5", SystemInfo.deviceName);
                PlayerPrefs.SetInt("Score5", Score);
            }
        }

        PlayerPrefs.Save();

        SceneManager.LoadScene("MainMenu");
    }
}
