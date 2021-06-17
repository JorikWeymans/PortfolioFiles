//Created by Jorik Weymans 2021

using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Animator))]
public sealed class PlayerAnimatorController : MonoBehaviour
{
    private PlayerMovement _Movement = null;
    private Animator _AniController = null;
    private void Awake()
    {
        _Movement = GetComponent<PlayerMovement>();
        _AniController = GetComponent<Animator>();
    }
    private void Update()
    {
        _AniController.SetFloat("_ForwardVel", _Movement.Velocity.y);
        _AniController.SetFloat("_SidewaysVel", _Movement.Velocity.x);
    }

    public void StartAttack()
    {
        _AniController.SetBool("_IsAttacking", true);
    }

    public void StopAttack()
    {
        _AniController.SetBool("_IsAttacking", false);
    }

    //called with gameobject::SendMessage()
    public void DoHeavyAttack()
    {
        _AniController.SetTrigger("_DoHeavyAttack");
    }

}