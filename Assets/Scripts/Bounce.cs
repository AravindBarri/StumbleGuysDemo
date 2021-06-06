using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
	public float force = 10f; //Force 10000f
	private Vector3 hitDir;

	void OnCollisionEnter(Collision collision)
	{
			if (collision.gameObject.tag == "Player")
			{
				collision.gameObject.GetComponent<PlayerMovement>().BouncePlayer(force);
			}
	}

}
