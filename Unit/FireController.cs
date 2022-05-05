using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class FireController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private float reloading;
    [SerializeField] private float miniReloading;
    [SerializeField] private Vector2 direction;
    [SerializeField] private Transform creationPoint;
    [SerializeField] private bool IsArtillery;
    [SerializeField] private bool IsHeavyArtillery;
    [SerializeField] private bool IsTurret;
    [SerializeField] private AudioSource gunAudio;
    [SerializeField] private ParticleSystem gunShotEffect;
    private Unit unit;
    private Health health;

    private void Start()
    {
        unit = GetComponent<Unit>();
        health = GetComponent<Health>();
        StartCoroutine(Fire());
    }

    private float CalculateSpeedBullet()
    {
        float distance = unit.DistanceEnemy;
        if ((IsArtillery || IsHeavyArtillery) && !IsTurret)
        {
            distance += 3;
        }
        float speed = Mathf.Sqrt((distance*Mathf.Abs(Physics2D.gravity.y))/(2*Mathf.Sin(direction.y)* Mathf.Cos(direction.y)));
        return speed;
    }

    private void CreateBullet()
    {
        GameObject bulletObj = Instantiate(bulletPref, creationPoint.position, Quaternion.identity);
        MovementController bulletÌÑ = bulletObj.GetComponent<MovementController>();
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        bulletÌÑ.DirectionMovement = direction;
        bullet.Team = health.Team;
        if (health.Team == Team.Enemy)
        {
            bulletObj.transform.localScale = new Vector3(bulletObj.transform.localScale.x * (-1f), bulletObj.transform.localScale.y, bulletObj.transform.localScale.z);
        }
        if (gunAudio != null)
            gunAudio.Play();
        if (gunShotEffect != null)
            gunShotEffect.Play();
    }

    private void CreateArtilleryBullet()
    {
        GameObject bulletObj = Instantiate(bulletPref, creationPoint.position, Quaternion.identity);
        MovementController bulletÌÑ = bulletObj.GetComponent<MovementController>();
        ArtilleryBullet bullet = bulletObj.GetComponent<ArtilleryBullet>();
        bulletÌÑ.DirectionMovement = direction;
        bulletÌÑ.BaseSpeed = CalculateSpeedBullet();
        bullet.Team = health.Team;
        if (gunAudio != null)
            gunAudio.Play();
        if (gunShotEffect != null)
            gunShotEffect.Play();
    }

    IEnumerator Fire()
    {
        while (true)
        {
            if (unit.IsEnemyDetected)
            {
                if (IsArtillery==true)
                {
                    CreateArtilleryBullet();
                }
                else if (IsHeavyArtillery == true)
                {
                    for (int i=0; i<3; i++)
                    {
                        if (unit.IsEnemyDetected)
                        {
                            CreateArtilleryBullet();
                        }
                        
                        yield return new WaitForSeconds(miniReloading);
                    }
                }
                else
                {
                    CreateBullet();
                }
            }
            yield return new WaitForSeconds(reloading);
        }
    }


}
