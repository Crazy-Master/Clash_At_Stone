using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenejer : MonoBehaviour
{
   public static GameMenejer instance;
   public GameEntity[,] dataCell;
   [SerializeField] private GameObject _stone;
   
   
   private void Start()
   {
      if (instance == null)
      {
         instance = this;
            
      }
      else if (instance == this)
      {
         Destroy(gameObject);
      }
      DontDestroyOnLoad(gameObject);
      dataCell = new GameEntity[7,13];
   }
   
   
}
