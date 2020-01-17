using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRotation : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D p;
    private Vector2 mousePos;
    

    public Camera cam;
    
    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.transform.position = p.transform.position;


    }
    void FixedUpdate()
    {
       
        Vector2 lookDir =  mousePos - rb.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x)*Mathf.Rad2Deg;
        rb.rotation = angle;

        
    }

}
