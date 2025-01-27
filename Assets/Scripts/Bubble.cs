using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public float lifetime;
    // Start is called before the first frame update
    private void Awake()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifetime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
