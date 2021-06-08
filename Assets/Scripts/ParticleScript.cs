using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    ParticleSystem particleobject;
    // Start is called before the first frame update
    void Start()
    {
        particleobject = GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!particleobject.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
