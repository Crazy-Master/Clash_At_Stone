using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    private GameObject[,] _dataCell;
    private float _moveTime = 0.7f;
    [SerializeField] private AudioClip collectedClip;
    
    public void HorizontalButtons(int side)
    {
        _dataCell = GameMenejer.instance.dataCell;
        var objectZ = (int)(gameObject.transform.position.z + 1);
        var objectZOver = Mathf.Abs(objectZ - 13);
        if (side < 0) //влево
        {
            if (_dataCell[objectZ, 0] == null && _dataCell[objectZOver, 0] == null)
            {
                GameMenejer.instance.PlaySound(collectedClip);
                
                for (int i = 0; i < 7; i++)
                {
                    _dataCell[objectZ, i] = _dataCell[objectZ, i + 1];
                    _dataCell[objectZOver, i] = _dataCell[objectZOver, i + 1];
                }
                _dataCell[objectZ, 7] = null;
                _dataCell[objectZOver, 7] = null;
                for (int i = 0; i < 8; i++) //move
                {
                    if (_dataCell[objectZ, i] != null)
                    {
                        Vector3 move = new Vector3(i, _dataCell[objectZ, i].transform.position.y, objectZ);
                        _dataCell[objectZ, i].transform.DOMove(move, _moveTime);
                    }

                    if (_dataCell[objectZOver, i] != null)
                    {
                        Vector3 move = new Vector3(i, _dataCell[objectZOver, i].transform.position.y, objectZOver);
                        _dataCell[objectZOver, i].transform.DOMove(move, _moveTime);
                    }
                }
            }
        }
        else //вправо
        {
            if (_dataCell[objectZ, 7] == null && _dataCell[objectZOver, 7] == null)
            {
                GameMenejer.instance.PlaySound(collectedClip);
                
                for (int i = 7; i > 0; i--)
                {
                    _dataCell[objectZ, i] = _dataCell[objectZ, i - 1];
                    _dataCell[objectZOver, i] = _dataCell[objectZOver, i - 1];
                }

                _dataCell[objectZ, 0] = null;
                _dataCell[objectZOver, 0] = null;
                for (int i = 0; i < 8; i++) //move
                {
                    if (_dataCell[objectZ, i] != null)
                    {
                        Vector3 move =  new Vector3(i, _dataCell[objectZ, i].transform.position.y, objectZ);
                        _dataCell[objectZ, i].transform.DOMove(move, _moveTime);
                    }

                    if (_dataCell[objectZOver, i] != null)
                    {
                        Vector3 move =  new Vector3(i, _dataCell[objectZOver, i].transform.position.y, objectZOver);
                        _dataCell[objectZOver, i].transform.DOMove(move, _moveTime);
                    }
                }
            }
        }
    }
}
