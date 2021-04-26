using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Submarine
{

    public string name;

    public int damageRating;
    public int MaxDamageRating;
    public int damage;
    public int condition;
    public int maxCondition;
    public int subSize;
    public int maxSubSize;
    public int subType;
  

    public List<Card> deck;

    public Submarine()
    {
        initializeSub(1);
    }
    public Submarine(int type)
    {
        initializeSub(type);
    }

    public void initializeSub(int type)
    {
        subType = type;
        deck = new List<Card>();

        deck.Add(new Card(Constants.cardType.Explore, 1));
        deck.Add(new Card(Constants.cardType.Investigate, 1));      
        deck.Add(new Card(Constants.cardType.Maintenance, 1));

        if (subType == 1)
        {
            name = "George Class";
            damageRating = 3;
            MaxDamageRating = 3;
            subSize = 3;
            maxSubSize = 3;
            condition = 10;
            maxCondition = 14;
        }
        else if (subType == 2)
        {
            name = "Dolphin Class";
            damageRating = 2;
            MaxDamageRating = 4;
            subSize = 4;
            maxSubSize = 5;
            condition = 8;
            maxCondition = 14;
            deck.Add(new Card(Constants.cardType.Repair, 1));
        }
    }
}
