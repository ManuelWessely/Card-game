using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LazyHealthbar : MonoBehaviour
{
    enum Mode
    {
        Static,
        Damage,
        Heal
    }
    public Slider realValueSlider, lazySlider;
    public float baseSpeed;
    public float acceleration;
    private float speed;
    private float lastValue;
    Mode mode=Mode.Static;

    public void SetHealth(int health, int maxHealth)
    {
        SetValue((float)health / maxHealth);
    }


    [Button]
    public void SetValue(float value)
    {
        if (value>lastValue)
        {
            mode = Mode.Heal;
            lazySlider.value = value;
        }
        else if (value < lastValue)
        {
            mode = Mode.Damage;
            realValueSlider.value = value;
        }
        else
        {
            mode = Mode.Static;
            realValueSlider.value = value;
            lazySlider.value = value;
        }
        lastValue = value;
        speed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        switch (mode)
        {
            case Mode.Static:
                break;
            case Mode.Damage:
                if (lazySlider.value >lastValue)
                {
                    lazySlider.value -= Time.deltaTime * speed;
                    speed += Time.deltaTime * acceleration;

                }
                else
                {
                    mode = Mode.Static;
                }
                break;
            case Mode.Heal:
                if (realValueSlider.value < lastValue)
                {
                    realValueSlider.value += Time.deltaTime * speed;
                    speed += Time.deltaTime * acceleration;
                }
                else
                {
                    mode = Mode.Static;
                }
                break;
            default:
                break;
        }

    }
}
