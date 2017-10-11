using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class Stat {
    [SerializeField]
    private UIBar bar;

    [SerializeField]
    private float maxValue;

    [SerializeField]
    private float currentValue;

    public float CurrentValue
    {
        get
        {
            return currentValue;
        }

        set
        {
            if( value > maxValue )
            {
                this.currentValue = maxValue;
                bar.Value = currentValue;
            }
            else
            {
                this.currentValue = value;
                bar.Value = currentValue;
            }
        }
    }

    public float MaxValue
    {
        get
        {
            return maxValue;
        }

        set
        {
            this.maxValue = value;
            bar.MaxValue = maxValue;
        }
    }

    public void Initialize(string nameOfStat)
    {
        bar.MaxValue = maxValue;
        bar.StatName = nameOfStat;
        bar.Value = currentValue;
    }
}
