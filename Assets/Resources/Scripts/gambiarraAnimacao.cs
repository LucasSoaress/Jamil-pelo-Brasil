using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gambiarraAnimacao : MonoBehaviour
{
    public Image[] pes;
    private float tempo;
    private int ii;
    public Canvas instru;
    private float tempoDois;
    public static bool pausa;
    
	void Start ()
    {
        pausa = true;
        ii = 0;
        tempo = 0;

        for(int i = 0; i < pes.Length; i++)
        {
            pes[i].enabled = false;
        }
	}
	
	void Update ()
    {
        if(instru.enabled)
        {
            tempo += Time.deltaTime;
        }
        
        if (tempo >= 1 && ii < pes.Length )
        {
            pes[ii].enabled = true;
            tempo = 0;
            ii++;
        }

        if(pes[5].enabled)
        {
            tempoDois += Time.deltaTime;
            if(tempoDois >= 0.4)
            {
                pausa = false;
                instru.enabled = false;
                tempoDois = 0;
            }
            
        }
	}
}
