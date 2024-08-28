using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{

    private float distance = 20f;
    [SerializeField] private LayerMask enemylayer;
    [SerializeField] private GameObject bullet;
    private Coroutine shoot;
   // public GameObject playerBullet;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {

        Debug.DrawLine(transform.position, transform.TransformDirection(Vector2.left) * distance, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), distance, enemylayer);


        if (hit)
        {
            if (shoot == null)
            {
                shoot = StartCoroutine(CreateTheBullet());
            }
            Debug.Log("you hit " + hit.collider.name);
         

        }
    }
    IEnumerator CreateTheBullet()
    {
        for (int i = 0; i < 100; i++)
        {
            Vector2 bulletPos = new Vector2(transform.position.x +-.5f , transform.position.y);  //random pos
            bullet.transform.GetComponent<SpriteRenderer>().color = Color.black; //random color
            Instantiate(bullet, bulletPos, Quaternion.identity);

            yield return new WaitForSeconds(2f);
        }
        shoot = null;
    }
}
