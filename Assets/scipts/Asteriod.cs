using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteriod : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
 public GameObject[] subAsteroids;
    public int numberOfAsteroids;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        rb.drag = 0;
        rb.angularDrag = 0;

        rb.velocity = new Vector3 (
            Random.Range (-1f, 1f),
            Random.Range (-1f, 1f),
            // Random.Range (-1f, 1f)
            0
        ).normalized * speed;

        rb.angularVelocity = Random.Range (-50f, 50f);
    }

     bool isDestroying = false;

     private void OnTriggerEnter2D (Collider2D col)
    {
         if(isDestroying)
            return;
       
        isDestroying = true;

         if (col.CompareTag("Bullet"))
         {
            Destroy(gameObject);
            Destroy(col.gameObject);
            for (var i = 0; i < numberOfAsteroids; i++) 
            {
                var subinstatiate = Instantiate 
                (
                    subAsteroids[Random.Range (0, subAsteroids.Length)],
                    transform.position,
                    Quaternion.identity
                );
            }
        }
        if (col.CompareTag("Player"))
        {
            var asteroids= FindObjectsOfType<Asteriod>();
            for (var i = 0; i < asteroids.Length; i++)
            {
                Destroy(asteroids[i].gameObject);
            }
            col.GetComponent<Player>().Lose();
        }
    }

   
}
