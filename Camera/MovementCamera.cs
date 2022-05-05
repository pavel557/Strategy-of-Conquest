using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCamera : MonoBehaviour
{
    //[SerializeField] private Transform leftBorder;
    //[SerializeField] private Transform rightBorder;
    //[SerializeField] private Transform upBorder;
    //[SerializeField] private Transform downBorder;
    //[SerializeField] private float maxDistance = 30f;

    [SerializeField] private Transform player;
    //[SerializeField] private List<Transform> enemyTransforms;
    //[SerializeField] private Transform targetEnemyTransforms;

    //[SerializeField] private Camera cam;

    //private Vector3 positionCamera;
    //private float sizeCamera;
    //private float speed = 15f;

    //public List<Transform> EnemyTransforms { get => enemyTransforms; set => enemyTransforms = value; }
    //public Transform TargetEnemyTransforms { get => targetEnemyTransforms; set => targetEnemyTransforms = value; }

    public void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

    //private void Start()
    //{
    //    //StartCoroutine(VisibilityCheck());
    //    StartCoroutine(TargetSelection());
    //}

    //private void Update()
    //{
    //    if (targetEnemyTransforms == null)
    //    {
    //        sizeCamera = 3.5f;
    //        positionCamera = new Vector3(player.position.x, player.position.y, transform.position.z);
    //    }
    //    else
    //    {
    //        Vector3 position = new Vector3((targetEnemyTransforms.position.x + player.position.x)/2f, (targetEnemyTransforms.position.y + player.position.y)/2f, transform.position.z);
    //        positionCamera = position;
    //        if (Vector3.Distance(targetEnemyTransforms.position, player.position) > 5f)
    //        {
    //            sizeCamera = Vector3.Distance(targetEnemyTransforms.position, player.position) * 0.8f;
    //        }

    //    }
    //    CameraControl();
    //}

    //private void CameraControl()
    //{
    //    transform.position = Vector3.MoveTowards(transform.position, positionCamera, speed * Time.fixedDeltaTime/2.5f);
    //    cam.orthographicSize = Mathf.MoveTowards(cam.orthographicSize, sizeCamera, speed * Time.deltaTime / 5f);
    //}

    //IEnumerator VisibilityCheck()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(1f);
    //        if (targetEnemyTransforms != null)
    //        {
    //            if (Vector3.Distance(player.transform.position, targetEnemyTransforms.position) > maxDistance)
    //            {
    //                enemyTransforms.Remove(targetEnemyTransforms);
    //                targetEnemyTransforms = null;
    //            }
    //        }
    //        //if (enemyTransforms.Count > 0)
    //        //{
    //        //    for (int i = 0; i < enemyTransforms.Count; i++)
    //        //    {
    //        //        if (Vector3.Distance(player.transform.position, enemyTransforms[i].position) > maxDistance)
    //        //        {
    //        //            enemyTransforms.Remove(enemyTransforms[i]);
    //        //        }
    //        //    }
    //        //}
    //    }
    //}

    //public void RemoveEnemyTransform(Transform enemyTransform)
    //{
    //    enemyTransforms.Remove(enemyTransform);
    //}

    //IEnumerator TargetSelection()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(1f);
    //        if (enemyTransforms.Count > 0)
    //        {
    //            targetEnemyTransforms = enemyTransforms[0];
    //            if (enemyTransforms.Count > 0)
    //            {
    //                for (int i = 1; i < enemyTransforms.Count; i++)
    //                {
    //                    if (Vector3.Distance(player.transform.position, targetEnemyTransforms.position) > Vector3.Distance(player.transform.position, enemyTransforms[i].position))
    //                    {
    //                        targetEnemyTransforms = enemyTransforms[i];
    //                    }
    //                    yield return new WaitForEndOfFrame();
    //                }
    //            }

    //        }
    //    }
    //}
}
