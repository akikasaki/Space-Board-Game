﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyField : FieldEffect
{
    public override void TooltipDisplay()
    {
        TooltipHandler tooltipHandler = InstanceManager.Instance.Get<TooltipHandler>();
        tooltipHandler.ShowFieldInfoTooltip("This field does nothing!");
    }

    public override void TriggerEffect()
    {
        GenericTriggerEffect();
        InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
        print("end turn");
    }
}