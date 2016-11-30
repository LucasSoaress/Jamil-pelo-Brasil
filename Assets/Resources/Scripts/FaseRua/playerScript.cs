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
    public string Fim;
	public static int contadorColetaveis;
    private static int vida;

	void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
        pulando = false;
        contadorColetaveis = 0;
        vida = 3;
	}
	
	
	void Update () 
    {
        if (!gambiarraAnimacao.pausa)
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
                movimento(-speedX);

                if (transform.localScale.x > 0)
                {
                    transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                }
                GetComponent<Animator>().SetBool("correndo", true);
            }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
                GetComponent<Animator>().SetBool("correndo", false);

            //Pulo inicial
            if (Input.GetKeyUp(KeyCode.Space) && pulando == false && contadorPulo == 0)
            {
                rb.AddForce(new Vector2(0f, valor));
                pulando = true;
                contadorPulo = 1;
                GetComponent<Animator>().SetBool("pulando", true);
            }

            
            if (Input.GetKeyDown(KeyCode.Space) && pulando == false && contadorPulo == 3)
            {
                rb.AddForce(new Vector2(0f, valor - 100));
                pulando = true;
                contadorPulo = 0;
                GetComponent<Animator>().SetBool("pulando", true);
            }

            if (vida <= 0)
            {
                Application.LoadLevel("Menu");
            }

        }

    }

    void movimento(float speed)
    {
        transform.Translate(speed * Time.deltaTime, 0f, 0f);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //Colisão com o chão do cenário e os elementos de primeiro nivel
        if (coll.gameObject.tag == "Chao" || coll.gameObject.tag == "Banco" )
        {
            pulando = false;
            contadorPulo = 0;
            GetComponent<Animator>().SetBool("pulando", false);
        }

        //Colisão com Carrinho de côco
        if ( coll.gameObject.tag == "Carrinho")
        {
            pulando = false;
            contadorPulo = 3;
            GetComponent<Animator>().SetBool("pulando", false);
        }

        //Colisão e coleta de objetos
        if (coll.gameObject.tag == "Coletavel")
        {
            Destroy(coll.gameObject);
			contadorColetaveis++;
            this.GetComponent<AudioSource>().Play();
			
        }

        //Colisao com o bueiro, gerando mudança de cena e após o RESTART do jogo
        if (coll.gameObject.tag == "Bueiro")
        {
            Application.LoadLevel(Fim);
        }

        //Restart 
        if (coll.gameObject.tag == "Restart")
        {
            Application.LoadLevel(Cena);
        }

        if (coll.gameObject.tag == "Final_Sudeste" && contadorColetaveis == 5)
        {
            Application.LoadLevel(Cena);
			contadorColetaveis = 0;
        }

		if (coll.gameObject.tag == "Final_Sudeste" && contadorColetaveis < 5)
		{
			//aparece mensagem dizendo: "Voce nao coletou todos os brinquedos, volte e explore mais!"
            Debug.Log("Não coletou todos!");
		}

        if(coll.gameObject.tag == "Homem do Saco")
        {
            Application.LoadLevel("gameOver");
        }

        if(coll.gameObject.tag == "Coco")
        {
            vida--;
            Destroy(coll.gameObject);
        }
    }
}
