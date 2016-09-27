using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour 
{

    public float speedX;
    public float speedY;
    public float valor;
    private Rigidbody2D rb;
    private bool pulando;
    private int contadorPulo;
   
	void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
        pulando = false; 
	}
	
	
	void Update () 
    {
	    if (Input.GetKey(KeyCode.D))
        {
            movimento(speedX);

            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);  
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            movimento(- speedX);

            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            } 
        }

        if (Input.GetKeyDown(KeyCode.Space) && pulando == false && contadorPulo == 0)
        {
            rb.AddForce(new Vector2(0f, valor));
            pulando = true;
            contadorPulo = 1;
        }

        else if (Input.GetKeyDown(KeyCode.Space) && pulando == true && contadorPulo == 1)
        {
            rb.AddForce(new Vector2(0f, valor - 250f));
            contadorPulo = 2;
        }

    }

    void movimento(float speed)
    {
        transform.Translate(speed * Time.deltaTime, 0f, 0f);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Chao")
        {
            pulando = false;
            contadorPulo = 0;
        }      
    }
}
