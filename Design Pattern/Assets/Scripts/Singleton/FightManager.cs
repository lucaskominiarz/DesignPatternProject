using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;


public class FightManager : MonoBehaviour
{
    public static FightManager INSTANCE;

    [SerializeField] private float enemyTurnTime = 1f;
    [SerializeField] private GameObject combatCanvas;
    private CreatureScriptableInstance _enemy;
    private CreatureScriptableInstance _player;
    private int _currentPlayerHp;
    private int _currentEnemyHp;
    private bool _isPlayerTurn = true;
    private Coroutine _enemyInTurn;

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

    void StartFight(CreatureScriptableInstance enemy, CreatureScriptableInstance player)
    {
        _enemy = enemy;
        _player = player;
        _currentEnemyHp = enemy.health;
        _currentPlayerHp = player.health;
    }

    void EndTurn()
    {
        _isPlayerTurn = !_isPlayerTurn;
        if (!_isPlayerTurn)
        {
            Attack();
        }
    }

    void EndFight()
    {
        combatCanvas.SetActive(false);
        // rajouter les trucs en mode autoriser player a bouger et destoy enemy jsp 
    }

    bool CheckPlayerDeath() => _currentPlayerHp <= 0;
    bool CheckEnemyDeath() => _currentEnemyHp <= 0;
    
    
    public void Attack()
    {
        if (_isPlayerTurn)
        {
            _currentEnemyHp -= (int)(_player.attack * Random.Range(0f,_enemy.defense / 10f) + _player.special * Random.Range(0f,_enemy.defense / 10f));
            if (CheckEnemyDeath())
            {
                EndFight();
            }
            EndTurn();
        }
        else if (_enemyInTurn == null)
        {
            _enemyInTurn = StartCoroutine(EnemyTurnCoroutine());
        }
    }

    private IEnumerator EnemyTurnCoroutine()
    {
        yield return new WaitForSeconds(enemyTurnTime);
        _currentPlayerHp -= (int)(_enemy.attack * Random.Range(0f,_player.defense / 10f) + _enemy.special * Random.Range(0,_player.defense / 10f));
        if (CheckPlayerDeath())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        EndTurn();
    }

    void UpdateUi()
    {
        
    }
}
