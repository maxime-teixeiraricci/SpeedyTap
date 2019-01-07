using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    public GameObject MenuHud;
    public GameObject GameHud;

	
	// Update is called once per frame
	void Update ()
    {
		if (PlayerScript.instance.score == 0)
        {
            MenuHud.SetActive(true);
            GameHud.SetActive(false);
        }
        else
        {
            MenuHud.SetActive(false);
            GameHud.SetActive(true);
        }
	}
}
