using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float t;
    public static TimerScript instance;


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
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        t += Time.deltaTime;
        GetComponent<Text>().text = ToString(t);
    }

    public string ToString(float t)
    {
        int min = (int)(t / 60);
        float sec = t % 60;
        return min.ToString("00") + ":" + sec.ToString("00.000");
    }
}
