using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnStone : MonoBehaviour
{
    [ContextMenu("StoneSpawn")]

    public void StoneSpawn()
    {
        var i = Random.Range(-3, 4);
        int y = 0;
        int distance = 0;
        while (distance < 2 || distance > 4)
        {
            Debug.Log("зашёл");
           y = Random.Range(-3, 4);
           distance = i - y;
           if (distance < 0)
           {
               distance = distance * -1;
           }
        }
        Debug.Log("distance_" + distance);
    }
}
