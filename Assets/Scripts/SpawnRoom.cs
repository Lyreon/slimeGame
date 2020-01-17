using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    public LayerMask whatIsRoom;
    public LevelGeneration levelGen;
    void Update()
    {
        Vector2 fpos = new Vector2(transform.position.x - 4.5f, transform.position.y +  4.5f);
        Vector2 spos = new Vector2(transform.position.x + 4.5f, transform.position.y - 4.5f);
        Collider2D roomDetection = Physics2D.OverlapArea(fpos, spos, whatIsRoom);
        if (roomDetection == null && levelGen.stopGeneration == true)
        {

            int rand = Random.Range(0, levelGen.rooms.Length);
            Instantiate(levelGen.rooms[rand], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
