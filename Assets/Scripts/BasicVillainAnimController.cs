using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicVillainAnimController : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        SuperCharsController.AttackAnim += Attack;
    }
    public void Attack()
    {
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }
    }
}
