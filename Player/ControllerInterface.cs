using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInterface : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Animator animator2;
    [SerializeField] private float space;
    private bool isSpace = false;

    public void Update()
    {
        if ((transform.position.y >= space)&&(!isSpace))
        {
            animator.SetBool("isSpace", true);
            animator2.SetBool("isSpace", true);
            isSpace = animator.GetBool("isSpace");
        }
        else if ((transform.position.y < space) && (isSpace))
        {
            animator.SetBool("isSpace", false);
            animator2.SetBool("isSpace", false);
            isSpace = animator.GetBool("isSpace");
        }
    }
}
