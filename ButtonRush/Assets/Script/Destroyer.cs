using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Destroyer : MonoBehaviour
{
    ScoreText scoreText;

    private void Start()
    {
        scoreText = FindObjectOfType<ScoreText>();



    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent.gameObject.GetComponent<ScoreToGive>().wrongAnswer == true)
        {
            
            scoreText.addScore(-other.transform.parent.gameObject.GetComponent<ScoreToGive>().scoreToAdd);
            gameManager.health -= 1;

        }
        else if (other.transform.parent.gameObject.GetComponent<ScoreToGive>().wrongAnswer == false)
        {
            scoreText.addScore(-other.transform.parent.gameObject.GetComponent<ScoreToGive>().scoreToAdd);
        }


        Destroy(other.transform.parent.gameObject);
    }
}
