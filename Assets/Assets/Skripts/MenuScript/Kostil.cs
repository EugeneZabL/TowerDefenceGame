using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kostil : MonoBehaviour
{
    [SerializeField] GameObject king;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene("MainMenu");
            Cursor.lockState = CursorLockMode.Confined;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            king.GetComponent<Main_hp>().minusHP();
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStates>().money = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStates>().money + 50;
        }
    }
}
