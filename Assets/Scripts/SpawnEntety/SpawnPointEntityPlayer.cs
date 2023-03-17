using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnPointEntityPlayer : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private RowEntety _rowEntety;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == -1)
        {
            _rowEntety.SpawnEntety((int)gameObject.transform.position.x);
        }
    }
}
