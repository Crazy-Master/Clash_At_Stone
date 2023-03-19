using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private HorizontalMovement _horizontalMovement;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == -1)
        {
            _horizontalMovement.HorizontalButtons(-1);
        }
    }
}
