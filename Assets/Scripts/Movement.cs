using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

   	public float movementSpeed;
	public float jumpSpeed;
	public Animator animator;
	
	float horizontalMove = 0f;
	

    // Update is called once per frame
    void FixedUpdate()
    {
	horizontalMove = Input.GetAxisRaw("Horizontal") * movementSpeed;

	animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

 	if(Input.GetKeyDown("w")){
		GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpSpeed;
		}
        if (Input.GetKey ("a") && !Input.GetKey ("d")) {
                transform.position += transform.TransformDirection (Vector2.left) * Time.deltaTime * movementSpeed;
            } 
	else if (Input.GetKey ("d") && !Input.GetKey ("a")) {
                transform.position -= transform.TransformDirection (Vector2.left) * Time.deltaTime * movementSpeed;
            }
    }
}
