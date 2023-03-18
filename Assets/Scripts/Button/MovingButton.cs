using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovingButton : MonoBehaviour, IPointerClickHandler
{
    //private int _horizontal;
    private int _vertical;
    private GameObject[,] _dataCell;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == -1)
        {
            //_horizontal = ((int)gameObject.transform.position.x);
            _vertical = ((int)gameObject.transform.position.z);
            _dataCell = GameMenejer.instance.dataCell;
            
            for (int i = 0; i < 8; i++)
            {
                var objectCell = _dataCell[_vertical, i];
                if (objectCell.GetComponent<VarreorEntety>())
                {
                    objectCell.GetComponent<VarreorEntety>().Muving();
                }
            }
        }
    }
}

