using TMPro;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    [SerializeField] private TMP_Text textPokemon;
    [SerializeField] private CreatureScriptable[] allCreatures;
    
    private CreatureScriptableInstance fightCreature;
    
    private int numberOfPokemon;
    private void Awake()
    {
        EventManager.onCatch += AddPokemon;
    }

    private void AddPokemon()
    {
        numberOfPokemon++;
        SetFightCreature(allCreatures[Random.Range(0,allCreatures.Length)]);
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
}
