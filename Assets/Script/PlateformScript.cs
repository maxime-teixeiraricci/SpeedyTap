using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlateformScript : MonoBehaviour
{

    public TextMesh scoreText;
    public int score;

    public void Update()
    {
        if (PlayerScript.instance.score - 5 > score)
        {
            Destroy(gameObject);
        }
    }
    public void UpdateText()
    {
        

        if (score % 10 == 0)
        {
            scoreText.text = score.ToString("00");
        }
        else
        {
            scoreText.text = "";
        }
    }
}
