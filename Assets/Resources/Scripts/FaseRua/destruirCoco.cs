using UnityEngine;
using System.Collections;

public class destruirCoco : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Chao")
        {
            Destroy(this.gameObject);
        }
    }
}
