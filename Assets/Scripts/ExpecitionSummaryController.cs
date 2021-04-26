using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExpecitionSummaryController : MonoBehaviour
{
    private Text summaryLeftText;
    private Text summaryRightText;
    private Text statusText;
    private Text arcText;
    private Text bioText;
    private Text chemText;
    private Text geoText;
    private Text physText;
    // Start is called before the first frame update
    void Start()
    {
        summaryLeftText = GameObject.Find("SummaryLeftText").GetComponent<Text>();
        summaryRightText = GameObject.Find("SummaryRightText").GetComponent<Text>();
        statusText = GameObject.Find("StatusText").GetComponent<Text>();

        arcText = GameObject.Find("ArcText").GetComponent<Text>();
        bioText = GameObject.Find("BioText").GetComponent<Text>();
        chemText = GameObject.Find("ChemText").GetComponent<Text>();
        geoText = GameObject.Find("GeoText").GetComponent<Text>();
        physText = GameObject.Find("PhysText").GetComponent<Text>();

        string leftSummary = "";
        string rightSummary = "";
        int money = 0;

        rightSummary += "Level reached: " + CampaignValues.ExpeditionSummary.levelReached + "\n";
        rightSummary += "Damage sustained: " + CampaignValues.ExpeditionSummary.damageSustained + "\n";

                if (CampaignValues.ExpeditionSummary.success)
        {
            statusText.text = "Expedition Successful\n\n";
            leftSummary += "Resources collected: " + CampaignValues.ExpeditionSummary.resourcesCollected + "\n";
            money = 0;
            money += CampaignValues.ExpeditionSummary.archaeologicalResourcesCollected * 100;
            money += CampaignValues.ExpeditionSummary.biologicalResourcesCollected * 70;
            money += CampaignValues.ExpeditionSummary.chemicalResourcesCollected * 40;
            money += CampaignValues.ExpeditionSummary.geologicalResourcesCollected * 20;
            money += CampaignValues.ExpeditionSummary.physicalResourcesCollected * 10;
        }
        else
        {
            statusText.text = "Expedition failed\n\n";
            leftSummary += "No resources collected\n";
        }


        CampaignValues.sub.damage = CampaignValues.ExpeditionSummary.damageSustained;
        CampaignValues.money += money;
        leftSummary += "Money earned: $" + money;
        summaryLeftText.text = leftSummary;
        summaryRightText.text = rightSummary;

        arcText.text = "" + CampaignValues.ExpeditionSummary.archaeologicalResourcesCollected;
        bioText.text = "" + CampaignValues.ExpeditionSummary.biologicalResourcesCollected;
        chemText.text = "" + CampaignValues.ExpeditionSummary.chemicalResourcesCollected;
        geoText.text = "" + CampaignValues.ExpeditionSummary.geologicalResourcesCollected;
        physText.text = "" + CampaignValues.ExpeditionSummary.physicalResourcesCollected;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void continueCampaign()
    {
        SceneManager.LoadScene("BaseScene");
    }
}
