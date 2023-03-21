using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovingButton : MonoBehaviour, IPointerDownHandler
{
    //private int _horizontal;
    private int _vertical;
    private GameObject[,] _dataCell;

    [SerializeField] private MovementButtons _mvovementButtons;

    public void OnPointerDown(PointerEventData eventData)
    {
        _mvovementButtons.ButtonsMovement();
            GameMenejer.instance.MuvePlayerOff();
    }
}

