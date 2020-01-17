using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        RoomType room = hitInfo.GetComponent<RoomType>();
        if( room != null)
        {
            Destroy(gameObject);
        }
        
    }
}
