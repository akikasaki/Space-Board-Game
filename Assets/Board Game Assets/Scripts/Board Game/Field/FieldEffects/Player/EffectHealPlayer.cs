﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHealPlayer : FieldEffect
{
    public float amountToHeal = 20f;

    public override void TriggerEffect()
    {
        GenericTriggerEffect();
        Repair.RepairPlayer(playersHandler.GetCurrentPlayer(), amountToHeal, HullHandler.MAXIMUM_HULL);
        InstanceManager.Instance.Get<FieldEffectHandler>().TriggerEffectFinishedEvents(gameObject);
    }

    public override void FinishedEffect()
    {
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}