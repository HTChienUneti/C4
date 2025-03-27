using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Path : MyMonoBehaviour
{
    [SerializeField] protected List<Point> points;
    public List<Point> Points => points;    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPoint();
    }
    public virtual void LoadPoint()
    {
        if (this.points.Count > 0) return;
        foreach (Transform child in transform)
        {
            Point point = child.GetComponent<Point>();
            this.points.Add(point);
            point.LoadNextPoint();
        }
        Debug.LogWarning(transform.name + " LoadPath", gameObject);
    }
}
