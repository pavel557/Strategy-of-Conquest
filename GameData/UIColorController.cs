using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIColorController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float space;
    private bool isSpace = false;

    public void Update()
    {
        if ((transform.position.y >= space) && (!isSpace))
        {
            animator.SetBool("isSpace", true);
            isSpace = animator.GetBool("isSpace");
        }
        else if ((transform.position.y < space) && (isSpace))
        {
            animator.SetBool("isSpace", false);
            isSpace = animator.GetBool("isSpace");
        }
    }
}
