using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatsColidder : MonoBehaviour
{
    List<GameObject> targetsCor = new List<GameObject>(0);

    [SerializeField] GameObject BODY;

    [SerializeField] int typeOfTurre = 0;        // 0 - bonker
                                                 // 1 - Support

    GameObject ParticleManager;

    private void Start()
    {
        ParticleManager = GameObject.FindGameObjectWithTag("ParticleCash");
    }
    public float level = 1;
    public float delay = 3;
    float tempDelay = 2;

    public float damage = 1;

    private void Update()
    {
        if (targetsCor.Count != 0)
        {
            switch(typeOfTurre)
            {
                case 0:
                    BONKER();
                    break;
                case 1:
                    Support();
                    break;
            }
        }
        tempDelay = tempDelay - Time.deltaTime;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            targetsCor.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            targetsCor.Remove(other.gameObject);
        }
    }

    void BONKER()
    {
        if (targetsCor[0].gameObject.activeSelf)
        {
            BODY.transform.LookAt(targetsCor[0].transform);
            //tempDelay = tempDelay -Time.deltaTime;
            if (tempDelay <= 0)
            {
                targetsCor[0].GetComponent<MOVE>().TakeDamage(damage);
                ParticleManager.GetComponent<ParticleManager>().AskForBonk(targetsCor[0].transform);
                tempDelay = delay;
            }
        }
        else if (!targetsCor[0].gameObject.activeSelf)
            targetsCor.Remove(targetsCor[0]);
    }

    void Support()
    {
        if (tempDelay <= 0)
        {
            foreach(GameObject t in targetsCor)
            {
                if(t.activeSelf)
                {
                    ParticleManager.GetComponent<ParticleManager>().AskForFreze(t.transform);
                    if (t.GetComponent<MOVE>().speed>10)
                        t.GetComponent<MOVE>().speed = 10;
                }
            }
            tempDelay = delay;
        }
    }

    public void Uppdeit()
    {
        level = level+1;
        CalculateStat();
    }
    void CalculateStat()
    {
        damage = damage + (level * 0.1f) * 2;
        delay = delay - (level * 0.1f);
        if(delay<0.5)
        {
            delay = 0.5f;
        }
    }
}
