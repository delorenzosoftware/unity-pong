using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Infos : MonoBehaviour
{
    public PaddleData data;

    void Update()
    {
        var text = gameObject.GetComponentInChildren<TMP_Text>(true);
        text.text = data.PositionScale.ToString();
    }

    public void ChangeData(float value)
    {
        data.PositionScale = value;
    }
}
