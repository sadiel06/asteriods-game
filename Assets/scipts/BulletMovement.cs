using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
