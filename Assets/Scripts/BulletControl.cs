using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.GetComponent<Rigidbody2D>().velocity = move;
    }
   
}
