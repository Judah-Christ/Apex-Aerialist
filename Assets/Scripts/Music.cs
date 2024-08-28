using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
 
    public AudioClip Main;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(Main, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
