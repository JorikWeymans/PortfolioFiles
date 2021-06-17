//Created by Jorik Weymans 2021

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private float _Damage = 60.0f;
    public bool IsAttacking { get; set; } = false;
    public bool IsHeavyAttack { get; set; }= false;

    private List<Collider> _Colliders = new List<Collider>();

    public void Reset()
    {
        _Colliders.Clear();
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (!IsAttacking) return;
        if (!coll.CompareTag("Enemy")) return;
        if (_Colliders.Contains(coll)) return;

        _Colliders.Add(coll);

        EnemyStats stats = coll.transform.GetComponent<EnemyStats>();
        if (stats != null)
        {
            stats.Health.LoseResource(IsHeavyAttack? _Damage : _Damage * 2.0f);
        }

        Debug.Log("Weapon Hit");
    }
}