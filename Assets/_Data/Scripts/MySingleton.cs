using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class MySingleton<T> : MyMonoBehaviour where T : MyMonoBehaviour
{ 
    protected static T instance;
    public static T Instance
    {
        get
        {
            if(instance ==null)
            {
                Debug.LogError("Instance is null");
                return null; 
            }
            return instance;    
        }
    }

    protected override void Awake()
    {
        base.Awake();
        this.LoadInstance();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
       // this.LoadInstance();
    }
    protected virtual void LoadInstance()
    {
        if(instance != null)
        {
            Debug.LogError("There are already have a instance",gameObject);
            return;
        }
        else
        {
            instance = this as T;
        }
    }
}
