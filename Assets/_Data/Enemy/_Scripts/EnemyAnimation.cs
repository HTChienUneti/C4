using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class EnemyAnimation : EnemyAbtract
{
    [SerializeField] protected Animator animator;
    public Animator Animator => animator;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAnimator();
    }
    protected virtual void FixedUpdate()
    {
        this.Handle();
    }
    protected virtual void Handle()
    {
        if (this.EnemyCtrl.EnemyMoving.IsMoving) this.Moving();
        else this.Idel();
    
    }
    protected virtual void Moving() 
    {
        this.animator.SetBool("isMoving", true);
    }
    protected virtual void Idel()
    {
        this.animator.SetBool("isMoving", false);
    }
    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = GetComponent<Animator>();
        Debug.LogWarning(transform.name + " LoadAnimator", gameObject);
    }
}
