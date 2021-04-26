using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour
{
    private Text damageText;
    private Text conditionText;
    private Text sizeText;
    private Text moneyText;
    private Text nameText;
    private Text deckText;

    private GameObject damageButton;
    private GameObject conditionButton;
    private GameObject sizeButton;

    private GameObject salesPanel;
    // Start is called before the first frame update
    void Start()
    {
        moneyText = GameObject.Find("MoneyText").GetComponent<Text>();
        nameText = GameObject.Find("NameText").GetComponent<Text>();

        damageText = GameObject.Find("DamageText").GetComponent<Text>();
        conditionText = GameObject.Find("ConditionText").GetComponent<Text>();
        sizeText = GameObject.Find("SizeText").GetComponent<Text>();
        deckText = GameObject.Find("DeckText").GetComponent<Text>();

        damageButton = GameObject.Find("UpgradeDamageButton");
        conditionButton = GameObject.Find("UpgradeConditionButton");
        sizeButton = GameObject.Find("UpgradeSizeButton");

        salesPanel = GameObject.Find("SalePanel");

        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI()
    {
        nameText.text = CampaignValues.sub.name;
        moneyText.text = "Money: " + CampaignValues.money;

        if (CampaignValues.sub.subType == 2)
        {
            salesPanel.SetActive(false);
        }
        else
        {
            salesPanel.SetActive(true);
        }

        if (CampaignValues.sub.subType == 2)
        {
            deckText.text = "Explore, Investigate, Maintenance, Repair";
        }
        else
        {
            deckText.text = "Explore, Investigate, Maintenance";
        }

        damageText.text = "Damage Rating " + CampaignValues.sub.damageRating + "/" + CampaignValues.sub.MaxDamageRating;
        damageButton.GetComponentInChildren<Text>().text = "Upgrade $" + Constants.damageCost;
        if (CampaignValues.sub.damageRating < CampaignValues.sub.MaxDamageRating)
        {
            damageButton.SetActive(true);
            if (CampaignValues.money > Constants.damageCost)
            {
                damageButton.GetComponent<Button>().interactable = true;
            }
            else
            {
                damageButton.GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            damageButton.SetActive(false);
        }
        conditionText.text = "Condition Rating " + CampaignValues.sub.condition + "/" + CampaignValues.sub.maxCondition;
        conditionButton.GetComponentInChildren<Text>().text = "Upgrade $" + Constants.conditionCost;
        if (CampaignValues.sub.condition < CampaignValues.sub.maxCondition)
        {
            conditionButton.SetActive(true);
            if (CampaignValues.money > Constants.conditionCost)
            {
                conditionButton.GetComponent<Button>().interactable = true;
            }
            else
            {
                conditionButton.GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            conditionButton.SetActive(false);
        }
        sizeText.text = "Size Rating " + CampaignValues.sub.subSize + "/" + CampaignValues.sub.maxSubSize;
        sizeButton.GetComponentInChildren<Text>().text = "Upgrade $" + Constants.sizeCost;
        if (CampaignValues.sub.subSize < CampaignValues.sub.maxSubSize)
        {
            sizeButton.SetActive(true);
            if(CampaignValues.money > Constants.sizeCost)
            {
                sizeButton.GetComponent<Button>().interactable = true;
            }
            else
            {
                sizeButton.GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            sizeButton.SetActive(false);
        }
    }
    public void GoBack()
    {
        SceneManager.LoadScene("BaseScene");
    }
    public void upgradeDamage()
    {
        if (CampaignValues.sub.damageRating < CampaignValues.sub.MaxDamageRating)
        {
            CampaignValues.sub.damageRating++;
            CampaignValues.money -= Constants.damageCost;
            UpdateUI();
        }
    }
    public void upgradeSize()
    {
        if (CampaignValues.sub.subSize < CampaignValues.sub.maxSubSize)
        {
            CampaignValues.sub.subSize++;
            CampaignValues.money -= Constants.sizeCost;
            UpdateUI();
        }
    }
    public void upgradeCondition()
    {
        if (CampaignValues.sub.condition < CampaignValues.sub.maxCondition)
        {
            CampaignValues.sub.condition++;
            CampaignValues.money -= Constants.conditionCost;
            UpdateUI();
        }
    }

    public void buySubmarine()
    {
        if (CampaignValues.money > Constants.subPurchaseCost)
        {
            CampaignValues.sub.initializeSub(2);
            UpdateUI();
        }
    }
}
