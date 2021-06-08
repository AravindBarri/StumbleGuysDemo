using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : MonoBehaviour
{
    public GameObject sphereprefab;
    public Vector3 offset;

    public Stack<GameObject> SphereStack;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateSphere", 1,4);
        SphereStack = new Stack<GameObject>();
        CreateSphere(10);
    }

    // Update is called once per frame
    void Update()
    {
        int ran = Random.Range(3, 4);
    }
    void CreateSphere(int value) //to create pool of tiles   
    {
        for (int i = 0; i < value; i++)
        {
            SphereStack.Push(Instantiate(sphereprefab));
            SphereStack.Peek().SetActive(false);
        }
    }

    public void GenerateSphere()
    {
        GameObject temp = SphereStack.Pop();
        temp.SetActive(true);
        temp.transform.position = this.transform.position + offset;
        //Instantiate(SphereStack.Pop(), transform.position + offset, Quaternion.identity);
    }
    public void pushtoStack(GameObject sphereobj)
    {
        SphereStack.Push(sphereobj);
        SphereStack.Peek().SetActive(false);
    }
}
