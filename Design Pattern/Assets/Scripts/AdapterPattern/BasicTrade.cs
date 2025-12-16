using System;
using UnityEngine;

public class BasicTrade : MonoBehaviour
{
    [SerializeField] private CreatureScriptable tradeCreatureScriptable;
    private CreatureScriptableInstance tradeCreatureInstance;

    private void Awake()
    {
        tradeCreatureInstance = new CreatureScriptableInstance(tradeCreatureScriptable);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Inventory otherInventory = other.GetComponent<Inventory>();
        CreatureScriptableInstance receiveCreature = otherInventory.GetFightCreature();
        otherInventory.SetFightCreature(tradeCreatureInstance);
        tradeCreatureInstance = receiveCreature;
    }
}
