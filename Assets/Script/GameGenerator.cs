using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour
{
    public GameObject prefab;
    public GameObject badPrefab;
    public int number;
    public int currentScore;
    public GameObject currentObject;
    public static GameGenerator instance;
    public int deltaScore;

    // Use this for initialization
    private void Awake()
    {
       /*
        PlayerPrefs.SetFloat("BestTime1000", 0);
        PlayerPrefs.SetFloat("BestTime500", 0);
        PlayerPrefs.SetFloat("BestTime100", 0);
        */

        if (PlayerPrefs.GetFloat("BestTime100") == 0)
        {
            PlayerPrefs.SetFloat("BestTime100", 99 * 60 + 59.999f);
        }
        if (PlayerPrefs.GetFloat("BestTime500") == 0)
        {
            PlayerPrefs.SetFloat("BestTime500", 99 * 60 + 59.999f);
        }
        if (PlayerPrefs.GetFloat("BestTime1000") == 0)
        {
            PlayerPrefs.SetFloat("BestTime1000", 99 * 60 + 59.999f);
        }

        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    void Start () {
        Generator();

    }


    public void Update()
    {
        deltaScore = Mathf.Max(10 - (PlayerScript.instance.score / 11), 1);
    }





    void Generator()
    {
        currentObject = Instantiate(prefab);
        currentObject.transform.position = new Vector3(0, -7.5f, 0);
        currentObject.GetComponent<PlateformScript>().UpdateText();
        for (int i = 1; i < number+1; i++)
        {
            if (currentScore - PlayerScript.instance.score < deltaScore )
            AddGenerator();
        }
    }



    public void AddGenerator()
    {
        if (currentScore - PlayerScript.instance.score < deltaScore)
        {
            GameObject obj = Instantiate(prefab);
            Vector3 offsetVect;
            Vector3 badOffsetVect;

            if (Random.Range(0f, 1f) < 0.5f)
            {
                offsetVect = Vector3.forward;
                if (Mathf.Min(45,1.25f * (int)(PlayerScript.instance.score / 13)) > Random.Range(0f,100f))
                {
                    badOffsetVect = Vector3.right;
                    GameObject bad = Instantiate(badPrefab);
                    bad.transform.position = currentObject.transform.position + badOffsetVect;
                    print("BAD");
                }
            }
            else
            {
                offsetVect = Vector3.right;
                if (Mathf.Min(45, 1.25f * (int)(PlayerScript.instance.score / 13)) > Random.Range(0f, 100f))
                {
                    badOffsetVect = Vector3.forward;
                    GameObject bad = Instantiate(badPrefab);
                    bad.transform.position = currentObject.transform.position + badOffsetVect;
                    print("BAD");
                }
            }
            
            obj.GetComponent<PlateformScript>().score = currentObject.GetComponent<PlateformScript>().score + 1;
            obj.name = "Plateforme " + obj.GetComponent<PlateformScript>().score;
            currentScore = obj.GetComponent<PlateformScript>().score;
            obj.GetComponent<PlateformScript>().UpdateText();
            obj.transform.position = currentObject.transform.position + offsetVect;
            currentObject = obj;
        }

    }


    public void SaveBestScore()
    {
        
        PlayerPrefs.SetInt("BestScore", Mathf.Max(PlayerPrefs.GetInt("BestScore"), PlayerScript.instance.score));
    }



}
