using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MyMonoBehaviour
{
    [SerializeField] protected Point nextPoint;
    public Point NextPoint => nextPoint;    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadNextPoint();
    }
    public virtual void LoadNextPoint()
    {
        if (this.nextPoint != null) return;
        int indexSelf = transform.GetSiblingIndex();
        if (indexSelf == transform.parent.childCount-1) this.nextPoint = null;
        else  this.nextPoint = transform.parent.GetChild(++indexSelf).GetComponent<Point>();
    }
    
}
