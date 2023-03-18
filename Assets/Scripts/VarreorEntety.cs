using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VarreorEntety : MonoBehaviour
{
    public int strength;
    //[SerializeField] private TextMeshProUGUI _strText;
    public void Strength()
    {
       var strText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
       strText.text = strength.ToString();
    }

    public void Muving()
    {
        
    }
}
