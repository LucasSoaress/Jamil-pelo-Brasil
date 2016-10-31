using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour 
{
    public Transform Boneco;
    public float mininoX;
    public float maximoX;
    
    void LateUpdate ()
    {
        this.transform.position = new Vector3(Mathf.Clamp(Boneco.position.x, mininoX, maximoX),transform.position.y, transform.position.z);    
    }
}
