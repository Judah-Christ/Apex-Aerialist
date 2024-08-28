using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPlatformController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") // looking for collision between the player and platform
        {
            Destroy(gameObject);        //destroys the game object it self
           

        }
    }
}
