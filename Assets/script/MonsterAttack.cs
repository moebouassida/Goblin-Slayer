using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
	public int attackDamage = 20;

	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;

	public AudioClip[] playlist;
	public AudioSource audioSource;

    private void Start()
    {
		audioSource.clip = playlist[0];
    }

    public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<PlayerStatus>().TakeDamage(attackDamage);
			audioSource.Play();
		}
	}

	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}
