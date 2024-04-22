using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStates : MonoBehaviour
{
    [SerializeField] GameObject CatBase;
    [SerializeField] GameObject Molot;
    [SerializeField] GameObject Fish;
    [SerializeField] GameObject Vudka;

    [SerializeField] GameObject FishGame;

    [SerializeField] GameObject MessegeShow;
    RaycastHit hit;



    public int money = 5;

    int PlayerST = 0;       // 0 - Normal
                            // 1 - BILDING
                            // 2 - Upgreid
                            // 3 - Fishing


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MouseTweek();
        if (Input.GetKeyDown(KeyCode.Alpha1))
            PlayerST = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            PlayerST = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            PlayerST = 2;
        if (Input.GetKeyDown(KeyCode.Alpha4))
            PlayerST = 3;

        switch (PlayerST)
        {
            case 0:
                Molot.SetActive(false);
                Vudka.SetActive(false);
                Fish.SetActive(false);
                break;

            case 1:
                Building();
                Molot.SetActive(true);
                Vudka.SetActive(false);
                Fish.SetActive(false);
                break;

            case 2:
                Upgreid();
                Molot.SetActive(false);
                Vudka.SetActive(false);
                Fish.SetActive(true);
                break;

            case 3:
                Fishing();
                FishGame.SetActive(true);
                Molot.SetActive(false);
                Vudka.SetActive(true);
                Fish.SetActive(false);
                break;
        }
        if (FishGame.activeSelf && PlayerST!=3)
        {
            FishGame.SetActive(false);
        }
    }

    void Building()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit);
            if(!hit.collider.gameObject.CompareTag("NonTurra"))
            {
                GameObject t = Instantiate(CatBase);
                t.transform.position = hit.point;
                t.transform.SetParent(GameObject.FindGameObjectWithTag("MassOfTurr").transform);
            }
        }
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit);
            if (hit.collider.gameObject.CompareTag("NonTurra"))
            {
                Destroy(hit.collider.gameObject.transform.parent.gameObject);
            }
        }
    }

    void Upgreid()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit);
            if (hit.collider.gameObject.CompareTag("NonTurra"))
            {
                GameObject.FindGameObjectWithTag("MassOfTurr").GetComponent<ManagerOfUpgreid>().TryToUpgreid(hit.collider.gameObject);
            }
            if(hit.collider.gameObject.CompareTag("TURRETS"))
            {
                Debug.Log("TURRETS");
                float level = hit.collider.gameObject.transform.GetChild(1).GetComponent<CatsColidder>().level;
                if(money>=level)
                {
                    hit.collider.gameObject.transform.GetChild(1).GetComponent<CatsColidder>().Uppdeit();
                    money = money - Convert.ToInt32(level);
                    MessegeShow.GetComponent<ShowMassage>().ShowMessage("New Level is " + (level+1f));
                }
                else
                    MessegeShow.GetComponent<ShowMassage>().ShowMessage("No Money. Need - " + level);
            }
        }
    }

    void MouseTweek()
    {
        if(Input.GetKeyDown(KeyCode.Mouse2))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.Confined;
            else
                Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Fishing()
    {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (FishGame.transform.GetChild(1).GetComponent<PointerSkript>().isFishing())
                {
                    money++;
                }
            }
    }

}
