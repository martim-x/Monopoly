using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards
{
    public enum CardType
    {
        Street = 0,
        Utility = 1,
        Railway = 2,
        Chance = 3,
        Community = 4,
        Tax = 5,
        Jail = 6,
        ToJail = 7,
        Neutral = 8,
    }
    public string Name { get; } = "";
    public CardType cardType { get; } = CardType.Neutral;
    
    public Cards(string name, CardType cardAbility) 
    {
        Name = name;
        cardType = cardAbility;
    }
    public virtual void Ability(string player) { }
    public override string ToString()
    {
        return Name;
    }
}
