using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EntetyPlayrs : MonoBehaviour, IPointerDownHandler
{
    public RowEntety rowEntety;
    

    public void OnPointerDown(PointerEventData eventData)
    {
        rowEntety.SpawnEntety((int)gameObject.transform.position.x, GameMenejer.instance._entetyPlayers);
    }
}
