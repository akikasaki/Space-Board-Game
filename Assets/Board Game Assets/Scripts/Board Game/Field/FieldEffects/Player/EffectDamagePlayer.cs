﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDamagePlayer : FieldEffect
{
    public float damageAmount = 20;

    public override void TooltipDisplay()
    {
        TooltipHandler tooltipHandler = InstanceManager.Instance.Get<TooltipHandler>();
        tooltipHandler.ShowFieldInfoTooltip("You Took damage!");
    }

    public override void TriggerEffect()
    {
        GenericTriggerEffect();
        Damage.DamagePlayer(playersHandler.GetCurrentPlayer(), damageAmount);
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}