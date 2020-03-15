﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineFieldSelectionEvent : ISelectionEffect
{
    private GameObject fieldOfPlayerSelecting;

    public MineFieldSelectionEvent(GameObject fieldOfPlayerSelecting)
    {
        this.fieldOfPlayerSelecting = fieldOfPlayerSelecting;
    }

    public void ConfirmedSelection()
    {
        GameObject selectedField = InstanceManager.Instance.Get<FieldSelectionHandler>().GetSelectedField();
        if (selectedField.GetComponent<Mine>() == null)
        {
            selectedField.AddComponent<Mine>();
            InstanceManager.Instance.Get<FieldEffectHandler>().TriggerEffectFinishedEvents(fieldOfPlayerSelecting);
            //Mine placed sound
        }
        else Debug.Log("mine already exists");
    }
}