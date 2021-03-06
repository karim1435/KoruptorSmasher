﻿using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public delegate void UpdateHp();
    public event UpdateHp OnZeroHealth;

    private float initialHp;
    private float currentHp;
    private float point;
    private float damage=1.0f;

    private Enemy enemy;
    public float CurrentHp { get {return currentHp; } protected set { currentHp = value; } }
    void Start()
    {
        enemy = GetComponent<Enemy>();
        initialHp = enemy.Hp;
        currentHp = initialHp;
    }
    protected virtual void AttackHp(float attackPower)
    {
        CheckHp();
    }
    private void CheckHp()
    {
        if (currentHp<=0)
        {
            if (OnZeroHealth != null)
                OnZeroHealth();
        }
    }
    protected virtual void OnMouseDown()
    {
        if (!GameManager.Instance.IsGameRunning()) return;
        if (currentHp > 0)
            AttackHp(damage);
    }

}
