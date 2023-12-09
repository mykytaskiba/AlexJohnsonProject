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

        /*
        if (Mathf.Abs(velocity.y) > 0.05f)
        {
            animator.Play("Fall");
            return;
        }*/

        if (velocity.magnitude > 0.05f)
        {
            animator.Play("Walk");
            return;
        }


        animator.Play("Idle");
        return;

    }

    bool overrideAnimation;
    string overrideName;

    public void OverrideAnimation(string name)
    {
        overrideAnimation = true;
        overrideName = name;
    }

    bool playOnce;
    bool hasPlayed;

    public void PlayOnce(string name)
    {
        hasPlayed = false;
        playOnce = true;
        overrideName = name;
    }

    public void ClearOverride()
    {
        overrideAnimation = false;
    }

    private void Update()
    {
        if (playOnce)
        {
            if (!hasPlayed)
            {
                animator.Play(overrideName);
                hasPlayed = true;
            }
            return;
        }

        if (overrideAnimation)
        {
            animator.Play(overrideName);
        }
        else
        {
            UpdateAnimator();
        }
    }
}
