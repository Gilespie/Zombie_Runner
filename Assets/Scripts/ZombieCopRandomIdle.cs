using UnityEngine;

public class ZombieCopRandomIdle : StateMachineBehaviour
{
    [SerializeField] private int _Chance = 5;
    [SerializeField] private int _agonyChance = 5;
    [SerializeField] private int _currentChance;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int chance = Random.Range(1, 101);
        _currentChance = chance;

        if (chance <= _Chance)
        {
            animator.SetInteger("IdleSelect", 3);
        }
        else if(chance > _Chance && chance <= _agonyChance)
        {
            animator.SetInteger("IdleSelect", 2);
        }
        else
        {
            animator.SetInteger("IdleSelect", 1);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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