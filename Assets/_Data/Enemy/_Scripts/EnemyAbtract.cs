using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbtract : MyMonoBehaviour
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl EnemyCtrl => enemyCtrl;    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.loadEnemyCtrl();
    }
    protected virtual void loadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.LogWarning(transform.name + " LoadEnemyCtl", gameObject);
    }
}
