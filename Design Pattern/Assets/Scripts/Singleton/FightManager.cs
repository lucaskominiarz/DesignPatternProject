using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class FightManager : MonoBehaviour
{
    public static FightManager INSTANCE;

    [SerializeField] private float enemyTurnTime = 1f;
    [SerializeField] private Image imageEnemy;
    [SerializeField] private Image imagePlayer;
    [SerializeField] private PlayerController playerControllerReference;
    [SerializeField] private int healValue = 4;

    [SerializeField] private Slider playerLifeSlider;
    [SerializeField] private Slider enemyLifeSlider;

    [SerializeField] private GameObject[] endFightUnactiveGo;
    
    private CreatureScriptableInstance _enemy;
    private CreatureScriptableInstance _player;
    private int _currentPlayerHp;
    private int _currentEnemyHp;
    private bool _isPlayerTurn = true;

    private void Start()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        EventManager.onCatch += EndFight;
    }

    public void StartFight(CreatureScriptableInstance enemy, CreatureScriptableInstance player)
    {
        _enemy = enemy;
        _player = player;
        _currentEnemyHp = enemy.health;
        _currentPlayerHp = player.health;
        imageEnemy.sprite = enemy.sprite;
        imagePlayer.sprite = player.sprite;
        playerControllerReference.canMove = false;
        playerLifeSlider.maxValue = _player.health;
        enemyLifeSlider.maxValue = _enemy.health;
        UpdateUi();
    }

    void EndTurn()
    {
        UpdateUi();
        _isPlayerTurn = !_isPlayerTurn;
        if (!_isPlayerTurn)
        {
            StartCoroutine(EnemyTurnCoroutine());
        }
    }

    void EndFight()
    {
        playerControllerReference.canMove = true;
        foreach (var elem in endFightUnactiveGo)
        {
            elem.SetActive(false);
        }
        StopAllCoroutines();
    }

    bool CheckPlayerDeath() => _currentPlayerHp <= 0;
    bool CheckEnemyDeath() => _currentEnemyHp <= 0;
    
    
    public void Attack()
    {
        if (_isPlayerTurn)
        {
            _currentEnemyHp -= _player.attack - _enemy.defense / 2;
            if (CheckEnemyDeath())
            {
                EndFight();
            }
            EndTurn();
        }
    }

    public void Heal()
    {
        if (_isPlayerTurn)
        {
            _currentPlayerHp += healValue;
            UpdateUi();
            EndTurn();
        }
    }

    public void Run()
    {
        EndFight();
    }

    private IEnumerator EnemyTurnCoroutine()
    {
        yield return new WaitForSeconds(enemyTurnTime);
        _currentPlayerHp -= _enemy.attack- _player.defense / 2;
        if (CheckPlayerDeath())
        {
            Debug.Log("Loose");
            EndFight();
        }
        EndTurn();
    }

    void UpdateUi()
    {
        playerLifeSlider.value = _currentPlayerHp;
        enemyLifeSlider.value = _currentEnemyHp;
    }

    private void OnDestroy()
    {
        EventManager.onCatch -= EndFight;
    }
}
