using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCtrl : MyMonoBehaviour
{
    [SerializeField] protected Transform rotator;
    public Transform Rotator => rotator;
    [SerializeField] protected Transform model;
    public Transform Model => model;
    [SerializeField] protected TowerTargeting towerTargeting;
    public TowerTargeting TowerTargeting => towerTargeting;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
        this.LoadTowerTargeting();  
    }
    protected virtual void LoadTowerTargeting()
    {
        if (this.towerTargeting != null) return;
        this.towerTargeting = GetComponentInChildren<TowerTargeting>();
        Debug.LogWarning(transform.name + "LoadTowerTargeting", gameObject);
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        this.rotator = this.model.Find("Rotator");
        Debug.LogWarning(transform.name + " LoadModel", gameObject);
    }
}
