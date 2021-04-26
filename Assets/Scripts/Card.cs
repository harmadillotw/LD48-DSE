using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Card 
{
    public Constants.cardType type;
    public bool active = false;
    public int value = 1;
    public bool discarded = false;

    public Card()
    {

    }
    public Card(Constants.cardType type, int value )
    {
        this.type = type;
        this.value = value;
    }

}
