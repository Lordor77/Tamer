using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {
    
    // Variables
    private float fillAmount;

    [SerializeField]
    private Image content;
    [SerializeField]
    public Text valueText;
    [SerializeField]
    private float lerpSpeed;
    public float MaxValue { get; set; }
    [SerializeField]
    private Color fullColor;
    [SerializeField]
    private Color lowColor;
    [SerializeField]
    private bool lerpColors;


    public float Value
    {
        set
        {
            string[] tmp = valueText.text.Split(':');
            valueText.text = tmp[0] + ": " + value;
            fillAmount = Map(value,0,MaxValue,0,1);
        }
    }

    // Use this for initialization
    void Start () {
        if (lerpColors)
        {
            content.color = fullColor;
        }
	}
	
	// Update is called once per frame
	void Update () {
        BarHandler();
	}

    void BarHandler()
    {
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount,fillAmount,Time.deltaTime * lerpSpeed);
        }
        if (lerpColors)
        {
            content.color = Color.Lerp(lowColor, fullColor, fillAmount);
        }
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
