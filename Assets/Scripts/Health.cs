using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour 
{
	public const int maxHealth = 100;
	public bool destroyOnDeath;

	[SyncVar(hook = "ChangeHealthBar")]
	public int currentHealth = maxHealth;
	public RectTransform healthBar;

	public void TakeDamage(int amount)
	{
		if (!isServer)
			return;
		
		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			if (destroyOnDeath) {
				Destroy(gameObject);
			}
			currentHealth = maxHealth;
			RpcRespawn();
		}
	}

	void ChangeHealthBar(int current) {
		healthBar.sizeDelta = new Vector2(current, healthBar.sizeDelta.y);
	}

	/* CLientRpc : Server to client */
	[ClientRpc]
	void RpcRespawn()
	{
		if (isLocalPlayer) {
			transform.position = Vector3.zero;
		}
	}
}