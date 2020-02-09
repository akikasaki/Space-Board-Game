﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFieldMovement : MovementHandler
{
    public void SetCurrentField(int fieldIndex, GameObject player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

        //update the current field to be without the player
        
        playerMovement.currentField = path.MemberWithIndex(playerMovement.playersCurrentPathIndex);
        playerMovement.currentFieldAltPoints = playerMovement.currentField.GetComponent<FieldAltPoints>();
        playerMovement.currentFieldAltPoints.playersOnField--;

        //get the field you are supposed to move to
        playerMovement.playersCurrentPathIndex = fieldIndex;
        playerMovement.currentField = path.MemberWithIndex(fieldIndex);
        playerMovement.currentFieldAltPoints = playerMovement.currentField.GetComponent<FieldAltPoints>();

        //Update the next field to have the player on it
        FieldAltPoints nextFieldAltPoints = playerMovement.currentFieldAltPoints;
        nextFieldAltPoints.playersOnField++;
        playerMovement.positionToTravelTo = nextFieldAltPoints.altPoints[nextFieldAltPoints.playersOnField - 1].transform.position;

    }

    public GameObject MoveNFields(int n, GameObject player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        int spacesToMove = playerMovement.spacesToMove = n;
        int currentPathIndex = playerMovement.playersCurrentPathIndex;

        GameObject lastField = currentPathIndex + spacesToMove >= path.gameObjects.Length ?
            path.MemberWithIndex(currentPathIndex + spacesToMove - path.gameObjects.Length) :
            path.MemberWithIndex(currentPathIndex + spacesToMove);
        lastField.tag = "LastField";
        MoveToNextField(player, currentPathIndex);
        return player;
    }

    public GameObject MoveToNextField(GameObject player, int currentPathIndex)
    {
        path = InstanceManager.Instance.Get<FieldHandler>();

        player.GetComponent<PlayerMovement>().spacesToMove--;

        int nextPathIndex = (currentPathIndex + 1) % (path.gameObjects.Length);
        if (path.MemberWithIndex(nextPathIndex).tag != "LastField")
        {
            path.MemberWithIndex(nextPathIndex).tag = "NextField";
        }
        InstanceManager.Instance.Get<PlayerFieldMovement>().SetCurrentField(nextPathIndex, player.gameObject);
        return player;
    }

}
