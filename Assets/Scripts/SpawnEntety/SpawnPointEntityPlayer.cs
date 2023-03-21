using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnPointEntityPlayer : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private RowEntety _rowEntety;

    public void OnPointerDown(PointerEventData eventData)
    {
        _rowEntety.SpawnEntety((int)gameObject.transform.position.x);
    }
}
