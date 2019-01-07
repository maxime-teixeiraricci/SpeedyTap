using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimationFading : MonoBehaviour
{
    public float speed;

	
	// Update is called once per frame
	void Update ()
    {
        Color color = GetComponent<Text>().color;
        float a = ((Mathf.Sin(Time.time * speed)) + 1 ) *0.5f;
        GetComponent<Text>().color = new Color(color.r, color.g, color.b, a);
	}
}
