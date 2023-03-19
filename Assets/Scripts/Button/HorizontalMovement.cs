using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    private GameObject[,] _dataCell;
    
    public void HorizontalButtons(int side)
    {
        _dataCell = GameMenejer.instance.dataCell;
        var objectZ = (int)(gameObject.transform.position.z + 1);
        var objectZOver = Mathf.Abs(objectZ - 13);
        if (side < 0)
        {
            if (_dataCell[objectZ, 0] == null && _dataCell[objectZOver, 0] == null)
            {
                for (int i = 0; i < 7; i++)
                {
                    _dataCell[objectZ, i] = _dataCell[objectZ, i + 1];
                    _dataCell[objectZOver, i] = _dataCell[objectZOver, i + 1];
                }
                _dataCell[objectZ, 7] = null;
                _dataCell[objectZOver, 7] = null;
                for (int i = 0; i < 8; i++)
                {
                    if (_dataCell[objectZ, i] != null)
                    {
                        _dataCell[objectZ, i].transform.position =
                            new Vector3(i, _dataCell[objectZ, i].transform.position.y, objectZ);
                    }

                    if (_dataCell[objectZOver, i] != null)
                    {
                        _dataCell[objectZOver, i].transform.position = new Vector3(i,
                            _dataCell[objectZOver, i].transform.position.y, objectZOver);
                    }
                }
            }
        }
        else
        {
            if (_dataCell[objectZ, 7] == null && _dataCell[objectZOver, 7] == null)
            {
                for (int i = 7; i > 0; i--)
                {
                    _dataCell[objectZ, i] = _dataCell[objectZ, i - 1];
                    _dataCell[objectZOver, i] = _dataCell[objectZOver, i - 1];
                }

                _dataCell[objectZ, 0] = null;
                _dataCell[objectZOver, 0] = null;
                for (int i = 0; i < 8; i++)
                {
                    if (_dataCell[objectZ, i] != null)
                    {
                        _dataCell[objectZ, i].transform.position =
                            new Vector3(i, _dataCell[objectZ, i].transform.position.y, objectZ);
                    }

                    if (_dataCell[objectZOver, i] != null)
                    {
                        _dataCell[objectZOver, i].transform.position = new Vector3(i,
                            _dataCell[objectZOver, i].transform.position.y, objectZOver);
                    }
                }
            }
        }
    }
}
