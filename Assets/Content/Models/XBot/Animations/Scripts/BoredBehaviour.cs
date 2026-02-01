using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoredBehaviour : StateMachineBehaviour
{
    [SerializeField]
    private float timeUntilBored = 8.0f;
    [SerializeField]
    private int numberOfBoredAnimations = 2;

    private bool isBored;
    private float idleTime;
    private int boredAnimation;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ResetIdle();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!isBored) {
            idleTime += Time.deltaTime;

            if (idleTime > timeUntilBored && stateInfo.normalizedTime % 1 < 0.02f) {
                isBored = true;
                boredAnimation = Random.Range(1, numberOfBoredAnimations + 1);

                Debug.Log("BORED");
            }
        }
        else if (stateInfo.normalizedTime % 1 > 0.98) {
            //ResetIdle();
        }

        animator.SetFloat("BoredAnimation", boredAnimation, 0.2f, Time.deltaTime);
    }

    private void ResetIdle()
    {
        isBored = false;
        idleTime = 0;
        boredAnimation = 0;
    }
}
