using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIBar : MonoBehaviour {
    private float fillAmount;

    [SerializeField]
    private Image content;

    public float MaxValue { get; set; }

    [SerializeField]
    private Text barText;

    private string statName;


    public float Value
    {
        get
        {
            return Value;
        }
        set
        {
            fillAmount = Mathf.Lerp(0.0f, 1.0f, value / MaxValue);
            //barText.text = statName + ": " + ((int)Mathf.Lerp(0, MaxValue, Mathf.Lerp(0, 1, (fillAmount-0.13f)/0.74f))).ToString();
            barText.text = statName + ": " + ((int)Mathf.Lerp(0, MaxValue, fillAmount));
        }
    }

    public string StatName
    {
        set
        {
            statName = value;
        }
    }

    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        HandleBar();
    }

    private void HandleBar()
    {
        if (content.fillAmount != fillAmount)
        {
            content.fillAmount = fillAmount;
        }
    }
}
