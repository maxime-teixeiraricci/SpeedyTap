using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    public float time;
    public Image image;

	
	// Update is called once per frame
	void Update ()
    {
        time -= Time.deltaTime;
        image.fillAmount = time % 1;
        GetComponent<Text>().text = ""+(int)time;
	}
}
