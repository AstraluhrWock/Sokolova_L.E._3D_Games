using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKControl : MonoBehaviour
{
    private float _currentHeadRotation;
    private float _headRotationSpeed = 0.1f;

    protected Animator animator;

    public bool ikActive = false;
    public Transform rightHandObject = null;
    public Transform lookAt = null;
    public Transform head = null;
    public float distance = 2;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK()
    {
        if (animator)
        {
            if (ikActive)
            {
                if (lookAt != null)
                {
                    if(head)
                    {
                        if(Vector3.Distance(head.position, lookAt.position) < distance)
                        {
                            animator.SetLookAtWeight(_currentHeadRotation);
                            animator.SetLookAtPosition(lookAt.position);
                            _currentHeadRotation += Time.deltaTime * _headRotationSpeed;

                            if(_currentHeadRotation > 1)
                            {
                                _currentHeadRotation = 1;
                            }
                        }
                        else
                        {
                            animator.SetLookAtWeight(_currentHeadRotation);
                            _currentHeadRotation -= Time.deltaTime * _headRotationSpeed;

                            if(_currentHeadRotation < 0)
                            {
                                _currentHeadRotation = 0;
                            }
                        }
                    }
      
                }
            }

            if (rightHandObject != null)
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObject.position);
                animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObject.rotation);
            }
        }
        else
        {
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
            animator.SetLookAtWeight(0);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
