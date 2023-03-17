//This guy help me with this https://www.youtube.com/watch?v=hPX_5-mJMHc&ab_channel=GameAssetWorld

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedSliderController : MonoBehaviour
{
    public Slider slider;

    public TextMeshProUGUI sliderText;

    public Flock flock;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = 10f;
        slider.minValue = 1f;
        slider.value = 5f;
        sliderText.text = "Speed: " + slider.value.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        flock.maxSpeed = slider.value;
        sliderText.text = "Speed: " + slider.value.ToString();
    }
}
