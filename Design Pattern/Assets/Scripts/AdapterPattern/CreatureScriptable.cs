using UnityEngine;

[CreateAssetMenu(fileName = "Creature", menuName = "Scriptable Objects/Creature Scriptable")]
public class CreatureScriptable : ScriptableObject
{
    public string name;
    public int health;
    public int attack;
    public int defense;
    public int speed;
    public int special;
}

public class CreatureScriptableInstance
{
    public string name;
    public int health;
    public int attack;
    public int defense;
    public int speed;
    public int special;

    public CreatureScriptableInstance(CreatureScriptable creature)
    {
        name = creature.name;
        health = creature.health;
        attack = creature.attack;
        defense = creature.defense;
        speed = creature.speed;
        special = creature.special;
    }
}