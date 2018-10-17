using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
	{
		var health = collision.gameObject.GetComponent<Health>();
		if (health != null)
		{
			health.TakeDamage(10);
		}

		Destroy(gameObject, 2.0f);
	}
}