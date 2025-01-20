using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameHandler : MonoBehaviour
{
    [SerializeField] PlayerScript[] players;
    [SerializeField] GameObject[] dices;
    int order = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!players[order].isMyMove)
        {
            if (order + 1 < players.Length)
            {
                order++; 
            }
            else
            {
                order = 0;
            }
            players[order].isMyMove = true;
            dices[0].GetComponent<DiceMovementScript>().enabled = true;
            dices[1].GetComponent<DiceMovementScript>().enabled = true;
            dices[0].GetComponent<DiceRoll>().NotPlayable = true;
            dices[1].GetComponent<DiceRoll>().NotPlayable = true;
            dices[0].GetComponent<Outline>().enabled = true;
            dices[1].GetComponent<Outline>().enabled = true;
        }
    }
    public void PayRent(string Name, int money)
    {
        foreach (var player in players)
        {
            if (player.Name == Name)
            {
                player.money += money;
                player.UpdateMoney();
            }
        }
    }
}
