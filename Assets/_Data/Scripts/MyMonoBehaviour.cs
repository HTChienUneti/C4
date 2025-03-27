using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyMonoBehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponent();
    }
    protected virtual void Awake()
    {
        this.LoadComponent();
       
    }
    protected virtual void LoadComponent()
    {
        this.ResetValue();
    }
    protected virtual void ResetValue()
    {

    }
}
