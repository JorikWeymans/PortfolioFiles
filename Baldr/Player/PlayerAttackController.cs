//Created by Jorik Weymans 2021

using Utilities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerAnimatorController))]
public sealed class PlayerAttackController : MonoBehaviour, ISerializationCallbackReceiver
{
    [SerializeField] [ReadOnly] private int _AttackCombo = 1;
    [SerializeField] private int _ComboCount = 3;
    [SerializeField] private PlayerWeapon _Weapon = null;
    [SerializeField] private UnityEvent _OnAttackStart = new UnityEvent();

    [SerializeField] [Tooltip("The time between clicks that still count as \"Holding down\"")]
    private float _ClickTime = 0.2f;
    private Elapser _ELWaitTime = null;

    [SerializeField] [Tooltip("The min amount of time that an attack takes ")]
    private float _MinAttackTime = 0.2f;
    private Elapser _ElMinAttackTime = null;

    private PlayerAnimatorController _AniCont = null;

    private bool _IsHoldingDown = false; 
    private bool _IgnoreAnimationFunction = false;
    private CharacterStats _stats;

    private void Awake()
    {
        _stats = this.GetComponent<CharacterStats>();
        _ELWaitTime = new Elapser(_ClickTime);
        _ElMinAttackTime = new Elapser(_ClickTime);
        _AniCont = GetComponent<PlayerAnimatorController>();
    }
    private void Update()
    {
        if (!_stats.Health.IsAlive) return;
        if (!_Weapon.IsAttacking) return;

        _ElMinAttackTime.Update(Time.deltaTime);
        if (_IsHoldingDown) return;

        if (!_ElMinAttackTime.HasElapsed) return;

        if (_ELWaitTime.Update(Time.deltaTime))
        {
            StopAttack();
        }
    }

    private void OnLeftClickDown()
    {
        
        if(!_Weapon.IsAttacking)
        {
            _ElMinAttackTime.Reset();
        }

        _Weapon.IsAttacking = true;
        _AniCont.StartAttack();
        _ELWaitTime.Reset();

        _IsHoldingDown = true;
        _IgnoreAnimationFunction = false;
    }
    private void OnLeftClickUp()
    {
        _IsHoldingDown = false;
        //StopAttack();
    }
    private void StopAttack()
    {
        _Weapon.IsAttacking = false;
        _AniCont.StopAttack();
        _AttackCombo = 1;
        _IgnoreAnimationFunction = true;
    }
    private void EndOfAttack()
    {
        _Weapon.Reset();
        if (_IgnoreAnimationFunction) return;
        _AttackCombo++;


        if (_AttackCombo % _ComboCount == 0)
        {
            _Weapon.IsHeavyAttack = true;
            gameObject.SendMessage("DoHeavyAttack");
        }
        else
        {
            _Weapon.IsHeavyAttack = false;
        }
    }


    private void AttackStart()
    {
        _OnAttackStart?.Invoke();
    }

    public void OnBeforeSerialize() { }
    public void OnAfterDeserialize()
    {
        _ELWaitTime?.Reset(_ClickTime);
        _ElMinAttackTime?.Reset(_MinAttackTime);
    }
}