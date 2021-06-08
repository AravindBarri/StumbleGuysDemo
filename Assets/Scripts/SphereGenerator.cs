using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : MonoBehaviour
{
    public GameObject sphereprefab;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateSphere", 1,4);
    }

    // Update is called once per frame
    void Update()
    {
        int ran = Random.Range(3, 4);
    }

    public void GenerateSphere()
    {
        Instantiate(sphereprefab, transform.position + offset, Quaternion.identity);
    }
}
