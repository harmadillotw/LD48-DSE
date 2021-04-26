using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CampaignValues 
{
    public static bool newCampaign { get; set; }

    public static bool expeditionSuccess { get; set; }
    public static int resources { get; set; }

    public static int money { get; set; }

    public static Player player { get; set; }

    public static Captain captain { get; set; }
    public static Submarine sub { get; set; }

    public static ExpeditionSummary ExpeditionSummary { get; set; }
    public static void clearCampaign()
    {
        newCampaign = false;
        resources = 0;
        money = 0;
        player = new Player();
    }
}
