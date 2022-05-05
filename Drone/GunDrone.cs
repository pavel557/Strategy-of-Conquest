using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDrone : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float reloading;
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private List<Transform> creationPoint;
    [SerializeField] private Link playerLink;
    [SerializeField] private bool playerIsFound = false;
    [SerializeField] private bool fireWhenOnBecameVisible = true;
    [SerializeField] private float distance = 25f;
    [SerializeField] private AudioSource gunAudio;
    [SerializeField] private ParticleSystem gunShotEffect;

    private Vector2 direction;
    private Transform player;

    public bool PlayerIsFound { get => playerIsFound; set => playerIsFound = value; }

    private void Start()
    {
        player = playerLink.ObjectLink.GetComponent<Transform>();
        StartCoroutine(Fire());
    }

    private void Update()
    {
        ControlTurret();
    }

    public void ControlTurret()
    {
        if (playerIsFound == true)
        {
            direction = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, angle), Time.deltaTime * rotateSpeed);
        }
        
    }

    private void CreateBullet()
    {
        for (int i=0; i<creationPoint.Count; i++)
        {
            GameObject bulletObj = Instantiate(bulletPref, creationPoint[i].position, transform.rotation);
            MovementController bulletÌÑ = bulletObj.GetComponent<MovementController>();
            Bullet bullet = bulletObj.GetComponent<Bullet>();
            bulletÌÑ.DirectionMovement = DirectionMovement();
            bullet.Team = Team.Enemy;
            gunAudio.Play();
            if (gunShotEffect != null)
                gunShotEffect.Play();
        }
    }

    private Vector2 DirectionMovement()
    {
        float y = 1f;
        float x = 1f;
        if ((transform.rotation.eulerAngles.z > 90) && (transform.rotation.eulerAngles.z < 270))
        {
            x = -1f;
            y = Mathf.Tan(transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * -1f;
        }
        if ((transform.rotation.eulerAngles.z < 90) || (transform.rotation.eulerAngles.z > 270))
        {
            x = 1f;
            y = Mathf.Tan(transform.rotation.eulerAngles.z * Mathf.Deg2Rad);
        }
        if (transform.rotation.eulerAngles.z == 90)
        {
            x = 0f;
            y = float.MaxValue;
        }
        if (transform.rotation.eulerAngles.z == 270)
        {
            x = 0f;
            y = float.MinValue;
        }

        Vector2 direction = new Vector2(x, y);
        direction.Normalize();
        return direction;
    }

    IEnumerator Fire()
    {
        while (true)
        {
            if ((PlayerIsFound == true)||((!fireWhenOnBecameVisible)&&(Vector3.Distance(player.position, transform.position)<distance)))
            {
                CreateBullet();
            }
            yield return new WaitForSeconds(reloading);
        }
    }
}
