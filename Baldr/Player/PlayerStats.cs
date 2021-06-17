using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    private Animator animator;
    [SerializeField]
    private float _RemoveTime = 2f;
    private void Awake()
    {
        animator = this.GetComponent<Animator>();
        _Health.SetMax(_Health.Max + GameManager.GetInstance().WaveManager.GetEnemyCount() * 5);
        _Health.AddListener(Resource.ActionType.ActionOnEmpty, arg0 =>
        {
            GameManager gManager = GameManager.GetInstance();

            gManager.WaveManager.UpdateEnemyCount();
            if (animator != null)
            {
                animator.SetTrigger("IsKilled");
                Invoke("Remove", _RemoveTime);
            }
            else
                Remove();
        });

    }
    private static void Remove()
    {
        GameManager.GetInstance().endState = false;
        ServiceLocator.UIService.OpenPanel(UI.PanelNames.ENDSCREEN_PANEL);
    }
}
