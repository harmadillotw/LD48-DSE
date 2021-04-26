using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    public enum resourceType
    {
        Archaeological = 0,
        Biological = 1,
        Chemical = 2,
        Geological = 3,
        Physical = 4
    }

    public static readonly string[] resoureNames = {"Archaeological",
        "Biological",
        "Chemical",
        "Ecological",
        "Physical" };

    public enum cardType
    {
        Explore,
        Investigate,
        Repair,
        Maintenance

    }
    public static string getTypeName(cardType cType)
    {
        switch(cType)
        {
            case cardType.Explore:
                return "Explore";

            case cardType.Investigate:
                return "Investigate";

            case cardType.Maintenance:
                return "Maintenance";

            case cardType.Repair:
                return "Repair";

            default:
                return "";

        }
        
    }
    public static readonly string[] cardTypeNames = {"Explore",
        "Investigate",
        "Repair",
        "Maintenance"
    };

    public static Vector2 unloadPos = new Vector2(-30f, -2f);

    public static int damageCost = 5000;
    public static int conditionCost = 1000;
    public static int sizeCost = 10000;

    public static int subPurchaseCost = 100000;
}
