using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

    public int score;


    public static PlayerScript instance;


    // Use this for initialization
    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
            
        }

    }

    public void MoveLeft()
    {
        transform.position += Vector3.forward;
        GameGenerator.instance.AddGenerator();
        AddScore();
    }

    public void MoveRight()
    {
        transform.position += Vector3.right;
        GameGenerator.instance.AddGenerator();
        AddScore();
    }

    void AddScore()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray.origin, ray.direction, out hit))
        {
            if (hit.transform.tag == "BadPlateform")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                GameGenerator.instance.SaveBestScore();
                return;
            }

            score++;
            if (score == 1000)
            {
                PlayerPrefs.SetFloat("BestTime1000", Mathf.Min(PlayerPrefs.GetFloat("BestTime1000"), TimerScript.instance.t));
            }
            else if (score == 500)
            {
                PlayerPrefs.SetFloat("BestTime500", Mathf.Min(PlayerPrefs.GetFloat("BestTime500"), TimerScript.instance.t));
            }
            else if (score == 100)
            {
                print("Best : " + PlayerPrefs.GetFloat("BestTime100"));
                print("Current : " + TimerScript.instance.t);
                PlayerPrefs.SetFloat("BestTime100", Mathf.Min(PlayerPrefs.GetFloat("BestTime100"), TimerScript.instance.t));
            }
        }
        else
        {
            GameGenerator.instance.SaveBestScore();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
