using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class HeroMovement : StateMachineBehaviour
{

    Transform otherHero;
    Rigidbody2D rb;
    public float moveSpeed = 1f;
    public float attackRange = 3f;
    Vector2 startPos;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        otherHero = GameObject.FindGameObjectWithTag("Hero1").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        startPos = new Vector2(rb.position.x, rb.position.y);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        Vector2 target = new Vector2(otherHero.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if(Vector2.Distance(otherHero.position,rb.position) <= attackRange){

            animator.SetTrigger("Attack");

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        Vector2 newPos = Vector2.MoveTowards(rb.position, startPos, moveSpeed * Time.fixedDeltaTime * 3);
        rb.MovePosition(newPos);

    }

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
