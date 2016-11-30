using UnityEngine;
using System.Collections;

public class monstroScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public int valor;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {
        rb.AddForce(new Vector2(-valor, 0f));
    }
}
