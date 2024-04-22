using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    [SerializeField] GameObject krisa;
    [SerializeField] Transform[] _Waypoints;

    private float delayTime;
    private int LongOfArmy;
    private int ArmyAlive;

    public bool doWork = false;

    List<GameObject> KingArmy = new List<GameObject>(0);

    float delay;
    int i = 0;

    void Update()
    {
        if (doWork)
        {
            delay -= Time.deltaTime;
            if (delay <= 0 && i < LongOfArmy)
            {
                Debug.Log("i " + i);
                delay = delayTime;
                KingArmy[i].gameObject.SetActive(true);
                i++;
            }
            if(i >= LongOfArmy&& ArmyAlive<=0)
            {
                Debug.Log("WaweIsEnded");
                GetComponentInParent<DMScript>().WaweIsEnd();
                doWork = false;
            }
        }
    }

   public void PlayerIsDead()
    {
        foreach(GameObject d in KingArmy)
        {
            d.GetComponent<MOVE>().speed = 0;
        }

        transform.GetComponentInParent<DMScript>().enabled = false;
    }

    public void InitTheWawe(float delaytimeT, int LongOfArmyT, float speedT, int hpT)
    {
        Debug.Log("INIT");
        i = 0;
        delayTime = delaytimeT;
        LongOfArmy = LongOfArmyT;
        ArmyAlive = LongOfArmyT;

        KingArmy.Clear();

        for (int j = 0; j < LongOfArmy; j++)
        {
            KingArmy.Add(Instantiate(krisa));
            KingArmy[j].gameObject.SetActive(false);
            KingArmy[j].transform.SetParent(transform);
            KingArmy[j].transform.position = this.transform.position;
            KingArmy[j].GetComponent<MOVE>().Waypoints = _Waypoints;
            KingArmy[j].GetComponent<MOVE>().speed = speedT;
            KingArmy[j].GetComponent<MOVE>().HP = hpT;
        }
        doWork = true;
    }

    public void MinusKris()
    {
        
        ArmyAlive = ArmyAlive - 1;
        Debug.Log("ArmyAlywe" + ArmyAlive);
    }

}
