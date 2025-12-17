using UnityEngine;

public class SecondGenTrade : MonoBehaviour
{
    [SerializeField] private SecondGenCreatureScriptable tradeSecondCreatureScriptable;
    [SerializeField] private int maxFireResistance = 10;
    private SecondGenCreatureScriptableInstance tradeSecondCreatureInstance;

    private void Awake()
    {
        tradeSecondCreatureInstance = new SecondGenCreatureScriptableInstance(tradeSecondCreatureScriptable);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        Inventory otherInventory = other.GetComponent<Inventory>();
        CreatureScriptableInstance receiveCreature = otherInventory.GetFightCreature();
        if (receiveCreature == null)  return;
        otherInventory.SetFightCreature(AdapterSend(tradeSecondCreatureInstance));
        tradeSecondCreatureInstance = AdapterReceive(receiveCreature);
    }

    private SecondGenCreatureScriptableInstance AdapterReceive(CreatureScriptableInstance creature)
    {
        SecondGenCreatureScriptableInstance newCreature = new SecondGenCreatureScriptableInstance(tradeSecondCreatureScriptable);
        newCreature.name = creature.name;
        newCreature.health = creature.health;
        newCreature.attack = creature.attack;
        newCreature.defense = creature.defense;
        newCreature.speed = creature.speed;
        newCreature.special = creature.special;
        newCreature.fireResistance = Random.Range(0,maxFireResistance);
        return newCreature;
    }
    
    private CreatureScriptableInstance AdapterSend(SecondGenCreatureScriptableInstance creature)
    {
        CreatureScriptableInstance newCreature = new CreatureScriptableInstance(tradeSecondCreatureScriptable);
        return newCreature;
    }
}
