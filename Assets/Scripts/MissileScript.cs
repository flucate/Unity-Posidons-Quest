using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    //Attributes
    public float speed = 6;

 
    // Start is called before the first frame update
    void Start()
    {        
        Rigidbody2D rb = GetComponent<Rigidbody2D>();       
        rb.velocity = new Vector2(speed, 0);     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //When the missile left the cam view zone it is destroyed
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
