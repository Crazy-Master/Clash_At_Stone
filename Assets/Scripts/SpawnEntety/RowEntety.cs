using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowEntety : MonoBehaviour
{
    private GameObject[] _entetyArrey = new GameObject[8];
    [SerializeField] private int _vertically = 0;
    private int _filledCells;
    private int _strength = 1;
    
    public void SpawnEntety(int horizontal, GameObject entety)
    {
        if (_entetyArrey[horizontal] == null)
        {
            var pos = new Vector3(horizontal, 0.2f, _vertically);
            _entetyArrey[horizontal] = GameMenejer.instance.ObjectSpawn(pos, entety); //dataCell не удаляет повторные объекта, а только перезаписывает!!!
            if (_entetyArrey[horizontal].GetComponent<EntetyPlayrs>() != null)
            {
                _entetyArrey[horizontal].GetComponent<EntetyPlayrs>().rowEntety = this;
            }
            _entetyArrey[horizontal].GetComponent<VarreorEntety>().strength = _strength; //сила entety
            //_strength = _strength + 1;
            _entetyArrey[horizontal].GetComponent<VarreorEntety>().Strength();
            var stone = _entetyArrey[horizontal];
            stone.transform.SetParent(GameMenejer.instance._rowEntety);
            _filledCells++;
            return;
        }
        else
        {
            Destroy(_entetyArrey[horizontal]);
            _entetyArrey[horizontal] = null;
            Debug.Log(_entetyArrey[horizontal]);
            _filledCells--;
        }
    }

    public int ArrayIsFilled()
    {
        if (_filledCells == 8)
        {
            for (int i = 0; i < 8; i++)
                if (_entetyArrey[i] != null && _entetyArrey[i].GetComponent<EntetyPlayrs>())
                    _entetyArrey[i].GetComponent<EntetyPlayrs>().enabled = false;

            _filledCells = 0;
            _entetyArrey = new GameObject[8];
            _strength = 1;
            return 1;
        }
        return 0;
    }
    
    
}
