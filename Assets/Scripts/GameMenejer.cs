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
   
   //счетчик раундов
   [SerializeField] private RoundCounter _roundCounter;
   
   //кнопка даллее
   [SerializeField] private GameObject _nextButton;
      
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

      if (_step > 4 && _step < 12)
      {
         SecondPhase();
      }

      // if (_step == 12)
      // {
      //    DestroyObject();
      // }
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
      
      if (_step == 9)
      {
         _movementButtons.ButtonsMovement();
         _step++;
      }
      
      if (_step == 10)
      {
         _movementButtons.ButtonsMovement();
         _step++;
      }
      
      if (_step == 11)
      {
         Battle();
         _step++;
         _nextButton.SetActive(true);
      }
   }

   private void MuvePlayerOn()
   {
      _movingButton.gameObject.SetActive(true);
      _rightBatton.gameObject.SetActive(true);
      _leftButton.gameObject.SetActive(true);

   }
   public void MuvePlayerOff()
   {
      {
         _movingButton.gameObject.SetActive(false);
         _rightBatton.gameObject.SetActive(false);
         _leftButton.gameObject.SetActive(false);
         _step++;
      }
   }
   private void MuveEnemy()
   {
      int x = Random.Range(-1,2);
      _horizontalMovement.HorizontalButtons(x);
      _horizontalMovement.HorizontalButtons(x);
      _movementButtons.ButtonsMovement();
      _step++;
   }

   private void Battle()
   {
      var powerPlaer = 0;
      var powerEnemy = 0;
      for (int i = 0; i < 8; i++)
      {
         if (dataCell[6, i] != null)
         {
            powerPlaer = powerPlaer + dataCell[6, i].GetComponent<VarreorEntety>().strength;
         }
         if (dataCell[7, i] != null)
         {
            powerEnemy = powerEnemy + dataCell[7, i].GetComponent<VarreorEntety>().strength;
         }
      }

      if (powerPlaer > powerEnemy)
      {
         Debug.Log("победил Plaer");
         _roundCounter.Counter(1); //1- победил игрок, 2- победил врак, 3- ничья
         return;
      }

      if (powerPlaer < powerEnemy)
      {
         Debug.Log("победил Enemy");
         _roundCounter.Counter(2);
         return;
      }
      Debug.Log("ничья");
      _roundCounter.Counter(3);
   }

   public void DestroyObject()
   {
      _step = 0;
      for (int z = 0; z < 14; z++)
      {
         for (int x = 0; x < 8; x++)
         {
            if (dataCell[z,x] != null)
            {
               Destroy(dataCell[z,x]);
            }
         }
      }

      _horizontalMovement.transform.position = new Vector3(0, 0, 0);
      _roundCounter.ResetColor();  // сброс цветов с счетчика раундов
      dataCell = new GameObject[14, 8];
      _nextButton.SetActive(false);
   }
}
