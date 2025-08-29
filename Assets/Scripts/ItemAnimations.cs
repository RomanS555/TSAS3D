using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Move_player))]
public class ItemAnimations : MonoBehaviour
{
    [SerializeField] Animator animator;
    Rigidbody rb;
    Move_player movePlayer;
    void Start()
    {
        movePlayer = GetComponent<Move_player>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float axeX, axeZ;
        axeX = Input.GetAxis("Horizontal")* (!movePlayer.isMenu ? 1f : 0f);
        axeZ = Input.GetAxis("Vertical")* (!movePlayer.isMenu ? 1f : 0f);
        Vector2 axe = new Vector2(axeX, axeZ);
        animator.SetBool("Walk", movePlayer.isGround && axe.magnitude > 0);

    }
    public void Punch()
    {
        animator.Play("Punch",-1, 0f);
               
    }
    public void Fire()
    {
        animator.Play("Fire",-1, 0f);
    }
    

}
