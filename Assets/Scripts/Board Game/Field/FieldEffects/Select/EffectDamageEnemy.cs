﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDamageEnemy : SelectOnTrigger
{
    public const float AMOUNT_TO_DAMAGE = 20f;

    public override void TriggerEffect()
    {
        SelectNextPlayerOnTrigger();
        print("Damage Another player!");
    }

    private void Awake()
    {
        selectionEffect = new DamageEnemy(gameObject);
    }

    private void Update()
    {
        if (gameObject.tag == TAG_SELECTION)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                InstanceManager.Instance.Get<SelectionHandler>().SelectNextPlayer(playersHandler.GetCurrentPlayer());
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                selectionEffect.ConfirmedSelection();
            }
        }
    }

}
