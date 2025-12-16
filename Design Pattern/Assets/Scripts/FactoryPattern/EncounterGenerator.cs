using System;
using UnityEngine;
using Random = UnityEngine.Random;


public abstract class EncounterGenerator : MonoBehaviour, IEncounter
{
    [SerializeField] private GameObject canvasCombat;
    [SerializeField] private EnemyScriptable[] enemies;
    private EnemyScriptable _actualEnemy; 

    private void OnTriggerEnter2D(Collider2D other)
    {
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
            Instantiate(enemies[Random.Range(0, enemies.Length)]); // ça marche pas faut que je crée un game object et je lui donne les valeurs apres // prefab enemie genre
            // faut faire un script ennemi qui prends dcp toutes les variables et qui peut combattre // nan pas d'instantiante enft juste 2 types d'enemies avec des scriptable pris dans le fight
        }
        else
        {
            Debug.LogError("There is no ennemies that can be spawned");
        }
    }

    protected virtual EnemyScriptable PickRandomPokemon()
    {
        return enemies[Random.Range(0,enemies.Length)];
    }

    protected virtual void PauseGameWhenFight()
    {
        Time.timeScale = 0;
    }
    
}
