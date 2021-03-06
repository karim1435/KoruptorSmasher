﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
using Assets.Scripts.Attacker;
using Assets.Scripts.Collectible_Item;

public class Bomb : DefenderParent
{
    protected override void KillAllIncomingEnemy()
    {
        foreach (var enemy in FindObjectsOfType<BadEnemyDied>())
        {
            if (enemy != null)
                enemy.Dead();
        }
        PlayClickEffects(gameAudio.bombEffects);
    }
    
}

