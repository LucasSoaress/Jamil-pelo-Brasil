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

	void OnCollisionEnter2D(Collision2D coll)
	{
		if ( coll.gameObject.tag == "Carro")
		{
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            valor *= -1;
        }

		if ( coll.gameObject.tag == "Carro2")
		{
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            valor *= -1;
        }
	}
}
