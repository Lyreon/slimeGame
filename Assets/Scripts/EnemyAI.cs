using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public float dist;
    public float jumpSpeed;
    private bool movingRight = true;
    public Transform rayBoi;

    private void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(rayBoi.position, Vector2.down, dist*10);
        RaycastHit2D ceilingInfo = Physics2D.Raycast(rayBoi.position, Vector2.up, dist/3);

        if (ceilingInfo == true)
        {
            rb.AddForce(new Vector2(0f, jumpSpeed));
        }

        if (groundInfo.collider==false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
