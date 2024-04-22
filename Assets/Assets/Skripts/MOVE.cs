using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVE : MonoBehaviour
{
    [SerializeField] GameObject ManagerPar;
    public Transform[] Waypoints;
    public float speed;

    public float HP = 1;

    int corrctPoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == Waypoints[corrctPoint].position && corrctPoint < Waypoints.Length - 1)
            corrctPoint = (corrctPoint + 1);
        else if(transform.position == Waypoints[corrctPoint].position)
        {
            GetComponentInParent<Main_hp>().minusHP();
            GetComponentInParent<King>().MinusKris();
            gameObject.SetActive(false);   
        }

        transform.position = Vector3.MoveTowards(transform.position, Waypoints[corrctPoint].position, speed * Time.deltaTime);
        transform.LookAt(Waypoints[corrctPoint].position);

        if(HP<=0)
        {
            GetComponentInParent<Main_hp>().addScore();
            GetComponentInParent<King>().MinusKris();
            ManagerPar.GetComponent<ParticleManager>().AskForDieCr(transform);
            gameObject.SetActive(false);
        }
    }

    public void TakeDamage(float damage)
    {
        HP = HP - damage;
    }

}
