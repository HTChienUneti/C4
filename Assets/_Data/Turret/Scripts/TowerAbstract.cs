using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerAbstract : MyMonoBehaviour
{
    [SerializeField] protected TowerCtrl towerCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTowerCtrl();
    }
    protected virtual void LoadTowerCtrl()
    {
        if (this.towerCtrl != null) return;
        this.towerCtrl = transform.parent.GetComponent<TowerCtrl>();
        Debug.LogWarning(transform.name + " LoadTowerCtrl", gameObject);
    }
}
