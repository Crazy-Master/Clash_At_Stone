using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour, ISpawnObject
{
    public GameObject ObjectSpawn(Vector3 position, GameObject prefab)
    {
        var dataCell = GameMenejer.instance.dataCell;
        if (position.z < 7)
        {
            dataCell[(int)position.z,(int)position.x] = Instantiate(prefab, position, Quaternion.identity);
            return dataCell[(int)position.z, (int)position.x];
        }
        dataCell[(int)position.z,(int)position.x] = Instantiate(prefab, position, Quaternion.AngleAxis(180,Vector3.up));
        return dataCell[(int)position.z, (int)position.x];
    }
}
