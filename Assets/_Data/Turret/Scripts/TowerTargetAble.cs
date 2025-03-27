using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class TowerTargetAble : MyMonoBehaviour
{
    [SerializeField] protected CapsuleCollider _collider;
    public virtual void OnTarget(string towerName)
    {
        Debug.Log(transform.name + " On target by "+towerName);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
    }
    protected virtual void LoadCollider()
    {
        if (this._collider != null) return;
        this._collider = GetComponent<CapsuleCollider>();
        this._collider.radius =.5f;
        this._collider.height = 1.7f;
        this._collider.center = new Vector3(0, 0.9f, 0);
        this._collider.isTrigger = true;
        Debug.LogWarning(transform.name + " LoadCollider", gameObject);
    }
}
