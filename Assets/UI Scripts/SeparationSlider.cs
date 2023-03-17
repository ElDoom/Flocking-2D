using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SeparationSlider : MonoBehaviour
{
    public Slider slider;

    public TextMeshProUGUI sliderText;

    public CompositeBehavior cb;

    private int positionOnArray = 0;
    // Start is called before the first frame update
    void Start()
    {
        slider.minValue = 0f;
        slider.maxValue = 5f;
        if (cb.behaviors == null)
        {
            Debug.LogError(cb.behaviors);
        }
        for (int i = 0; i < cb.behaviors.Length; i++)
        {
            if (cb.behaviors[i].GetNameBehavior().Equals("Separation"))
            {
                positionOnArray = i;
                slider.value = cb.weights[i];
                sliderText.text = "Separation Weight: " + cb.weights[i].ToString();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        cb.weights[positionOnArray] = slider.value;
        sliderText.text = "Separation Weight: " + cb.weights[positionOnArray].ToString();
    }
}