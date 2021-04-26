using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeckController : MonoBehaviour
{
    private Text exploreText;
    private Text investigateText;
    private Text maintenanceText;
    private Text repairText;

    private int[] capCounts;

    private int[] subCounts;

    // Start is called before the first frame update
    void Start()
    {
        exploreText = GameObject.Find("ExploreText").GetComponent<Text>();
        investigateText = GameObject.Find("InvestigateText").GetComponent<Text>();
        maintenanceText = GameObject.Find("MaintenanceText").GetComponent<Text>();
        repairText = GameObject.Find("RepairText").GetComponent<Text>();
        capCounts = new int[4];
        subCounts = new int[4];
        for (int i = 0; i < CampaignValues.player.deck.Count; i++)
        {
            updateCountCard(CampaignValues.player.deck[i], capCounts);
        }
        for (int i = 0; i < CampaignValues.sub.deck.Count; i++)
        {
            updateCountCard(CampaignValues.sub.deck[i], subCounts);
        }
        exploreText.text = "" + capCounts[(int)Constants.cardType.Explore] + "\n\n" + subCounts[(int)Constants.cardType.Explore] 
            + "\n\n" + (capCounts[(int)Constants.cardType.Explore] + subCounts[(int)Constants.cardType.Explore]);

        investigateText.text = "" + capCounts[(int)Constants.cardType.Investigate] + "\n\n" + subCounts[(int)Constants.cardType.Investigate]
            + "\n\n" + (capCounts[(int)Constants.cardType.Investigate] + subCounts[(int)Constants.cardType.Investigate]);

        maintenanceText.text = "" + capCounts[(int)Constants.cardType.Maintenance] + "\n\n" + subCounts[(int)Constants.cardType.Maintenance]
            + "\n\n" + (capCounts[(int)Constants.cardType.Maintenance] + subCounts[(int)Constants.cardType.Maintenance]);

        repairText.text = "" + capCounts[(int)Constants.cardType.Repair] + "\n\n" + subCounts[(int)Constants.cardType.Repair]
            + "\n\n" + (capCounts[(int)Constants.cardType.Repair] + subCounts[(int)Constants.cardType.Repair]);
    }
        // Update is called once per frame
    void Update()
    {

    }

    private void updateCountCard(Card card, int[] counts)
    {
        switch (card.type)
        {
            case Constants.cardType.Explore:
                counts[(int)Constants.cardType.Explore]++;
                break;
            case Constants.cardType.Investigate:
                counts[(int)Constants.cardType.Investigate]++;
                break;
            case Constants.cardType.Repair:
                counts[(int)Constants.cardType.Repair]++;
                break;
            case Constants.cardType.Maintenance:
                counts[(int)Constants.cardType.Maintenance]++;
                break;
            default:
                break;

        }

    }

    public void GoBack()
    {
        SceneManager.LoadScene("BaseScene");
    }
    
}
