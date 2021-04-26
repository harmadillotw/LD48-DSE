using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    private Text nameText;
    private Text captainText;
    private Text moneyText;
    private Text damageValueText;
    private Text repairText;
    private Text repairAllText;
    private Button repairButton;
    private Button repairAllButton;

    private LoadSave loadSaveUtil;

    // Start is called before the first frame update
    void Start()
    {
        loadSaveUtil = new LoadSave();
        //nameText = GameObject.Find("PlayerNameText").GetComponent<Text>();
        captainText = GameObject.Find("CaptainNameText").GetComponent<Text>();
        moneyText = GameObject.Find("MoneyText").GetComponent<Text>();
        damageValueText = GameObject.Find("DamgeValueText").GetComponent<Text>();

        repairText = GameObject.Find("RepairButton").GetComponentInChildren<Text>();
        repairButton = GameObject.Find("RepairButton").GetComponent<Button>();
        repairAllText = GameObject.Find("RepairAllButton").GetComponentInChildren<Text>();
        repairAllButton = GameObject.Find("RepairAllButton").GetComponent<Button>();


        updateUI();
    }

    private void updateUI()
    {
        //nameText.text = CampaignValues.player.name;
        captainText.text = "Captain: " + CampaignValues.captain.Name;
        

        updateRepairUI();
    }

    private void updateRepairUI()
    {
        moneyText.text = "Money: " + CampaignValues.money;
        damageValueText.text = "" + CampaignValues.sub.damage;
        int repairCost = CampaignValues.sub.damage * 100;
        repairText.text = "Repair 1 - $100";
        if ((CampaignValues.sub.damage == 0) || (CampaignValues.money < 100))
        {
            repairButton.GetComponent<Button>().interactable = false;
            repairAllButton.GetComponent<Button>().interactable = false;
            repairAllText.text = "Repair All";
            
        }
        else if (CampaignValues.money < repairCost)
        {
            repairAllText.text = "Repair All - $" + repairCost;
            repairButton.GetComponent<Button>().interactable = true;
            repairAllButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            
            repairAllText.text = "Repair All - $" + repairCost;
            repairButton.GetComponent<Button>().interactable = true;
            repairAllButton.GetComponent<Button>().interactable = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartExpedition()
    {
        SceneManager.LoadScene("ExpeditionScene");
    }

    public void StartCampaign()
    {
        SceneManager.LoadScene("BaseScene");
    }

    public void ViewDeck()
    {
        SceneManager.LoadScene("DeckScene");
    }
    public void UpgradeSub()
    {
        SceneManager.LoadScene("UpgradeScene");
    }

    private void CreateCampaign()
    {
        CampaignValues.clearCampaign();
        CampaignValues.captain = new Captain();
        CampaignValues.captain.Name = "Jacques";
        
        CampaignValues.ExpeditionSummary = new ExpeditionSummary();
        CampaignValues.sub = new Submarine();
    }

    public void RepairDamage()
    {
        CampaignValues.sub.damage--;
        CampaignValues.money -= 100;
        updateRepairUI();
    }
    public void RepairAllDamage()
    {
        int repairCost = CampaignValues.sub.damage * 100;
        CampaignValues.sub.damage = 0;
        CampaignValues.money -= repairCost;
        updateRepairUI();
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

    public void SaveGame()
    {
        loadSaveUtil.SaveData();
    }

    public void LoadGame()
    {
        loadSaveUtil.LoadData();
        updateUI();
    }

    public void ExitToMaimMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
