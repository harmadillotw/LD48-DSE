using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartCampaign()
    {
        SceneManager.LoadScene("BaseScene");
    }

    private void CreateCampaign()
    {
        CampaignValues.clearCampaign();
        CampaignValues.captain = new Captain();
        CampaignValues.captain.Name = "Jacques";

        CampaignValues.ExpeditionSummary = new ExpeditionSummary();
        CampaignValues.sub = new Submarine();
    }
    public void SelectEngineerCaptain()
    {
        CreateCampaign();
        CampaignValues.player = new Player(1);
        CampaignValues.player.money = 0;
        CampaignValues.captain.Name = "The Engineer";
        StartCampaign();
    }

    public void SelectScientistCaptain()
    {
        CreateCampaign();
        CampaignValues.player = new Player(2);
        CampaignValues.player.money = 0;
        CampaignValues.captain.Name = "The Engineer";
        StartCampaign();
    }
}
