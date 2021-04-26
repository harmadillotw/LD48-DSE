using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public string name;
    public int money;
    private List<string> crew;
    public List<Card> deck;
    public int playerType;
    // Start is called before the first frame update

    public Player()
    {
        playerType = 1;
        crew = new List<string>();
        createDeck();

    }

    public Player(int type)
    {
        playerType = type;
        crew = new List<string>();
        createDeck();
    }

        private void createDeck()
    {
        deck = new List<Card>();
        // scientist
        if (playerType == 1)
        {
            deck.Add(new Card(Constants.cardType.Explore, 1));
            deck.Add(new Card(Constants.cardType.Explore, 1));
            deck.Add(new Card(Constants.cardType.Explore, 1));
            deck.Add(new Card(Constants.cardType.Investigate, 1));
            deck.Add(new Card(Constants.cardType.Investigate, 1));
            deck.Add(new Card(Constants.cardType.Investigate, 1));
            deck.Add(new Card(Constants.cardType.Maintenance, 1));
        } else if (playerType == 2)
        {
            deck.Add(new Card(Constants.cardType.Explore, 1));
            deck.Add(new Card(Constants.cardType.Explore, 1));
            deck.Add(new Card(Constants.cardType.Investigate, 1));
            deck.Add(new Card(Constants.cardType.Investigate, 1));
            deck.Add(new Card(Constants.cardType.Maintenance, 1));
            deck.Add(new Card(Constants.cardType.Maintenance, 1));
            deck.Add(new Card(Constants.cardType.Maintenance, 1));
        }
        else
        {
            deck.Add(new Card(Constants.cardType.Explore, 1));
            deck.Add(new Card(Constants.cardType.Explore, 1));
            deck.Add(new Card(Constants.cardType.Explore, 1));
            deck.Add(new Card(Constants.cardType.Investigate, 1));
            deck.Add(new Card(Constants.cardType.Investigate, 1));
            deck.Add(new Card(Constants.cardType.Investigate, 1));
            deck.Add(new Card(Constants.cardType.Maintenance, 1));
        }

    }
}
