using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShouldItTurn : MonoBehaviour
{

    public SpriteRenderer initial;
    public Sprite[] turned;
    private float percent;

    void OnTriggerEnter2D(Collider2D Collide)
    {
        TurnIt Player = Collide.GetComponent<TurnIt>();

        if (Player.type == 0 && (initial.sprite == turned[0] ||initial.sprite == turned[2]))
        {
            initial.sprite = turned[1];
            SpawnObject.turned++;
        }
        else if (Player.type == 1 && initial.sprite == turned[1])
        {
            initial.sprite = turned[2];
            SpawnObject.turned--; 
        }
        else if (Player.type == 1)
        {
            initial.sprite = turned[2];
        }
        percent = (SpawnObject.turned / SpawnObject.total) * 100;
        Debug.Log(percent);

    }
}
