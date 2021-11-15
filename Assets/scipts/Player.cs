using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //velocidad de la nave
    public float acceleration;
    public float maxSpeed;
    //reducir la velcidad
    public float drag;
    //rotacion
    public float angularSpeed;
    //disparos
    public Vector2 bulletPosition;
    public GameObject bullet; 
    public GameObject bulletPrefab;
    public float offsetBullet;
    public float shootRate = 0.5f;
    private bool canShoot = true;
    //coliciones 
    
    private Rigidbody2D rb;
    //varibles de player
    private float horizontal;
    private float vertical;
    private float reverseVertical;
    private bool shooting;
    

    

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent <Rigidbody2D> ();
        rb.drag=drag;
    
    }

    // Update is called once per frame
    void Update()
    {
        vertical= InputManager.Vertical;
        reverseVertical= InputManager.Vertical;

        horizontal= InputManager.Horizontal;
        shooting= InputManager.Fire;
        Rotate();
        Shoot();
    }

    //update para las fisicas
    void FixedUpdate()
    {
        var forwardMotor = Mathf.Clamp (vertical,0f,1f);
        var reverseMotor = Mathf.Clamp (reverseVertical,-1f,0f);
        rb.AddForce(transform.up * acceleration * forwardMotor);  
         rb.AddForce(transform.up * acceleration * reverseMotor);  
        if(rb.velocity.magnitude > maxSpeed){
            rb.velocity = rb.velocity.normalized * maxSpeed;
        } 
    }

    private void Rotate()
    {
        if (horizontal == 0)
        {
         return;   
        }
        transform.Rotate(0,0,-angularSpeed * horizontal *Time.deltaTime);
    }


    public void Shoot()
    {
         if (shooting && canShoot)
        {
            StartCoroutine (FireRate ());
        }
    }

   public void Lose () {
            // var nsp = FindObjectsOfType<NetworkStartPosition> ();
            // var pos = nsp[Random.Range (0, nsp.Length)].transform.position;

            rb.velocity = Vector3.zero;
            transform.position = Vector3.zero;
        }


    private IEnumerator FireRate() {
        canShoot=false;
       
          
            var pos=transform.up * offsetBullet + transform.position;
            var bullet = Instantiate(
                bulletPrefab, pos, transform.rotation
            );
            yield return new WaitForSeconds (shootRate);
            Destroy(bullet, 5);
      
        canShoot=true;
    }

}
