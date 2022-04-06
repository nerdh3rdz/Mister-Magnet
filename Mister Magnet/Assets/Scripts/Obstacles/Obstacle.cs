using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    protected Animator animator;

    public bool IsOff = false;

    protected virtual void Start() => animator = GetComponent<Animator>();

    protected virtual void Update() => animator.SetBool("IsOff", IsOff);

    public void Deactivate() => IsOff = true;

    public void Activate() => IsOff = false;
}
