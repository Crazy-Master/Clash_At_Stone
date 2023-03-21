using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightBatton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private HorizontalMovement _horizontalMovement;

    public void OnPointerDown(PointerEventData eventData)
    {
        _horizontalMovement.HorizontalButtons(+1);
    }
}
