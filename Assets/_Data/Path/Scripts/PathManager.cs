using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PathManager : MySingleton<PathManager> 
{
    [SerializeField] protected List<Path> paths = new();
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPath();
    }
    public Path GetPath(int index)
    {
        return this.paths[index];
    }
    public Path GetPath(string pathName)
    {
        foreach(Path path in this.paths)
        {
            if (path.transform.name.Equals(pathName)) return path;
        }
        return null;
    }
    protected virtual void LoadPath()
    {
        if (this.paths.Count > 0) return;
        foreach(Transform child in transform)
        {
            Path path = child.GetComponent<Path>();
            this.paths.Add(path);
            path.LoadPoint(); 
            
        }
        Debug.LogWarning(transform.name + " LoadPath", gameObject);
    }

}
