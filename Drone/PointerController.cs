using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour
{

    private Vector2 direction;
    private Transform enemyDrone;

    public Transform EnemyDrone { get => enemyDrone; set => enemyDrone = value; }

    private void Update()
    {
        ControlTurret();
    }

    public void ControlTurret()
    {
        if (enemyDrone != null)
        {
            direction = new Vector2(enemyDrone.position.x - transform.position.x, enemyDrone.position.y - transform.position.y);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //Debug.Log(quaternion.eulerAngles.x + " " + quaternion.eulerAngles.y + " " + quaternion.eulerAngles.z);
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }

    }
}
