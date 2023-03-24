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
   public GameObject _entetyPlayers;
   public Transform _rowEntety;

   public bool _fifthStone;
   
   // первая фаза
   private bool _nextStep;
   [SerializeField] private float _timeNextStep = 1f;
   
   [SerializeField] private RowEntety _spawnEnemy;
   [SerializeField] private SpawnStone _spawnStoneFirst;
   [SerializeField] private HorizontallyFifthStonePlayer _spawnStoneFifthBot;
   [SerializeField] private HorizontallyFifthStoneEnemy _spawnStoneFifthPlayer;
   [SerializeField] private RowEntety _rowPlayer;
   private SpawnPointEntityPlayer[] _spawnPlayer;
   private ClickReceiver[] _clickReceivers;

   [SerializeField] private TimerPlayer _timerPlayer;

   //вторая фаза
   
   [SerializeField] private MovementButtons _movementButtons;
   [SerializeField] private HorizontalMovement _horizontalMovement;
   public bool canMuvePlayer;

   private bool _timerGo;
   
   //конопки перемещения
   public GameObject _swipeObject; //сделать инкапсуляцию

   //счетчик раундов
   [SerializeField] private RoundCounter _roundCounter;
   
   //кнопка даллее
   public GameObject _nextButton;
   public GameObject gameOver;
   public GameObject victory;
   
   //-------------------------------------
   
   [SerializeField] private GameObject[] _row = new GameObject[14];
   
      
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

      if (_step is > 4 and < 12)
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
      //ставится 1-4 ряд стен
      if (_step == 0) 
      {
         _spawnStoneFirst.StoneSpawn();
         _step++;
         _row[0].SetActive(true);
         return;
      }
      
      //игрок ставит воинов
      if (_step == 1) 
      {
         _step += _rowPlayer.ArrayIsFilled();
         return;
      }

      //враг ставит воинов
      if (_step == 2) 
      {
         if (_row[0].activeSelf)
         {
            _row[0].SetActive(false); 
            _nextStep = _spawnEnemy.gameObject.GetComponent<SpawnPointEntityEnemy>().SpawnEntetyEnemy();
         }
         if (_nextStep)
         {
            Invoke(nameof(NextStep), _timeNextStep);
            _nextStep = false;
         }
         return;
      }

      //игрок ставит 5-й ряд стен со стороны бота
      if (_step == 3) 
      {
         if (_row[8].activeSelf == false) 
            _row[8].SetActive(true); 
         _step += _spawnStoneFifthPlayer.ArrayIsFilled();
      }
      
      //враг ставит 5-й ряд стен со стороны игрока
      if (_step == 4)
      {
         if (_row[8].activeSelf)
         {
            _row[8].SetActive(false);
            _nextStep = _spawnStoneFifthBot.StoneSpawn();
         }
         if (_nextStep)
         {
            Invoke(nameof(NextStep), _timeNextStep);
            _nextStep = false;
         }
      }
   }
   
 
   private void SecondPhase()
   {
      //ход игрока
      if (_step == 5)
      {
         if (_row[1].activeSelf == false)
         {
            _row[1].SetActive(true);
            _swipeObject.SetActive(true);
            _timerGo = true;
         } 
         if (_timerPlayer.Timer() == 1 && _timerGo)
         {
            _movementButtons.ButtonsMovement();
            MuvePlayer();
         }
         _nextStep = true; //для след хода
         return;
      }

      //ход бота
      if (_step == 6)
      {
         if (_nextStep)
         {
            MuveEnemy();
            _nextStep = false;
         }
         return;
      }

      //ход игрока
      if (_step == 7)
      {
         if (_row[3].activeSelf == false)
         {
            _row[3].SetActive(true);
            _swipeObject.SetActive(true);
            _timerGo = true;
         } 
         if (_timerPlayer.Timer() == 1 && _timerGo)
         {
            _movementButtons.ButtonsMovement();
            MuvePlayer();
         }
         _nextStep = true; //для след хода
         return;
      }

      //ход бота
      if (_step == 8)
      {
         if (_nextStep)
         {
            MuveEnemy();
            _nextStep = false;
         }
         return;
      }
      
      // авто-ход
      if (_step == 9)
      {
         if (_nextStep == false)
         {
            _movementButtons.ButtonsMovement();
            Invoke(nameof(NextStep), _timeNextStep);
            _nextStep = true;
         }
         return;
      }
      
      // авто-ход
      if (_step == 10)
      {
         if (_nextStep)
         {
            _movementButtons.ButtonsMovement();
            Invoke(nameof(NextStep), _timeNextStep);
            _nextStep = false;
         }
         return;
      }
      
      // бой
      if (_step == 11)
      {
         Battle();
      }
   }
   
   public void MuvePlayer()
   { 
      _row[1].SetActive(false);
      _row[3].SetActive(false);
      _swipeObject.SetActive(false);
      _timerPlayer.TimerRemove();
      _timerGo = false;
   }
   
   
   #region MuveEnemy
   private void MuveEnemy()
   {
      int x = Random.Range(-1,2);
      _horizontalMovement.HorizontalButtons(x);
      if (x != 0)
      {
         Invoke(nameof(MovementEnemy), 1);
         return;
      }
      MovementEnemy();
   }
   private void MovementEnemy()
   {
      _movementButtons.ButtonsMovement();
   }
   #endregion

   #region Battle
   private void Battle()
   {
      _step++;
      //_nextButton.SetActive(true);
      DestroyObject();
      
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
   #endregion

   #region DestroyObject
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
      victory.SetActive(false);
      gameOver.SetActive(false);
      _nextStep = false;
      _timerGo = false;
   }
   #endregion

   #region ObjectSpawn
   public GameObject ObjectSpawn(Vector3 position, GameObject prefab)
   {
      if (position.z < 7)
      {
         dataCell[(int)position.z,(int)position.x] = Instantiate(prefab, position, Quaternion.identity);
         return dataCell[(int)position.z, (int)position.x];
      }
      dataCell[(int)position.z,(int)position.x] = Instantiate(prefab, position, Quaternion.Euler(0, 180, 0));
      return dataCell[(int)position.z, (int)position.x];
   }
   #endregion
   
   #region NextStepTimer
   public void NextStepTimer(float time)
   {
      MuvePlayer();
      Invoke(nameof(NextStep), time);
   }
   #endregion
   
   #region NextStep
   private void NextStep()
   {
      _step++;
      CancelInvoke();
   }
   #endregion
}
