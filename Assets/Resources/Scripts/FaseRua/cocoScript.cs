using UnityEngine;
using System.Collections;

public class cocoScript : MonoBehaviour
{
    public GameObject spawn;
    public GameObject coco;
    private float tempo;

	void Start ()
    {
        tempo = 0;
	}
	
	void Update ()
    {
        tempo += Time.deltaTime;
        if(tempo > 3)
        {
            Instantiate(coco, new Vector2(spawn.transform.position.x, spawn.transform.position.y), Quaternion.identity);
            tempo = 0;
        }
	}
}
