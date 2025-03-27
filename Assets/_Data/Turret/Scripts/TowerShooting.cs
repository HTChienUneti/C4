using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class TowerShooting : TowerAbstract
{
    [SerializeField] protected EnemyCtrl target;
    [SerializeField] protected Vector3 lookAtDefault= Vector3.zero;
    protected virtual void FixedUpdate()
    {
        this.LookAtTarget();
    }
    protected virtual void LookAtTarget()
    {
        this.target = this.towerCtrl.TowerTargeting.Nerest;
        if (this.target == null)
        {
            this.towerCtrl.Rotator.localRotation = Quaternion.identity;
            return; 
        }
       
        this.towerCtrl.Rotator.LookAt(this.target.TowerTargetAble.transform.position);
    }
}
