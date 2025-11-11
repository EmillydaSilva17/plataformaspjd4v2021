using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HUDObserverManager
{
    public static event Action<int> ONLivesChangedChannel;

    public static void LivesChangedChannel(int lives)
    {
        ONLivesChangedChannel?.Invoke(lives);
    }

    public static event Action<float> ONPlayerEnergyChangedChannel;

    public static void PlayerEnergyChangedChannel(float energy)
    {
        ONPlayerEnergyChangedChannel?.Invoke(energy);
    }

    public static event Action<bool> ONPlayerVictory;

    public static void PlayerVictory(bool playerWon)
    {
        ONPlayerVictory?.Invoke(playerWon);
    }

    public static event Action<bool> ONPlayerDeath;

    public static void PlayerDeath(bool playerDied)
    {
        ONPlayerDeath?.Invoke(playerDied);
    }

    public static event Action<bool> ONActivateHUD;

    public static void ActivateHUD(bool state)
    {
        ONActivateHUD?.Invoke(state);
    }

    public static event Action<int> ONCoinsChanged;
    
    public static void CoinsChanged(int coins)
    {
        ONCoinsChanged?.Invoke(coins);
    }

    public static event Action<bool> ONKeyChanged;

    public static void KeyChanged(bool key)
    {
        ONKeyChanged?.Invoke(key);
    }
    
    public static event Action<int> ONActChanged;
    
    public static void ActChanged(int act)
    {
        ONActChanged?.Invoke(act);
    }
}
