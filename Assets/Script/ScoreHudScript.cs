using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHudScript : MonoBehaviour {

    

    // Update is called once per frame
    void Update ()
    {
        GetComponent<TextMesh>().text = PlayerScript.instance.score.ToString("00");
	}
}
