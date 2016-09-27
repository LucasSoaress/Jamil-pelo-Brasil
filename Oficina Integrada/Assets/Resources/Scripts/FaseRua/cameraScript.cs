using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour 
{
    public Transform Boneco;
    public float mininoX;
    public float maximoX;
    
    void LateUpdate ()
    {
        this.transform.position = new Vector3(Mathf.Clamp(Boneco.position.x, mininoX, maximoX),Boneco.position.y + 2.7f, transform.position.z);    
    }
}
