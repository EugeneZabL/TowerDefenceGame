using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerOfUpgreid : MonoBehaviour
{
    [SerializeField] GameObject Upgreid1;
    [SerializeField] GameObject Upgreid2;
    //[SerializeField] GameObject Upgreid3;

    [SerializeField] GameObject UpgreidMenu;

    GameObject TempObject;

    GameObject Player;

    int Choise;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Choise = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Choise!=0)
        {
            if(TempObject != null)
            {
                GameObject j = TempObject;
                switch (Choise)
                {
                    case 1:
                        if (Player.GetComponent<PlayerStates>().money >= 5)
                        {
                            Player.GetComponent<PlayerStates>().money -= 5;
                            j = Instantiate(Upgreid1);
                            j.transform.parent = gameObject.transform;
                            j.transform.position = TempObject.transform.position;
                            Destroy(TempObject.transform.parent.gameObject);
                        }
                        else
                        {
                            GameObject.FindGameObjectWithTag("ShowMassage").GetComponent<ShowMassage>().ShowMessage("No money. Need 5");
                        }

                        break;
                    case 2:
                        if (Player.GetComponent<PlayerStates>().money >= 10)
                        {
                            Player.GetComponent<PlayerStates>().money -= 10;
                            j = Instantiate(Upgreid2);
                            j.transform.parent = gameObject.transform;
                            j.transform.position = TempObject.transform.position;
                            Destroy(TempObject.transform.parent.gameObject);
                        }
                        else
                        {
                            GameObject.FindGameObjectWithTag("ShowMassage").GetComponent<ShowMassage>().ShowMessage("No money. Need 10");
                        }
                        break;
                        default:
                        break;
                }
                Choise = 0;
                
            }
        }
    }

   public void TryToUpgreid(GameObject t)
    {
        TempObject = t;
        UpgreidMenu.SetActive(true);
    }

    public void Button1()
    {
       Choise = 1 ;
    }
    public void Button2()
    {
        Choise = 2;
    }
    public void Button3()
    {
        Choise = 3;
    }
}
