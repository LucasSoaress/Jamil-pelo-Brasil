using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bahiaScript : MonoBehaviour 
{
    public Image Objeto1;
    public Image Objeto2;
    public Image Objeto3;
    public Image Objeto4;
    public Image Objeto5;
    private Color p1;
    private Color p2;
    private Color p3;
    private Color p4;
    private Color p5;

	void Start () 
    {
        p1 = Objeto1.color;
        p2 = Objeto2.color;
        p3 = Objeto3.color;
        p4 = Objeto4.color;
        p5 = Objeto5.color;
	}
	
	void Update () 
    {
        int contador = playerScript.contadorColetaveis;

        if (contador  >= 1)
        {
            p1.a = 255;
            Objeto1.color = p1;
        }
        if(contador >= 2)
        {
            p2.a = 255;
            Objeto2.color = p2;
        }
        if(contador >= 3)
        {
            p3.a = 255;
            Objeto3.color = p3;
        }
        if (contador >= 4)
        {
            p4.a = 255;
            Objeto4.color = p4;
        }
        if(contador >= 5)
        {
            p5.a = 255;
            Objeto5.color = p5;
        }
	}
}
