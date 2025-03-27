using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : EnemyAbtract
{
    [SerializeField] protected GameObject target;
    [SerializeField] protected Path path;
   // [SerializeField] protected int pathIndex = 0;
    [SerializeField] protected string pathName = "Path_1";
    [SerializeField] protected Point currentPoint;
  
     [SerializeField] protected float distancePoint;
    [SerializeField] protected float maxDistance=1;
    [SerializeField] protected bool isFinish = false;
    [SerializeField] protected bool isMoving = false;
    public bool IsMoving => isMoving;
    [SerializeField] protected bool canMove = false;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTarget();
       // this.LoadPath();
        
    }
    protected virtual void Start()
    {
        this.LoadPath();
    }
    protected void FixedUpdate()
    {
        this.Moving();
        this.CheckMoving();

    }
    protected virtual void LoadTarget()
    {
        if (this.target != null) return;
        this.target = GameObject.Find("TargetMoving");
        Debug.LogWarning(transform.name + " LoadTarget", gameObject);
    }
    protected virtual void CheckMoving()
    {
        if (this.enemyCtrl.Nav.velocity.magnitude > 0.1f) this.isMoving = true;
        else this.isMoving=false;                                
    }
    protected virtual void Moving()
    {
        if (!this.canMove)
        {
            this.enemyCtrl.Nav.isStopped = true;
            return;
        }
        this.FindNextPoint();
        if (currentPoint == null || this.isFinish)
        {
            this.enemyCtrl.Nav.isStopped = true;
            return;
        }
        this.enemyCtrl.Nav.isStopped = false;
        this.enemyCtrl.Nav.SetDestination(this.currentPoint.transform.position);
    }
    protected virtual void FindNextPoint()
    {
        if(this.currentPoint == null && !this.isFinish)
        {
            this.currentPoint = this.path.Points[0];
            return;
        }
        this.distancePoint = Vector3.Distance(transform.position, this.currentPoint.transform.position);
        if (this.distancePoint > this.maxDistance) return;
        this.currentPoint = this.currentPoint.NextPoint;
        if(this.currentPoint == null)
            this.isFinish = true;
    }
    protected virtual void LoadPath()
    {
        if(this.path != null) return;
        this.path = PathManager.Instance.GetPath(this.pathName);
        Debug.LogWarning(transform.name + " LoadPath", gameObject);
    }    

}
