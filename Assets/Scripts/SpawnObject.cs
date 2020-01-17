using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
	public GameObject[] objects;
    public static float total;
    public static float turned;

	private void Start()
	{
		int rand = Random.Range(0, objects.Length);
		GameObject instance = (GameObject)Instantiate(objects[rand], transform.position, Quaternion.identity);
        instance.transform.parent = transform;
        if (rand == 0)
        {
            total++;
        }
    }
}
