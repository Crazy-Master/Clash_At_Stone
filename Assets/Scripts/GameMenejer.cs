using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenejer : MonoBehaviour
{
   public static GameMenejer instance;
   public GameEntity[,] dataCell;
   public GameObject _stone;
   public GameObject _enemy;
   public Transform _rowEntetyEnemy;
   public Transform _rowEntetyPlayr;

   public bool _fifthStone;
   
   
   [SerializeField] private RowEntety _spawnEnemy;
   [SerializeField] private SpawnStone _spawnStoneFirst;
   [SerializeField] private HorizontallyFifthStonePlayer _spawnStoneFifthBot;
   [SerializeField] private HorizontallyFifthStoneEnemy _spawnStoneFifthPlayer;
   [SerializeField] private RowEntety _rowPlayer;
   private SpawnPointEntityPlayer[] _spawnPlayer;
   private ClickReceiver[] _clickReceivers;
   
   private int _step;

   private void Awake()
   {
      _spawnPlayer = _rowPlayer.GetComponentsInChildren<SpawnPointEntityPlayer>();
      _clickReceivers = _spawnStoneFifthPlayer.GetComponentsInChildren<ClickReceiver>();
   }

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
      dataCell = new GameEntity[8,14];

   }

   private void FixedUpdate()
   {
      FirstPhase();
   }

   private void FirstPhase()
   {
      if (_step == 5) return;
      
      if (_step == 0) //ставится 1-4 ряд стен
      {
         _spawnStoneFirst.StoneSpawn();
         _step++;
         foreach (var clickReceivers in _spawnPlayer)
         {
            clickReceivers.GetComponent<SpawnPointEntityPlayer>().enabled = true;
         }
         return;
      }

      if (_step == 1) //игрок ставит воинов
      {
         _step += _rowPlayer.ArrayIsFilled();
      }

      if (_step == 2) //враг ставит воинов
      {
         _spawnEnemy.gameObject.GetComponent<SpawnPointEntityEnemy>().SpawnEntetyEnemy();
         _step++;
         foreach (var clickReceivers in _spawnPlayer)
         {
            clickReceivers.GetComponent<SpawnPointEntityPlayer>().enabled = false;
         }
         
         foreach (var clickReceivers in _clickReceivers)
         {
            clickReceivers.GetComponent<ClickReceiver>().enabled = true;
         }
         return;
      }

      if (_step == 3)  //игрок ставит 5-й ряд стен со стороны бота
      {
         _step += _spawnStoneFifthPlayer.ArrayIsFilled();
      }
      
      if (_step == 4) //враг ставит 5-й ряд стен со стороны игрока
      {
         _spawnStoneFifthBot.StoneSpawn();
         _step++;
         foreach (var clickReceivers in _clickReceivers)
         {
            clickReceivers.GetComponent<ClickReceiver>().enabled = false;
         }
         return;
      }
      
   }
}
