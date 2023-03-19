using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowEntety : MonoBehaviour
{
    private GameObject[] _entetyArrey = new GameObject[8];
    [SerializeField] private int _vertically;
    private int _filledCells;
    private int _strength = 1;
    
    public void SpawnEntety(int horizontal)
    {
        if (_entetyArrey[horizontal] == null)
        {
            var pos = new Vector3(horizontal, 0.7f, _vertically);
            _entetyArrey[horizontal] = Instantiate(GameMenejer.instance._enemy, pos, Quaternion.identity);
            GameMenejer.instance.dataCell[_vertically, horizontal] = _entetyArrey[horizontal];
            _entetyArrey[horizontal].GetComponent<VarreorEntety>().strength = _strength; //сила entety
            _strength = _strength + 1;
            _entetyArrey[horizontal].GetComponent<VarreorEntety>().Strength();
            var stone = _entetyArrey[horizontal];
            stone.transform.SetParent(GameMenejer.instance._rowEntetyPlayr);
            _filledCells++;
            return;
        }
        Debug.Log("клетка занята");
    }

    public int ArrayIsFilled()
    {
        if (_filledCells == 8)
        {
            _filledCells = 0;
            _entetyArrey = new GameObject[8];
            _strength = 1;
            return 1;
        }
        return 0;
    }
    
    
}
