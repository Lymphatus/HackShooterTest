using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHealthController : MonoBehaviour
{
    public Slider slider;

    public void SetMax(float value)
    {
        slider.maxValue = value;
        slider.value = value;
    }

    public void SetValue(float value)
    {
        slider.value = value;
    }
}
