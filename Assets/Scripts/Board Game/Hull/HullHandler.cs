﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HullHandler : MonoBehaviour, IBoardState
{
    public const float startingAmount = 120f;
    public const float maximumAmount = 120f;

    public GameObject SetPlayerHull(GameObject player, float value)
    {
        player.GetComponent<PlayerHull>().HullPercentage = value;
        return player;
    }

    public PlayerHull GetPlayerHull(GameObject player)
    {
        return player.GetComponent<PlayerHull>();
    }

    public GameObject RepairPlayer(GameObject player, float value)
    {
        PlayerHull playerHull = player.GetComponent<PlayerHull>();
        playerHull.HullPercentage += value;
        if (playerHull.HullPercentage >= maximumAmount)
        {
            playerHull.HullPercentage = maximumAmount;
        }

        return player;
    }

    public GameObject DamagePlayer(GameObject player, float value)
    {
        player.GetComponent<PlayerHull>().HullPercentage -= value;
        if(player.GetComponent<PlayerHull>().HullPercentage <= 0)
        {
            player.GetComponent<PlayerCheckpoint>().RespawnAtCheckpoint();
        }
        return player;
    }

    public void SaveState()
    {
        int i = 0;
        foreach (var player in InstanceManager.Instance.Get<PlayersHandler>().gameObjects)
        {
            float amount = InstanceManager.Instance.Get<BoardStateHandler>().playerBoardStates[i].hull = player.GetComponent<PlayerHull>().HullPercentage;
            print("Saving the players fuel: " + amount);
            i++;
        }
    }

    public void SetupState()
    {
        int i = 0;
        foreach (var player in InstanceManager.Instance.Get<PlayersHandler>().gameObjects)
        {
            float amount = InstanceManager.Instance.Get<BoardStateHandler>().playerBoardStates[i].hull;
            player.GetComponent<PlayerHull>().HullPercentage = amount;
            print("Players initial hull set: " + amount);
            i++;
        }
    }
}


