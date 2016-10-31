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
    public string Cena;
	public int contadorColetaveis;


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
	            GetComponent<Animator>().SetBool("correndo", true);
	        }

	        if (Input.GetKey(KeyCode.A))
	        {
	            movimento(- speedX);

	            if (transform.localScale.x > 0)
	            {
	                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
	            }
	            GetComponent<Animator>().SetBool("correndo", true);
	        }
	        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
	            GetComponent<Animator>().SetBool("correndo", false);

	        if (Input.GetKeyDown(KeyCode.Space) && pulando == false && contadorPulo == 0)
	        {
	            rb.AddForce(new Vector2(0f, valor));
	            pulando = true;
	            contadorPulo = 1;
	            GetComponent<Animator>().SetBool("pulando", true);
	        }

	        if (Input.GetKeyDown(KeyCode.Space) && pulando == false && contadorPulo == 2)
	        {
	            rb.AddForce(new Vector2(0f, valor - 100));
	            pulando = true;
	            contadorPulo = 2;
	            GetComponent<Animator>().SetBool("pulando", true);
	        }
		 
	}

    void movimento(float speed)
    {
        transform.Translate(speed * Time.deltaTime, 0f, 0f);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Chao" || coll.gameObject.tag == "Banco" )
        {
            pulando = false;
            contadorPulo = 0;
            GetComponent<Animator>().SetBool("pulando", false);
        }

        if ( coll.gameObject.tag == "Carrinho")
        {
            pulando = false;
            contadorPulo = 2;
            GetComponent<Animator>().SetBool("pulando", false);
        }

        if (coll.gameObject.tag == "Coletavel")
        {
            Destroy(coll.gameObject);
			contadorColetaveis++;
            this.GetComponent<AudioSource>().Play();
        }

        if (coll.gameObject.tag == "Final_Sudeste" && contadorColetaveis == 5)
        {
            Application.LoadLevel(Cena);
			contadorColetaveis = 0;
        }

		/*if (coll.gameObject.tag == "Final_Sudeste" && contadorColetaveis < 5)
		{
			//aparece mensagem dizendo: "Voce nao coletou todos os brinquedos, volte e explore mais!"
		}*/
    }
}
