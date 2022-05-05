using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtilleryBullet : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    [SerializeField] private Team team;
    [SerializeField] private GameObject effect;

    internal Team Team { get => team; set => team = value; }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(gameObject);
        GameObject Object = Instantiate(explosion, transform.position, Quaternion.identity);
        Bullet bullet = Object.GetComponent<Bullet>();
        if (bullet != null)
            bullet.Team = Team;
        if (effect != null)
            Instantiate(effect, transform.position, Quaternion.identity);
    }
}
