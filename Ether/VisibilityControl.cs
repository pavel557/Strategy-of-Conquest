using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityControl : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnBecameVisible()
    {
        Debug.Log("Visible");
        if (spriteRenderer.enabled == false)
        {
            spriteRenderer.enabled = true;
        }
    }

    private void OnBecameInvisible()
    {
        Debug.Log("Invisible");
        if (spriteRenderer.enabled == true)
        {
            spriteRenderer.enabled = false;
        }
    }
}
