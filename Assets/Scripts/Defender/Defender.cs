﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using Assets.Scripts.Collectible_Item;
using Assets.Scripts.Manager;

public abstract class DefenderParent : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private float totalItem;

    protected GameAudio gameAudio;
    protected virtual void Start()
    {
        gameAudio = FindObjectOfType<GameAudio>();
    }
    public float TotalItem
    {
        get { return totalItem; }
        protected set { totalItem = value; }
    }
    public void ExtraItem(float health)
    {
        TotalItem += health;
    }
    protected void SpendItem()
    {
        TotalItem--;
    }
    protected bool IsItemAvailable()
    {
        return TotalItem > 0;
    }
    protected abstract void KillAllIncomingEnemy();
    private void UseItem()
    {
        SpendItem();
        KillAllIncomingEnemy();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!GameManager.Instance.IsGameRunning()) return;
        if (IsItemAvailable())
            UseItem();
    }
    protected void PlayClickEffects(AudioClip clip)
    {
        SoundManager.Instance.PlayEffect(clip);
    }
}
