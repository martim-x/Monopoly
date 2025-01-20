using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class StreetCard : Cards
{
    public int Houses;
    public string Owner;
    public int Rent;
    public int Price;
    public Color ColorOfStreet { get; }
    public StreetCard(Color colorOfStreet,string name, string owner, int rent, int price, CardType cardAbility) : base(name, cardAbility)
    {
        Owner = owner;
        Rent = rent;
        Price = price;
        ColorOfStreet = colorOfStreet;
    }
    public void Ability(string player, StreetCard[] StreetsOfColor)
    {
        
    }
    public void Buy(string name)
    {
        Owner = name;
        Price /= 4;
    }
    public void BuyHouse()
    {
        Houses++;
        Rent *= 3;
    }
}
