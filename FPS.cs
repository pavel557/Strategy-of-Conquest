using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FPS : MonoBehaviour
{
    [SerializeField] private Text text;
    private float fps;
    void Start()
    {
        InvokeRepeating(nameof(GetFPS), 1, 1);
    }

    public void GetFPS()
    {
        fps = 1f / Time.unscaledDeltaTime;
        text.text = "" + fps.ToString("0.0");
    }
}
