using UnityEngine;
using System.Collections;

public class HeroKnight : MonoBehaviour {


    private Animator            m_animator;


    private void Awake()
    {
        SuperCharsController.AttackAnim += HeroAttack;
    }

    // Use this for initialization
    void Start ()
    {
        m_animator = GetComponent<Animator>();


    }

    // Update is called once per frame
   

    // Animation Events
    // Called in slide animation.
    
    /// <summary>
    /// The Civilian
    /// i am using asset animations for my usage
    /// </summary>
    public void HeroAttack()
    {
        m_animator.SetTrigger("Attack" + Random.Range(1,3));
    }
}
