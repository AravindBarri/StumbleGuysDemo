using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    SphereGenerator SGObj;
    private void Start()
    {
        SGObj = FindObjectOfType<SphereGenerator>();
    }
    private void Update()
    {
        /*if(transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "CheckPoint")
        {
            SGObj.pushtoStack(other.gameObject);
        }
    }
}
