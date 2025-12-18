using System;
using UnityEngine;
using Random = UnityEngine.Random;


public abstract class EncounterGenerator : MonoBehaviour, IEncounter
{
    [SerializeField] private GameObject canvasCombat;
    [SerializeField] private CreatureScriptable[] enemies;
    private CreatureScriptableInstance _actualEnemy;
    private CreatureScriptableInstance _playerCreature;

    private void OnTriggerEnter2D(Collider2D other)
    {
        _playerCreature = other.GetComponent<Inventory>().GetFightCreature();
        StartFight();
    }

    protected virtual void StartFight()
    {
        canvasCombat.SetActive(true);
        _actualEnemy = PickRandomPokemon();
        EnemySpawn();
    }
    protected virtual void EnemySpawn()
    {
        if (enemies.Length > 0)
        {
            FightManager.INSTANCE.StartFight(_actualEnemy,_playerCreature);
        }
        else
        {
            Debug.LogError("There is no ennemies that can be spawned");
        }
    }

    protected virtual CreatureScriptableInstance PickRandomPokemon()
    {
        return new CreatureScriptableInstance(enemies[Random.Range(0,enemies.Length)]);
    }

    protected virtual void PauseGameWhenFight()
    {
        Time.timeScale = 0;
    }
    
}
