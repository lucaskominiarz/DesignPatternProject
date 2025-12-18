using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


public class Inventory : MonoBehaviour
{
    [SerializeField] private TMP_Text textPokemon;
    [SerializeField] private CreatureScriptable[] allPossiblesCreatures;
    [SerializeField] private CreatureScriptable starterCreature;
    private CreatureScriptableInstance fightCreature;
    
    private int numberOfPokemon;
    private void Awake()
    {
        EventManager.onCatch += AddPokemon;
        fightCreature = new CreatureScriptableInstance(starterCreature);
    }

    private void AddPokemon()
    {
        numberOfPokemon++;
        SetFightCreature(allPossiblesCreatures[Random.Range(0,allPossiblesCreatures.Length)]);
        UpdateUi();
    }

    private void UpdateUi()
    {
        textPokemon.text = "Nombre de créatures capturées : " + numberOfPokemon;
    }

    public CreatureScriptableInstance GetFightCreature()
    {
        return fightCreature;
    }

    public void SetFightCreature(CreatureScriptable newCreature)
    {
        fightCreature = new CreatureScriptableInstance(newCreature);
    }
    public void SetFightCreature(CreatureScriptableInstance newCreature)
    {
        fightCreature = newCreature;
    }

    private void OnDestroy()
    {
        EventManager.onCatch -= AddPokemon;
    }
}
