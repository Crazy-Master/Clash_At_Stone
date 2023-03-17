using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickReceiver : MonoBehaviour, IPointerClickHandler
{
    private HorizontallyFifthStoneEnemy _horizontallyStoneEnemy;
    
    private void Awake()
    {
        _horizontallyStoneEnemy = gameObject.GetComponentInParent<HorizontallyFifthStoneEnemy>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == -1)
        {
            _horizontallyStoneEnemy.SpawnFiveLine(gameObject.transform.position + new Vector3(0,0.5f,0));
        }
    }

   
}
