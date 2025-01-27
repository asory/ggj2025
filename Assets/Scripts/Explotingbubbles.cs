using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explotingbubbles : MonoBehaviour
{

    static public Explotingbubbles explotingbubbles;
    public float sise;
    public AudioSource explodingAudio;
    
    bool win = false;

    static public int score = 0;
 
    void Start()
    {
        explotingbubbles = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x >= sise)
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        if (win)
        {
            score++;
            win = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bubble"))
        {

            transform.localScale = new Vector3(transform.localScale.x * 1.5f, transform.localScale.y * 1.5f, transform.localScale.z * 1.5f);
            explodingAudio.Play();
            win = true;
            Destroy(other.gameObject);

        }
    }
    
    
    //public int GetbubbleCount()
    //{
    //    return score;
    //}
}
