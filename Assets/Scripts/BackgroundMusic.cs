using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private const double V = .046;
   // public AudioClip Back;
    public AudioSource volume;
    // Start is called before the first frame update
    void Start()
    {
       // AudioSource.PlayClipAtPoint(Back, transform.position);
        AudioSource1(volume);
    }
    void AudioSource1(AudioSource v)
    {
        volume = v;
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
