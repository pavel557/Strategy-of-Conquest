using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour
{
    private AsyncOperation asyncOperation;
    [SerializeField] private GameObject menuBlock;

    public void StartL(int number)
    { 
        menuBlock.SetActive(true);
        asyncOperation = SceneManager.LoadSceneAsync(number);

    }
}
