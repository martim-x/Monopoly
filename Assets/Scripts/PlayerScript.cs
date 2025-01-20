using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.GridLayoutGroup;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] MovementScript pathContainer;
    Transform[] path;
    [SerializeField] GameObject dice1;
    [SerializeField] GameObject dice2;
    bool isSupposedToMove = false;
    public bool DoesDiceKnown = false;
    public bool isMyMove = false;
    int MoveSum = 0;

    public string Name;
    public int money = 1500;
    public int housesLeft = 16;
    public GameObject dataPanel;
    public GameObject alertPanel;
    public bool isInJail = false;
    [SerializeField] Button button;


    List<Cards> map = new List<Cards>()
    {
        new Cards("Go", Cards.CardType.Neutral),
        new StreetCard(Color.grey,"Средиземноморский Проспект","",0,60,Cards.CardType.Street),
        new Cards("Общественный фонд", Cards.CardType.Neutral),
        new StreetCard(Color.grey,"Балтийский Проспект","",0,60,Cards.CardType.Street),
        new Cards("Подоходный Налог", Cards.CardType.Neutral),
        new Cards("Линия Чтецов", Cards.CardType.Neutral),
        new StreetCard(Color.cyan,"Восточный Проспект","",0,100,Cards.CardType.Street),
        new Cards("Шанс", Cards.CardType.Neutral),
        new StreetCard(Color.cyan,"Проспект Вермонта","",0,100,Cards.CardType.Street),
        new StreetCard(Color.cyan,"Проспект Коннектикут","",0,120,Cards.CardType.Street),

        new Cards("Возле тюрьмы", Cards.CardType.Neutral),
        new StreetCard(Color.grey,"Площадь Святого Чарльза","",0,60,Cards.CardType.Street),
        new Cards("Электроснабжающая компания", Cards.CardType.Neutral),
        new StreetCard(Color.grey,"Проспект Штатов","",0,60,Cards.CardType.Street),
        new StreetCard(Color.grey,"Проспект Вирджиния","",0,60,Cards.CardType.Street),
        new Cards("Линия Пенсильвания", Cards.CardType.Neutral),
        new StreetCard(Color.cyan,"Площадь Святого Чарльза","",0,100,Cards.CardType.Street),
        new Cards("Общественный Фонд",Cards.CardType.Neutral),
        new StreetCard(Color.cyan,"Проспект Теннесси","",0,100,Cards.CardType.Street),
        new StreetCard(Color.cyan,"Нью-Йоркский Проспект","",0,100,Cards.CardType.Street),

        new Cards("Бесплатная Парковка",Cards.CardType.Neutral),
        new StreetCard(Color.grey,"Проспект Кентуки","",0,60,Cards.CardType.Street),
        new Cards("Электроснабжающая компания", Cards.CardType.Neutral),
        new StreetCard(Color.grey,"Проспект Индиана","",0,60,Cards.CardType.Street),
        new StreetCard(Color.grey,"Проспект Иллиноис","",0,60,Cards.CardType.Street),
        new Cards("Линия B & O", Cards.CardType.Neutral),
        new StreetCard(Color.grey,"Атлантический Проспект","",0,60,Cards.CardType.Street),
        new StreetCard(Color.grey,"Венторский Проспект","",0,60,Cards.CardType.Street),
        new Cards("Водоснабжающая компания", Cards.CardType.Neutral),
        new StreetCard(Color.grey,"Марвинский сад","",0,60,Cards.CardType.Street),

        new Cards("Арест", Cards.CardType.Neutral),
        new StreetCard(Color.grey,"Тихоокеанский Проспект","",0,60,Cards.CardType.Street),
        new StreetCard(Color.grey,"Северо-Каролинский Проспект","",0,60,Cards.CardType.Street),
        new Cards("Общественный фонд", Cards.CardType.Neutral),
        new StreetCard(Color.grey,"Проспект Пенсильвания","",0,60,Cards.CardType.Street),
        new Cards("Краткая Линия", Cards.CardType.Neutral),
        new Cards("Шанс", Cards.CardType.Neutral),
        new StreetCard(Color.grey,"Парковая Площадь","",0,60,Cards.CardType.Street),
        new Cards("Общественный фонд", Cards.CardType.Neutral),
        new StreetCard(Color.grey,"Набережная","",0,60,Cards.CardType.Street),

    };
    int pos = 0;
    private void Start()
    {
        path = pathContainer.path;
    }
    void Update()
    {

    }
    private void FixedUpdate()
    {
        if (!DoesDiceKnown && isMyMove)
        {
            button.interactable = false;
            if (dice1.GetComponent<DiceRoll>().DiceNum()<0 || dice2.GetComponent<DiceRoll>().DiceNum()<0)
            {
                return;
            }
            MoveSum = dice1.GetComponent<DiceRoll>().DiceNum() + dice2.GetComponent<DiceRoll>().DiceNum();
            print(MoveSum);
            DoesDiceKnown = true;
            isSupposedToMove = true;
        }
        if (isSupposedToMove && isMyMove)
        {
            if (MoveSum > 0)
            {
                if (pos >= path.Length - 1)
                {
                    pos = -1;
                    money += 200;
                    UpdateMoney();
                }
                gameObject.transform.position = Vector3.MoveTowards(transform.position, path[pos + 1].position, 0.01f);
                if (transform.position == path[pos + 1].position)
                {
                    pos++;
                    MoveSum--;
                    print(pos);
                }
            }
            else
            {
                StandOnCard(map[pos]);
                isSupposedToMove = false;
            }
        }
    }
    void StandOnCard(Cards card)
    {
        switch (card.cardType)
        {
            case 0:
                if (((StreetCard)card).Owner == "")
                {
                    alertPanel.SetActive(true);
                    alertPanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = $"Вы приобрели {((StreetCard)card).Name} за {((StreetCard)card).Price}";
                    ((StreetCard)card).Buy(name);
                    money -= ((StreetCard)card).Price;
                }
                else if (((StreetCard)card).Owner == name && housesLeft>0 && ((StreetCard)card).Houses<4)
                {
                    alertPanel.SetActive(true);
                    alertPanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = $"Вы приобрели дом на участке {((StreetCard)card).Name} за {((StreetCard)card).Price}";
                    ((StreetCard)card).BuyHouse();
                    money -= ((StreetCard)card).Price;
                }
                else
                {
                    alertPanel.SetActive(true);
                    alertPanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = $"Вы заплатили ренту на участке {((StreetCard)card).Name}, игроку {((StreetCard)card).Owner}, в размере {((StreetCard)card).Rent}";
                    GameObject.FindGameObjectWithTag("GameHandler").GetComponent<gameHandler>().PayRent(((StreetCard)card).Name, ((StreetCard)card).Rent);
                    money -= ((StreetCard)card).Rent;
                }
                break;
        }
        UpdateMoney();
        button.interactable = true;
    }
    public void UpdateMoney()
    {
        dataPanel.transform.GetChild(1).GetComponent<Text>().text = $"Бюджет: {money}";
        dataPanel.transform.GetChild(2).GetComponent<Text>().text = $"Домов: {16-housesLeft}/{housesLeft}";
    }
}
