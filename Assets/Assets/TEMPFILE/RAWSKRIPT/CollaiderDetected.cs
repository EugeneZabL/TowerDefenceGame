using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollaiderDetected : MonoBehaviour
{
    List<GameObject> targetsCor = new List<GameObject>(0);

    [SerializeField] GameObject BODY;

    public float delay = 2;
    float tempDelay = 2;

    public int damage = 1;

    private void Update()
    {
        if (targetsCor.Count != 0)
        {
            if (targetsCor[0].gameObject.activeSelf)
            {
                BODY.transform.LookAt(targetsCor[0].transform);
                //tempDelay = tempDelay -Time.deltaTime;
                if (tempDelay <= 0)
                {
                    targetsCor[0].GetComponent<MOVE>().TakeDamage(damage);
                    if (targetsCor[0] != null && !targetsCor[0].gameObject.activeSelf)
                        targetsCor.Remove(targetsCor[0]);
                    tempDelay = delay;
                }
            }
            else if (!targetsCor[0].gameObject.activeSelf)
                targetsCor.Remove(targetsCor[0]);
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
}
