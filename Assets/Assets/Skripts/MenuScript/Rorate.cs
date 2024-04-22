using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rorate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;

    [SerializeField] Scene Lvl1;    
    void Start()
    {
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            GetComponent<AudioSource>().Stop();
        }
        else
        {
            GetComponent<AudioSource>().Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,Time.deltaTime*speed,0);
    }

    public void StartScene1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Music()
    {
        if (PlayerPrefs.GetInt("Music")==0)
        {
            PlayerPrefs.SetInt("Music", 1);
            GetComponent<AudioSource>().Play();
        }
        else
        {
            PlayerPrefs.SetInt("Music", 0);
            GetComponent<AudioSource>().Stop();
        }
        PlayerPrefs.Save();
    }
}
