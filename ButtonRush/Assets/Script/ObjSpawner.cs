using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpawner : MonoBehaviour
{
    public GameObject[] tavler;

    int randomSpawn;

    float time = 2;

    float xPosition;
    float zPosition;
    float yPoaition = 15f;

    int changed;

    void Start()
    {
        // Starts the Coroutine(spawnTavle()
        StartCoroutine(spawnTavle());
    }

    void Update()
    {
        // Stops and sarts the Coroutine, if the game is started or not
        if (gameManager.gameStarted == true && changed == 1)
        {
            StartCoroutine(spawnTavle());
            changed = 0;
        }  
          else if (gameManager.gameStarted == false)
        {
            changed = 1;
            StopAllCoroutines();
        }
        
    }

    public IEnumerator spawnTavle()
    {
        // Instantiat the "Tavler" at random position and random time
        while (gameManager.gameStarted == true)
        {
            randomSpawn = Random.Range(0, tavler.Length);
            time = Random.Range(1.5f, 3f);
            xPosition = Random.Range(-6, 7);
            zPosition = Random.Range(20, 35);
            Instantiate(tavler[randomSpawn], new Vector3(xPosition, yPoaition, zPosition), Quaternion.identity);
            yield return new WaitForSeconds(time);
            

        }
        
    }
}
