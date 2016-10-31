using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menuScript : MonoBehaviour 
{
    public GameObject menuzinho;

	public void abrirJogo()
    {
       menuzinho.GetComponent<Animator>().SetInteger("posicao",4);
    }
}
