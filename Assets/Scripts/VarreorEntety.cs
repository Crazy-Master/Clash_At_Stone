using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;
using UnityEngine;

public class VarreorEntety : MonoBehaviour
{
    private float _moveTime = 1.5f;
    public int strength;
    //[SerializeField] private TextMeshProUGUI _strText;
    public void Strength()
    {
      var strText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
      strText.text = strength.ToString();
    }

    public void Muving(int z)
    {
        //gameObject.transform.position = gameObject.transform.position + new Vector3(0, 0, z);
        Vector3 move = gameObject.transform.position + new Vector3(0, 0, z);
        transform.DOMove(move, _moveTime);
        GameMenejer.instance.NextStepTimer(_moveTime);
        
    }
}
