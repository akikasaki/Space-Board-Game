﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFieldClickEvent
{
    void FieldClickAction(IClickEvent click, GameObject hit);
}