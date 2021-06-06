using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
	public float speed = 1.5f;
	public float limit = 75f; //Limit in degrees of the movement
	private float random = 0;
	public float force = 10;
	public float angle;

	// Start is called before the first frame update
	void Awake()
    {
			random = Random.Range(0f, 5f);
	}

    // Update is called once per frame
    void Update()
    {
		angle = limit * Mathf.Sin(Time.time + random * speed);
		transform.localRotation = Quaternion.Euler(0, 0, angle);
	}

	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			collision.gameObject.GetComponent<PlayerMovement>().BouncePendulum(force,angle);
		}
	}
}
