<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriger : MonoBehaviour
{

    public Audiodetector detector;
    public AudioSource SFXaudio;

    public float sensibility = 100;
    public float threshold = 0.1f;

    public GameObject bubbleObject;
    
    public Transform bubbleCanon;

    public bool started = false;
    
    public int bubbleCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void OnBubbles()
    {
        started = true;
    }

    // Update is called once per frame
    void Update()
    {

        float loudness = detector.getloudness() * sensibility;

   
        if (loudness >= threshold && started)
        {
            
            GameObject.Instantiate(bubbleObject.transform, bubbleCanon.position, gameObject.transform.rotation);
            SFXaudio.Play();
            bubbleCount++;
            Debug.Log("conteo burbuja: " + bubbleCount);
            StartCoroutine(Spawn());
        }


    }
    
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1);
    }

    public void spawnBubbles()
    {
        if (started)
        {

            GameObject.Instantiate(bubbleObject.transform, bubbleCanon.position, gameObject.transform.rotation);
            SFXaudio.Play();
            bubbleCount++;
            Debug.Log("conteo burbuja: " + bubbleCount);
            StartCoroutine(Spawn());
        }

    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriger : MonoBehaviour
{

    public Audiodetector detector;
    public AudioSource SFXaudio;

    public float sensibility = 100;
    public float threshold = 0.1f;

    public GameObject bubbleObject;
    
    public Transform bubbleCanon;

    public bool started = false;
    
    public int bubbleCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void OnBubbles()
    {
        started = true;
    }

    // Update is called once per frame
    void Update()
    {

        float loudness = detector.getloudness() * sensibility;

   
        if (loudness >= threshold && started)
        {
            
            GameObject.Instantiate(bubbleObject.transform, bubbleCanon.position, gameObject.transform.rotation);
            SFXaudio.Play();
            bubbleCount++;
            Debug.Log("conteo burbuja: " + bubbleCount);
            StartCoroutine(Spawn());
        }


    }
    
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1);
    }
    
}
>>>>>>> b8048306 (finish ggj2025)
