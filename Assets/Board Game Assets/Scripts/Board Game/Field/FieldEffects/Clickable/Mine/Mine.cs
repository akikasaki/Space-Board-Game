﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : FieldEffect
{
    public override void TooltipDisplay()
    {
        TooltipHandler tooltipHandler = InstanceManager.Instance.Get<TooltipHandler>();
        tooltipHandler.ShowFieldInfoTooltip("Stepped on a mine!");
    }

    public override void TriggerEffect()
    {
        GenericTriggerEffect();
        print("YOU STEPPED ON A MINE");
        Destroy(this);
    }
}