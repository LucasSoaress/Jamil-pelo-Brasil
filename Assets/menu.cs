using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menu : MonoBehaviour 
{
    public Canvas menuzinho;
    public Image creditos;
    public Image setinha;

    void Start()
    {
        creditos.enabled = false;
        setinha.enabled = false;
    }
    public void fechar()
    {
        menuzinho.enabled = false;
    }

    public void mostrarCreditos()
    {
        creditos.enabled = true;
        setinha.enabled = true;
    }

    public void fecharTudo()
    {
        creditos.enabled = false;
        setinha.enabled = false;
    }

}
