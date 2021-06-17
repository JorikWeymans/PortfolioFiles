//Created by Jorik Weymans 2021

using UnityEngine;
using UnityEngine.InputSystem;
using Utilities;
using Event = Observer.Event;

public sealed class PlayerMovement : MonoBehaviour
{
    [Header("Speeds")]
    [SerializeField] private float _ForwardMoveSpeed = 10.0f;
    [SerializeField] private float _BackwardsMoveSpeed = 5.0f;
    [SerializeField] private float _StrafeSpeed = 5.0f;

    [SerializeField] private Camera _Cam = null;
    private CharacterController _Controller = null;

    [Header("Jump Settings")]
    [SerializeField] [ReadOnly] private bool _JumpDown = false;
    [SerializeField] private float _JumpSpeed = 10.0f;
    [SerializeField] private float _ExtraGravity = 20.0f;
    private float y = 0.0f;

    //X is left and right, z is forward and backwards
    Vector3 _Motion = Vector3.zero;
    public Vector2 Velocity { get; private set; } = Vector2.zero;
    
    private void Awake()
    {
        _Controller = GetComponent<CharacterController>();
    }

    //called by input system
    private void OnMove(InputValue value)
    {
        Velocity = value.Get<Vector2>();
        _Motion = new Vector3(Velocity.x, 0, Velocity.y);

        if (Velocity.x < 0)
        {
            ServiceLocator.ObserverService.Notify(gameObject, Event.MoveA);

        }
        else if (Velocity.x > 0)
        {
            ServiceLocator.ObserverService.Notify(gameObject, Event.MoveD);
        }

        if (Velocity.y < 0)
        {
            ServiceLocator.ObserverService.Notify(gameObject, Event.MoveS);

        }
        else if (Velocity.y > 0)
        {
            ServiceLocator.ObserverService.Notify(gameObject, Event.MoveW);
        }
    }

    private void OnJump() => _JumpDown = true;
    private void OnJumpUp() => _JumpDown = false;
    private void FixedUpdate()
    { 
        Vector3 motionToUse = new Vector3();

        MoveWASD(ref motionToUse);
        Jump(ref motionToUse);

        _Controller.Move(motionToUse * Time.fixedDeltaTime);
    }

    private void MoveWASD(ref Vector3 motionToUse)
    {
        motionToUse += _Cam.transform.right * _Motion.x * _StrafeSpeed;
        motionToUse += _Cam.transform.forward * _Motion.z * ((_Motion.z > 0) ? _ForwardMoveSpeed : _BackwardsMoveSpeed);
    }

    private void Jump(ref Vector3 motionToUse)
    {
        if (_Controller.isGrounded && _JumpDown)
        {
            y = _JumpSpeed;
        }

        y -= _ExtraGravity * Time.fixedDeltaTime;
        motionToUse.y = y;
    }

    private void OnW_UP()
    {
        GameManager.GetInstance().Village.Health.LoseHealth(10);
    }
}