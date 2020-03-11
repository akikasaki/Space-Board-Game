﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardStateHandler : MonoBehaviour
{
    public PlayerBoardState[] playerBoardStates;

    private void Start()
    {
        GameObject[] players = InstanceManager.Instance.Get<PlayersHandler>().gameObjects;
        foreach (var stateComponent in InstanceManager.Instance.GetComponents<IBoardPlayerState>())
        {
            for (int i = 0; i < players.Length; i++)
            {
                stateComponent.SetupPlayerState(players[i], playerBoardStates[i]);
            }
        }
    }

    public void SaveBoardState()
    {
        GameObject[] players = InstanceManager.Instance.Get<PlayersHandler>().gameObjects;
        foreach (var stateComponent in InstanceManager.Instance.GetComponents<IBoardPlayerState>())
        {
            for (int i = 0; i < players.Length; i++)
            {
                stateComponent.SavePlayerState(players[i], playerBoardStates[i]);
            }
        }
    }
}