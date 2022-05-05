using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team
{
    Player,
    Enemy
}

public class Unit : MonoBehaviour
{
    private float distanceEnemy = 1000f;
     private bool isEnemyDetected = false;
     private bool isAllyFront = false;
    private bool isAllyRear = false;
    [SerializeField] private bool isShootsOnTheGo = false;
    private MovementController movementController;

    public float DistanceEnemy { get => distanceEnemy; set => distanceEnemy = value; }
    public bool IsEnemyDetected { get => isEnemyDetected; set => isEnemyDetected = value; }
    public bool IsAllyFront { get => isAllyFront; set => isAllyFront = value; }
    public bool IsAllyRear { get => isAllyRear; set => isAllyRear = value; }

    private void Start()
    {
        movementController = GetComponent<MovementController>();
    }

    private void Update()
    {
        DefineMovement();
    }

    //private void DefineMovement()
    //{
    //    //не зря учили дискретку
    //    if (!IsAllyFront && !(IsEnemyDetected && !IsAllyRear))
    //    {
    //        movementController.StartMoving();
    //    }
    //    else
    //    {
    //        movementController.StopMoving();
    //    }
    //}

    private void DefineMovement()
    {
        //(!IsAllyFront && !(IsEnemyDetected && !IsAllyRear))
        //не зря учили дискретку
        if (!IsAllyFront && (!IsEnemyDetected || (IsEnemyDetected && (isShootsOnTheGo || !isShootsOnTheGo && IsAllyRear))))
        {
            movementController.StartMoving();
        }
        else
        {
            movementController.StopMoving();
        }
    }
}
