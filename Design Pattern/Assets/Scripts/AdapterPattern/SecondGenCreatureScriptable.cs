using UnityEngine;

[CreateAssetMenu(fileName = "Creature 2nd gen", menuName = "Scriptable Objects/2nd Gen Creature Scriptable")] 
public class SecondGenCreatureScriptable : CreatureScriptable
{
    public int fireResistance;
}

public class SecondGenCreatureScriptableInstance
{
    public string name;
    public int health;
    public int attack;
    public int defense;
    public int speed;
    public int special;
    public int fireResistance;

    public SecondGenCreatureScriptableInstance(SecondGenCreatureScriptable creature)
    {
        name = creature.name;
        health = creature.health;
        attack = creature.attack;
        defense = creature.defense;
        speed = creature.speed;
        special = creature.special;
        fireResistance = creature.fireResistance;
    }
}