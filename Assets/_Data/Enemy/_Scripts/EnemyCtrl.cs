using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : MyMonoBehaviour
{
    [SerializeField] protected NavMeshAgent nav;
    public NavMeshAgent Nav => nav;
    [SerializeField] protected Transform model;
    [SerializeField] protected EnemyMoving enemyMoving;
    public EnemyMoving EnemyMoving => enemyMoving;
    [SerializeField] protected TowerTargetAble towerTargetAble;
    public TowerTargetAble TowerTargetAble => towerTargetAble;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadNavMeshAgent();
        this.LoadModel();
        this.LoadEnemyMoving();
        this.LoadTowerTargetAble();
    }


    protected virtual void LoadTowerTargetAble()
    {
        if (this.towerTargetAble!= null) return;
        this.towerTargetAble = GetComponentInChildren<TowerTargetAble>();
        this.towerTargetAble.transform.localPosition = new Vector3(0, 0.5f, 0);
        Debug.LogWarning(transform.name + " LoadTowerTargetAble", gameObject);
    }

    protected virtual void LoadEnemyMoving()
    {
        if (this.enemyMoving!= null) return;
        this.enemyMoving = GetComponentInChildren<EnemyMoving>();
        Debug.LogWarning(transform.name + " LoadEnemyMoving", gameObject);
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.LogWarning(transform.name + " LoadModel", gameObject);
    }
    protected virtual void LoadNavMeshAgent()
    {
        if (this.nav != null) return;
        this.nav = GetComponent<NavMeshAgent>();
        this.nav.speed = 3;
        this.nav.angularSpeed = 200f;
        this.nav.acceleration = 20f;
        Debug.LogWarning(transform.name + " LoadNavMeshAgent", gameObject);
    }
}
