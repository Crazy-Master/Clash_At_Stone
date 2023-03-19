using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameMenejer : MonoBehaviour
{
   public static GameMenejer instance;
   public GameObject[,] dataCell = new GameObject[14,8];
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
   
   //вторая фаза
   
   [SerializeField] private MovementButtons _movementButtons;
   [SerializeField] private HorizontalMovement _horizontalMovement;
   public bool canMuvePlayer;
   
   //конопки перемещения
   [SerializeField] private RightBatton _rightBatton;
   [SerializeField] private LeftButton _leftButton;
   [SerializeField] private MovingButton _movingButton;
      
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
   }

   private void FixedUpdate()
   {
      if (_step < 5)
      {
         FirstPhase();
      }

      if (_step > 4 && _step < 9)
      {
         SecondPhase();
      }
      
   }

   private void FirstPhase()
   {
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
   
   private void SecondPhase()
   {
      if (_step == 5)
      {
         MuvePlayerOn();
      }

      if (_step == 6)
      {
         MuveEnemy();
      }

      if (_step == 7)
      {
         MuvePlayerOn();
      }

      if (_step == 8)
      {
         MuveEnemy();
      }
   }

   private void MuvePlayerOn()
   {
      _movingButton.gameObject.SetActive(true);
      _rightBatton.gameObject.SetActive(true);
      _leftButton.gameObject.SetActive(true);
      Debug.Log("1");

   }
   public void MuvePlayerOff()
   {
      {
         _movingButton.gameObject.SetActive(false);
         _rightBatton.gameObject.SetActive(false);
         _leftButton.gameObject.SetActive(false);
         _step++;
         Debug.Log("2");
      }
   }
   private void MuveEnemy()
   {
      int x = Random.Range(-1,2);
      _horizontalMovement.HorizontalButtons(x);
      _movementButtons.ButtonsMovement();
      _step++;
   }
}
