using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField] protected float lifetime;
    [SerializeField] private Team team;
    

    public int Damage { get => damage;}
    public Team Team { get => team; set => team = value; }

    private void Start()
    {
        StartCoroutine(DestroyTime());
    }

    IEnumerator DestroyTime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    
}
