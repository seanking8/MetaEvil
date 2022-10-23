using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BossController : MonoBehaviour
{

    Transform target;   // Reference to the player
    NavMeshAgent agent; // Reference to the NavMeshAgent
    NpcScript npc;
    GameObject gamemanager;
    PlayerStats targetStats;
    public Animator anim;
    float CooldownTimer;
    public float Cooldown = 2f;//Cooldown to attack speed
    public AudioSource attackSound;
    public AudioSource hurtSound;
    public AudioSource deathSound;
    public AudioSource walkSound;
    public AudioSource spellSound;
    public bool isbossActive = false;
    public Transform SpellOrgin;//For spell

    public float spellSpeed = 50;
    public Rigidbody spell;
    public bool isranged;


    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        npc = GetComponent<NpcScript>();
        gamemanager = GameObject.Find("/GameManger");
        anim = GetComponent<Animator>();
        isbossActive = false;
        Idle();
    }


    // Update is called once per frame
    void Update()
    {
        if (isbossActive == false && isranged == false)//If boss stage is active boss will always target player.
        {
            return;
        }

        float distance = Vector3.Distance(target.position, transform.position);
        FaceTarget();   // Make sure to face towards the target

        if (isranged == true)
        {

            RaycastHit hit;
            if (distance <= 150)
            {
                if (Time.time > Cooldown + CooldownTimer)//Check if attack cooldown was reached
                {
                    spellSound.Play();
                    Attack();
                    CooldownTimer = Time.time;
                    Fire();
                }

            }

        }
        else
        {
            agent.SetDestination(PlayerManager.instance.player.transform.position);

            Walk();
            if (distance <= agent.stoppingDistance)
            {
                targetStats = gamemanager.GetComponent<PlayerStats>();
                if (targetStats != null)
                {
                    if (Time.time > Cooldown + CooldownTimer)//Check if attack cooldown was reached
                    {
                        CooldownTimer = Time.time;

                        Attack();

                    }

                }


            }
        }


    }

    public void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    //Play idle or walking animation based on if boss is moving or not
    public void Idle()
    {
        if (gameObject.name == "Wizard")
        {
            anim.SetFloat("Speed", 0.75f);
        }
        else
        {
            anim.SetFloat("Speed", 1);
        }
    }
    public void Walk()
    {
        if (gameObject.name == "Wizard")
        {
            anim.SetFloat("Speed", 0.75f);
        }
        else
        {
            if (walkSound.isPlaying == false)
            {
                walkSound.Play();
            }
            anim.SetFloat("Speed", 1);
        }
    }

    //Picks a random float value which will trigger one of 4 attack animations
    public void Attack()
    {
        if (gameObject.name != "Wizard")
        {
            attackSound.Play();
            anim.SetFloat("Attack", Random.Range(0f, 1f));
            targetStats.takeDmg(npc.npc.npcAttack);
            CooldownTimer = Time.time + Cooldown;
        }
        anim.SetTrigger("AttackTr");
    }

    //Fires magic fireball. (Called during the animation)
    public void Fire()
    {
        Debug.Log("Firing");
        Rigidbody bulletClone = (Rigidbody)Instantiate(spell, SpellOrgin.position, SpellOrgin.rotation);
        bulletClone.velocity = SpellOrgin.TransformDirection(Vector3.forward) * spellSpeed;
    }

    public void Hurt()
    {
        targetStats.takeDmg(npc.npc.npcAttack);
    }
}

