using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] Vector3 offset;

    Transform playerTransform;

    float delayspeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xoffset = playerTransform.transform.position.x;
        float zoffset = playerTransform.transform.position.z;
        float yoffset = playerTransform.transform.position.y;
        //Vector3 camposition = playerTransform.position + (offset - new Vector3(0f,yoffset,0f));
        Vector3 camposition = offset - new Vector3(-xoffset, -yoffset, -zoffset);

        transform.position = Vector3.Lerp(transform.position, camposition, Time.deltaTime * delayspeed);
    }
}
