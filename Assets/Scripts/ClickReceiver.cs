using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickReceiver : MonoBehaviour, IPointerDownHandler
{
    private HorizontallyFifthStoneEnemy _horizontallyStoneEnemy;
    
    private void Awake()
    {
        _horizontallyStoneEnemy = gameObject.GetComponentInParent<HorizontallyFifthStoneEnemy>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _horizontallyStoneEnemy.SpawnFiveLine(gameObject.transform.position + new Vector3(0,0.5f,0));
    }

   
}
