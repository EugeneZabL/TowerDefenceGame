using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerSkript : MonoBehaviour
{
    float speed;

    bool Left = true;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CalculateSpeed();
        if (Left)
        {
            transform.Translate(-1 * Time.deltaTime * speed, 0, 0);
            if (transform.localPosition.z >= 20)
                Left = false;
        }
        else
        {
            transform.Translate(1 * Time.deltaTime * speed, 0, 0);
            if (transform.localPosition.z <= -20)
                Left = true;
        }
    }

    public bool isFishing()
    {
        if(transform.localPosition.z<=3 && transform.localPosition.z >= -3)
            return true;
        else return false;

    }

    void CalculateSpeed()
    {
        speed = 2 * player.GetComponent<PlayerStates>().money;
        if(speed<20)
            speed = 20;
        if(speed>80)
            speed = 80;
    }
}
