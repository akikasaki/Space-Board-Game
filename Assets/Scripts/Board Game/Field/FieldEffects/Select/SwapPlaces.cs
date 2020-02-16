﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPlaces : ISelectionEffect
{

    private GameObject field;

    public SwapPlaces(GameObject field)
    {
        this.field = field;
    }

    public static bool TrySwappingPlayers(PlayerMovement firstPlayer, PlayerMovement secondPlayer, GameObject fieldTriggeringSwap)
    {
        bool playersOnSameField =
            firstPlayer.currentPlayerField.
            Equals(secondPlayer.currentPlayerField);

        if (playersOnSameField)
            return PlayersOnSameFieldAction();
        else return SwapPlayersAction(firstPlayer, secondPlayer, fieldTriggeringSwap);
    }

    private static bool PlayersOnSameFieldAction()
    {
        return false;
    }

    private static bool SwapPlayersAction(PlayerMovement firstPlayer, PlayerMovement secondPlayer, GameObject firstPlayersField)
    {
        firstPlayersField.tag = "Untagged";

        FieldHandler fieldHandler = InstanceManager.Instance.Get<FieldHandler>();
        fieldHandler.SwapTwoPlayers(firstPlayer, secondPlayer);

        return true;
    }

    public void ConfirmedSelection()
    {
        PlayerMovement triggeringPlayer = InstanceManager.Instance.Get<PlayersHandler>().GetCurrentPlayer().GetComponent<PlayerMovement>();
        PlayerMovement selectedPlayer = InstanceManager.Instance.Get<SelectionHandler>().GetSelectedPlayer().GetComponent<PlayerMovement>();
        if (TrySwappingPlayers(triggeringPlayer, selectedPlayer, field))
            InstanceManager.Instance.Get<TurnHandler>().EndCurrentPlayersTurn();
    }
}
