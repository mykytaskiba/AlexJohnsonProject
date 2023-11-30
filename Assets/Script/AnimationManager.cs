using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] Rigidbody targetRigidbody;

    void UpdateAnimator()
    {

        Vector3 velocity = targetRigidbody.velocity;

        if (Mathf.Abs(velocity.y) > 0.05f)
        {
            animator.Play("Fall");
            return;
        }

        if (velocity.magnitude > 0.05f)
        {
            animator.Play("Walk");
            return;
        }


        animator.Play("Idle");
        return;

    }

    private void Update()
    {
        UpdateAnimator();
    }
}
