using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class TowerTargeting : TowerAbstract
{
    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected SphereCollider _collider;
    [SerializeField] protected float distance;
    [SerializeField] protected float distanceMin = Mathf.Infinity;
    [SerializeField] protected EnemyCtrl nerest;
    public EnemyCtrl Nerest => nerest;
    [SerializeField] protected List<EnemyCtrl> enemies = new();
    protected virtual void FixedUpdate()
    {
        this.Targeting();
    }
    protected virtual void Targeting()
    {
        this.FindNereat();
    }
    protected virtual void FindNereat()
    {
        if (this.enemies.Count <= 0) return;
        foreach(EnemyCtrl enemyCtrl in this.enemies)
        {
            this.distance = Vector3.Distance(transform.position,enemyCtrl.transform.position);
            if(this.distance < this.distanceMin)
                this.nerest = enemyCtrl;
        }

    }
    protected void OnTriggerEnter(Collider other)
    {
        this.AddEnemy(other);
    }
    protected void OnTriggerExit(Collider other)
    {
        this.RemoveEnemy(other);
    }

    protected virtual void AddEnemy(Collider collider)
    {
        if (!collider.transform.name.Equals(Const.TOWER_TARGETABLE)) return;
        this.enemies.Add(collider.transform.parent.GetComponent<EnemyCtrl>());  
    }
    protected virtual void RemoveEnemy(Collider collider)
    {
        if (this.enemies.Count <= 0) return;
        for(int i=0;i<this.enemies.Count;i++)
        {
            if (collider.transform.parent != this.enemies[i].transform) continue;
            this.enemies.RemoveAt(i);
        }
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.useGravity = false;
        Debug.LogWarning(transform.name + " LoadRigidbody", gameObject);

    }
    protected virtual void LoadCollider()
    {
        if (this._collider != null) return;
        this._collider = GetComponent<SphereCollider>();
        this._collider.radius = 5f;
        this._collider.isTrigger = true;
        Debug.LogWarning(transform.name + " LoadCollider", gameObject);
    }
}
