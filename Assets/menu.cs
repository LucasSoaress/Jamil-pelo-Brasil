using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menu : MonoBehaviour 
{
    public Canvas menuzinho;
    public Image creditos;
    public Image setinha;
    public Canvas instru;
    public Canvas ui;

    void Start()
    {
        ui.enabled = false;
        instru.enabled = false;
        creditos.enabled = false;
        setinha.enabled = false;
    }
    public void fechar()
    {
        ui.enabled = true;
        menuzinho.enabled = false;
        instru.enabled = true;
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
