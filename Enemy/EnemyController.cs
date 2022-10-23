using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
	public float lookRadius = 10f;  // Detection range for player

	Transform target;   // Reference to the player
	NavMeshAgent agent; // Reference to the NavMeshAgent
						
	EnemyInfo npc;
	GameObject gamemanager;
	PlayerStats targetStats;
	public Animator anim;
	float CooldownTimer;
	float Cooldown = 2;//Cooldown to attack speed

	public AudioSource attackSound;
	// Use this for initialization
	void Start()
	{
		target = PlayerManager.instance.player.transform;
		agent = GetComponent<NavMeshAgent>();
		npc = GetComponent<EnemyInfo>();
		gamemanager = GameObject.Find("/GameManger");
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		
		// Distance to the target
		float distance = Vector3.Distance(target.position, transform.position);

		// If inside the lookRadius
		if (distance <= lookRadius)
		{
			// Move towards the target
			agent.SetDestination(target.position);
			anim.SetBool("walk", true);
			
			// If within attacking distance
			if (distance <= agent.stoppingDistance)
			{
			targetStats = gamemanager.GetComponent<PlayerStats>();
				if (targetStats != null)
				{

					if (Time.time > CooldownTimer)//Check if attack cooldown was reached
					{
						anim.SetBool("attack", true);
						attackSound.Play();
						targetStats.takeDmg(npc.attackvalue);
						CooldownTimer = Time.time + Cooldown;

                    }
                    else
                    {
						anim.SetBool("attack", false);
                    }
				}
				FaceTarget();   // Make sure to face towards the target
			}
        }
        else
        {
			anim.SetBool("walk", false);
		}
	}

	// Rotate to face the target
	void FaceTarget()
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}

	// Show the lookRadius in editor
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);

	}
}
