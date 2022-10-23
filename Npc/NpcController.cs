using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NpcController : MonoBehaviour
{

    public float lookRadius = 10f;  // Detection range for player
                                    //public GameObject Body;
    Transform target;   // Reference to the player
    NavMeshAgent agent; // Reference to the NavMeshAgent
    public Vector3 DebugPostion;
    NpcScript npc;
   public  GameObject gamemanager;
    PlayerStats targetStats;
    private Animator anim;
    float CooldownTimer;
    float Cooldown = 2;//Cooldown to attack speed
    Vector3 lastpos;
    public AudioSource attackSound;
    public AudioSource hurtSound;
    public AudioSource deathSound;
    public AudioSource walkSound;
    // Use this for initialization


    void Awake()
    {
        Debug.Log("Hit");
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        npc = GetComponent<NpcScript>();
       // gamemanager = GameObject.Find("/GameManger");
        anim = GetComponent<Animator>();
        anim.SetFloat("Speed", 0f);
        targetStats = gamemanager.GetComponent<PlayerStats>();
    }


    // Update is called once per frame
    void Update()
    {
       

        bool targetingPlayer = false;

        //lastpos = this.transform.position;
        float distance = Vector3.Distance(target.transform.position, transform.position);

        if (distance <= lookRadius)//Player is in distance
        {
            FaceTarget();   // Make sure to face towards the target
            Walk();
            agent.SetDestination(PlayerManager.instance.player.transform.position);
            targetingPlayer = true;
            Debug.Log("Targeting");

        }
        if (distance <= agent.stoppingDistance)
        {
          
            if (targetStats != null)
            {

                if (Time.time > Cooldown+CooldownTimer)//Check if attack cooldown was reached
                {
                    Debug.Log("Attacking");

                    //Picks a random value which will trigger one of 2 attack animations
                    int randomInt = Random.Range(0, 2);
                    float randFloat = (float)randomInt;
                    Debug.Log("Attack: " + randFloat);

                    anim.SetFloat("Attack", randFloat);
                    anim.SetTrigger("AttackTr");

                    attackSound.Play();

                    CooldownTimer = Time.time + Cooldown;

                }

            }



            if (Time.time > CooldownTimer && targetingPlayer == false)
            {
                //MoveRandom();
                CooldownTimer = Time.time + Cooldown;
            }




        }

        // Show the lookRadius in editor
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, 10);

        }


    }
    public void MoveRandom()
    {
        // if target is outside navmesh it freaks out
        agent.SetDestination(RandomNavmeshLocation(10));//Will move randomly with in 10

        RandomFace();
    }
    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        DebugPostion = finalPosition;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 0))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    //Will look in random direction
    public void RandomFace()
    {

        Quaternion lookRotation = Random.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 8f);
    }
    public void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    //Play idle, walk or run animation based on npc speed
    public void Idle()
    {
        if (anim.GetFloat("Speed") != 0f)
        {
            anim.SetFloat("Speed", 0f);
        }
    }
    public void Walk()
    {
        if (walkSound.isPlaying == false)
        {
            walkSound.Play();
        }
        

        if (anim.GetFloat("Speed") != 0.5f)
        {
            anim.SetFloat("Speed", 0.5f);
        }
    }
    public void Run()
    {
        if (anim.GetFloat("Speed") != 1f)
        {
            anim.SetFloat("Speed", 1f);
        }
    }

    
    public void Attack()
    {
        targetStats.takeDmg(npc.npc.npcAttack);
    }
}
