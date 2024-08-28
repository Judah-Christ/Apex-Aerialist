using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private GameObject plat;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateThePlat());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CreateThePlat()
    {
        for (int i = 0; i < 25; i++)
        {
            Vector2 platPos = new Vector2(Random.Range(-2, 2), Random.Range(-5,20));  //random pos
          
            Instantiate(plat, platPos, Quaternion.identity) ;

            yield return new WaitForSeconds(.5f);
        }
    }
}
