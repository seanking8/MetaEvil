using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtDuringState : StateMachineBehaviour
{
    public NpcController NPC;
    public BossController Boss;
    public bool knightHasHit;
    public bool trollHasHit;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        knightHasHit = false;
        trollHasHit = false;
        if (!animator.gameObject.name.Contains("Troll"))
        {
            
        Boss = animator.gameObject.GetComponent<BossController>();
        }
        else
        {
        NPC = animator.gameObject.GetComponent<NpcController>();
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float progress = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (animator.gameObject.name == "KnightPrefab")
        {
            if (progress >= 0.71f && progress <= 0.75f && knightHasHit == false)
            {
                Debug.Log("Making contact with player");
                Boss.Hurt();
                knightHasHit = true;
            }
        } 
        else
            {
                if (progress >= 0.33f && progress <= 0.36f && trollHasHit == false)
                {
                    Debug.Log("Making contact with player");
                    NPC.Attack();
                    trollHasHit = true;
                }
            }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}

}
