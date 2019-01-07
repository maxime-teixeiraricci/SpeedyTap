using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestTimeHUD : MonoBehaviour
{
    public string text;
    public string playerPrefabKey;

	// Use this for initialization
	void Start ()
    {
        GetComponent<Text>().text = text + "\n" + TimerScript.instance.ToString(PlayerPrefs.GetFloat(playerPrefabKey));
	}
}
