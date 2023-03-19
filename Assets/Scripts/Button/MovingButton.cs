using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovingButton : MonoBehaviour, IPointerClickHandler
{
    //private int _horizontal;
    private int _vertical;
    private GameObject[,] _dataCell;

    [SerializeField] private MovementButtons _mvovementButtons;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == -1)
        {
            //_horizontal = ((int)gameObject.transform.position.x);
            _mvovementButtons.ButtonsMovement();
            GameMenejer.instance.MuvePlayerOff();
        }
    }
}

