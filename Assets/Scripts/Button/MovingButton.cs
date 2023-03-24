using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovingButton : MonoBehaviour, IPointerDownHandler
{

    [SerializeField] private MovementButtons _mvovementButtons;

    public void OnPointerDown(PointerEventData eventData)
    {
        _mvovementButtons.ButtonsMovement();
            //GameMenejer.instance.MuvePlayerOff();
    }
}

