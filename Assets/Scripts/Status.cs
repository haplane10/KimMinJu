using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] Slider slider;

    public void UpdateData()
    {
        slider.value = hp;
    }

    public void Damaged(int value)
    {
        hp -= value;
        UpdateData();

        if (hp <= 0)
        {
            Destroy(gameObject, 1f);
        }
    }
}
