using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnbubbles : MonoBehaviour
{
    public GameObject bubbles;
    public bool spawning;
    public Vector3 center;
    public Vector3 sise;

    public void Awake()
    {
    }

    public void OnBubbles()
    {
        spawning = true;
        StartCoroutine(launchbubbles());
    }
   
    IEnumerator launchbubbles()
    {

        while (spawning)
        {

          yield return new WaitForSeconds(Random.Range(0,2));
          {
            Vector3 randomspawn = new Vector3(Random.Range(-sise.x / 2, sise.x / 2), transform.position.y, Random.Range(-sise.z / 2, sise.z / 2));

            Instantiate(bubbles, randomspawn, transform.rotation);
          }


        }

        
    }
}
