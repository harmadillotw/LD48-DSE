using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExpeditionController : MonoBehaviour
{
    public GameObject exploreCardPrefab;
    public GameObject investigateCardPrefab;
    public GameObject repairCardPrefab;
    public GameObject maintenanceCardPrefab;

    public GameObject resourceHiddenPrefab;
    public int deckSize = 10;

    public Sprite testSprite;
    public Sprite hiddenResourceSprite;
    public Sprite hiddenPhysicalSprite;
    public Sprite hiddenChemicalSprite;
    public Sprite hiddenArchaeologicalSprite;
    public Sprite hiddenGeologicalSprite;
    public Sprite hiddenBiologicalSprite;

    public AudioClip decendClip;
    public AudioClip damageClip;
    public AudioClip discoveryClip;
    public AudioClip maintenanceClip;
    public AudioClip exploreClip;

    public AudioSource audioSource;


    private int maxHandSize = 5;
    private int currentHandSize = 0;
    public int maxTokens = 5;
    private int level = 0;
    private int maxResources = 5;

    private int unexploredResources = 0;

    private int resourcesCollected = 0;
    private int physicalResourcesCollected = 0;
    private int chemicalResourcesCollected = 0;
    private int archaeologicalResourcesCollected = 0;
    private int geologicalResourcesCollected = 0;
    private int biologicalResourcesCollected = 0;

    private int maxSubCondition = 10;
    private int subCondition = 10;
    private int maxSubDamage = 3;
    private int subDamage = 0;

    private Text levelText;
    private Text resourcesCollectedText;
    private Text conditionText;
    private Text damageText;

    private Button deeperButton;
    private Button surfaceButton;
    private GameObject surfaceBack;
    private GameObject depthBack;
    private GameObject submarine;

    private GameObject depthBack2;
    private GameObject depthBack3;
    private GameObject depthBack4;
    private GameObject depthBack5;
    private GameObject depthBack6;

    private int exploredResources = 0;



    //private List<GameObject> cardsGameObjects;
    private Player player;

    private List<Card> cardDeck;
    private Queue<Card> cardDeckQueue;
    private List<Card> cardHand;
    private List<Card> cardDiscard;
    //private List<Card> deck;
    private int cardDrawn = 0;
    private GameObject[] resourcesGameObjects;
    private Dictionary<Card, GameObject> cardsToGameObjects;
    private Dictionary< GameObject, Card> gameObjectToCards;

    private Dictionary<Resource, GameObject> resourceToGameObject;
    private Dictionary<GameObject, Resource> gameObjectToResource;

    //private Resource[] resources;

    private Vector2 unloadPos = new Vector2(-30f, -2f);

    private Vector2 backgroundLoadPos = new Vector2(0f, 0f);

    public Color cWhite = new Color(255f, 255f, 255f, 1f);

    private Level currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        resourcesCollectedText = GameObject.Find("ResourcesCollectedText").GetComponent<Text>();
        conditionText = GameObject.Find("ConditionText").GetComponent<Text>();
        damageText = GameObject.Find("DamageText").GetComponent<Text>();
        deeperButton = GameObject.Find("DeeperButton").GetComponent<Button>();
        surfaceButton = GameObject.Find("SurfaceButton").GetComponent<Button>();
        surfaceBack = GameObject.Find("SurfaceBackground");
        depthBack = GameObject.Find("DepthBackground");
        depthBack2 = GameObject.Find("ocean_back2");
        depthBack3 = GameObject.Find("ocean_back3");
        depthBack4 = GameObject.Find("ocean_back4");
        depthBack5 = GameObject.Find("ocean_back5");
        depthBack6 = GameObject.Find("ocean_back6");
        


        submarine = GameObject.Find("Submarine");


        updateConditionText();

        subDamage = CampaignValues.sub.damage;

        maxHandSize = CampaignValues.sub.subSize;

        updateDamageText();
        //create deck
        player = CampaignValues.player;


        cardsToGameObjects = new Dictionary<Card, GameObject>();
        gameObjectToCards = new Dictionary<GameObject, Card>();

        resourceToGameObject = new Dictionary<Resource, GameObject>();
        gameObjectToResource = new Dictionary<GameObject, Resource>();

        resourcesGameObjects = new GameObject[maxResources];

        cardDeckQueue = new Queue<Card>();
        cardDeck = new List<Card>();
        cardHand = new List<Card>();
        cardDiscard = new List<Card>();

        // Add the player cards to the deck.

        //for (int i = 0; i < player.deck.Count ; i++)
        for (int i = 0; i < CampaignValues.player.deck.Count; i++)
            {
            addCardToDeck(CampaignValues.player.deck[i]);
            //GameObject cardPrefab; 
            //switch (player.deck[i].type)
            //{
            //    case Constants.cardType.Explore:
            //        cardPrefab = exploreCardPrefab;
            //            break;
            //    case Constants.cardType.Investigate:
            //        cardPrefab = investigateCardPrefab;
            //            break;
            //    case Constants.cardType.Repair:
            //        cardPrefab = repairCardPrefab;
            //            break;
            //    case Constants.cardType.Maintenance:
            //        cardPrefab = maintenanceCardPrefab;
            //            break;
            //    default:
            //        cardPrefab = exploreCardPrefab;
            //        break;

            //}
            //GameObject CardGO= (GameObject)Instantiate(cardPrefab, unloadPos, Quaternion.identity);
            //cardsToGameObjects.Add(player.deck[i], CardGO);
            //gameObjectToCards.Add(CardGO, player.deck[i]);
            //cardDeck.Add(player.deck[i]);
        }
        for (int i = 0; i < CampaignValues.sub.deck.Count; i++)
        {
            addCardToDeck(CampaignValues.sub.deck[i]);
        }
            // Add the Submarine cards to the deck.

            // Shuffle the deck
            cardDeck = Utils.shuffleList(cardDeck);
        for (int i = 0; i < cardDeck.Count; i++)
        {
            cardDeckQueue.Enqueue(cardDeck[i]);
        }
        cardDeck.Clear();
        for (int i = 0; i < maxResources; i++)
        {
            resourcesGameObjects[i] = (GameObject)Instantiate(resourceHiddenPrefab, unloadPos, Quaternion.identity);
        }
        // TODO set image;
        doGoDeeper(false);
    }

    private void addCardToDeck(Card card)
    {
        GameObject cardPrefab;
        switch (card.type)
        {
            case Constants.cardType.Explore:
                cardPrefab = exploreCardPrefab;
                break;
            case Constants.cardType.Investigate:
                cardPrefab = investigateCardPrefab;
                break;
            case Constants.cardType.Repair:
                cardPrefab = repairCardPrefab;
                break;
            case Constants.cardType.Maintenance:
                cardPrefab = maintenanceCardPrefab;
                break;
            default:
                cardPrefab = exploreCardPrefab;
                break;

        }
        GameObject CardGO = (GameObject)Instantiate(cardPrefab, unloadPos, Quaternion.identity);
        cardsToGameObjects.Add(card, CardGO);
        gameObjectToCards.Add(CardGO, card);
        cardDeck.Add(card);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void playAudio(AudioClip clip)
    {
        int volumeSet = PlayerPrefs.GetInt("volumeSet");
        float vol = 1f;
        if(volumeSet > 0)
        {
            int volume = PlayerPrefs.GetInt("volume");
            vol = (float)volume / 100f;
        }

        audioSource.PlayOneShot(clip, vol);
    }
    public void goDeeper()
    {
        doGoDeeper(true);
    }
    public void doGoDeeper(bool condition)
    {

        if (condition)
        {
            //audioSource.PlayOneShot(decendClip, 1f);
            playAudio(decendClip);
        }
        updateLevel();

        updateResources();

        if (condition)
        {
            reduceCondition(1);
        }
        doRest(false);


    }

    public void updateLevel()
    {
        /* Level Block */
        level++;

        levelText.text = "Level: " + level;
        updateLevelBackground();
        currentLevel = new Level();

        exploredResources = 0;

    }

    public void updateLevelBackground()
    {
        depthBack.transform.position = unloadPos;    
        depthBack2.transform.position = unloadPos;
        depthBack3.transform.position = unloadPos;
        depthBack4.transform.position = unloadPos;
        depthBack5.transform.position = unloadPos;
        depthBack6.transform.position = unloadPos;

        if (level < 5)
        {
            depthBack.transform.position = backgroundLoadPos;
            return;
        }
        if (level < 10)
        {
            depthBack2.transform.position = backgroundLoadPos;
            return;
        }
        if (level < 15)
        {
            depthBack3.transform.position = backgroundLoadPos;
            return;
        }
        if (level < 20)
        {
            depthBack4.transform.position = backgroundLoadPos;
            return;
        }
        if (level < 25)
        {
            depthBack5.transform.position = backgroundLoadPos;
            return;
        }
        depthBack5.transform.position = backgroundLoadPos;
    }

    public void updateResources()
    {
        /* Resource Block */

        resourceToGameObject.Clear();
        gameObjectToResource.Clear();
        for (int i = 0; i < maxResources; i++)
        {
            resourcesGameObjects[i].transform.position = unloadPos;
            resourcesGameObjects[i].GetComponent<ResourceActions>().updateSprite(hiddenResourceSprite);
        }
        unexploredResources = 0;
        // create Resources
        float xValue = -3f;
        for (int i = 0; i < currentLevel.numResources; i++)
        {
            xValue += 1.5f;

            resourcesGameObjects[i].transform.position = new Vector2(xValue, 3.6f);
            resourceToGameObject.Add(currentLevel.resources[i], resourcesGameObjects[i]);
            gameObjectToResource.Add(resourcesGameObjects[i], currentLevel.resources[i]);
            unexploredResources++;

        }
    }

    private void updateHand()
    {
        /* Hand Block */
        float startX = (float)maxHandSize / 2f * 2.1f * -1;

        foreach (KeyValuePair<Card, GameObject> keyValue in cardsToGameObjects)
        {
            GameObject cardGo = keyValue.Value;
            cardGo.transform.position = unloadPos;
            cardGo.GetComponent<SpriteRenderer>().color = cWhite;
        }
        int iter = 0;

        while ((iter < maxHandSize) &&  (cardDeckQueue.Count > 0))

        //foreach (KeyValuePair<Card, GameObject> keyValue in cardsToGameObjects)
        {
            float xPos = startX + (2.1f * iter);
            GameObject cardGO;
            Card card = cardDeckQueue.Dequeue();
            if (cardsToGameObjects.TryGetValue(card, out cardGO))
            {
                cardGO.transform.position = new Vector2(xPos, -2f);
                iter++;
                cardHand.Add(card);               
            }
            else
            {
                continue;
            }
        }
    }

    public void surface()
    {
        Debug.Log("Surface");
        returnToBase(true);
        //level = 0;
        //levelText.text = "Level: " + level;
        //deeperButton.GetComponentInChildren<Text>().text = "Start Expedition";
        
    }

    private void returnToBase(bool success)
    {
        CampaignValues.ExpeditionSummary.levelReached = level;
        CampaignValues.ExpeditionSummary.damageSustained = subDamage;
        CampaignValues.ExpeditionSummary.success = success;
        if (success)
        {
            CampaignValues.ExpeditionSummary.resourcesCollected = resourcesCollected;
            CampaignValues.ExpeditionSummary.physicalResourcesCollected = physicalResourcesCollected;
            CampaignValues.ExpeditionSummary.chemicalResourcesCollected = chemicalResourcesCollected;
            CampaignValues.ExpeditionSummary.archaeologicalResourcesCollected = archaeologicalResourcesCollected;
            CampaignValues.ExpeditionSummary.geologicalResourcesCollected = geologicalResourcesCollected;
            CampaignValues.ExpeditionSummary.biologicalResourcesCollected = biologicalResourcesCollected;

        }


    SceneManager.LoadScene("ExpeditionSummaryScene");
    }

    public void Explore(int count)
    {
        //audioSource.PlayOneShot(exploreClip, 1f);
        playAudio(exploreClip);
        int explored = 0;
        int i = 0;
        while ((i < currentLevel.numResources) && (explored < count))
        {
            if (currentLevel.resources[i].isHidden())
            {
                //currentLevel.resources[i].reveal();
                currentLevel.resources[i].reveal();
                GameObject resourceGO;
                resourceToGameObject.TryGetValue(currentLevel.resources[i], out resourceGO);
               switch (currentLevel.resources[i].getType() )
                {
                    case (int)Constants.resourceType.Archaeological:
                        resourceGO.GetComponent<ResourceActions>().updateSprite(hiddenArchaeologicalSprite);
                        break;
                    case (int)Constants.resourceType.Biological:
                        resourceGO.GetComponent<ResourceActions>().updateSprite(hiddenBiologicalSprite);
                        break;
                    case (int)Constants.resourceType.Chemical:
                        resourceGO.GetComponent<ResourceActions>().updateSprite(hiddenChemicalSprite);
                        break;
                    case (int)Constants.resourceType.Geological:
                        resourceGO.GetComponent<ResourceActions>().updateSprite(hiddenGeologicalSprite);
                        break;
                    case (int)Constants.resourceType.Physical:
                        resourceGO.GetComponent<ResourceActions>().updateSprite(hiddenPhysicalSprite);
                        break;
                    //case (int)Constants.resourceType.Danger:
                     //   resourceGO.GetComponent<ResourceActions>().updateSprite(testSprite);
                     //   break;

                    
                    default:
                        resourceGO.GetComponent<ResourceActions>().updateSprite(testSprite);
                        break;
                }
                //resourceGO.GetComponent<ResourceActions>().updateSprite(testSprite);
                explored++;
                unexploredResources--;
                exploredResources++;
            }
            i++;
        }
    }

    public void Investigate(int count)
    {
        //audioSource.PlayOneShot(discoveryClip, 1f);
        playAudio(discoveryClip);
        int i = 0;
        int investigated = 0;
        while ((i < currentLevel.numResources) && (exploredResources > 0) && investigated < count)
        {
            //if ((!currentLevel.resources[i].isHidden()) && (currentLevel.resources[i].getType() != (int)Constants.resourceType.Danger) && (!currentLevel.resources[i].isInvestigated()))
            if ((!currentLevel.resources[i].isHidden()) && (!currentLevel.resources[i].isInvestigated()))
                {
                GameObject resourceGO;
                
                
                resourceToGameObject.TryGetValue(currentLevel.resources[i], out resourceGO);
                Card resourceCard = getCard(resourceGO);
                resourceGO.transform.position = unloadPos;
                resourceGO.GetComponent<ResourceActions>().updateSprite(hiddenResourceSprite);
                currentLevel.resources[i].investigate();
                exploredResources--;
                investigated++;
                resourcesCollected++;

                switch (currentLevel.resources[i].getType())
                {
                    case (int)Constants.resourceType.Archaeological:
                        archaeologicalResourcesCollected++;
                        break;
                    case (int)Constants.resourceType.Biological:
                        biologicalResourcesCollected++;
                        break;
                    case (int)Constants.resourceType.Chemical:
                        chemicalResourcesCollected++;
                        break;
                    case (int)Constants.resourceType.Geological:
                        geologicalResourcesCollected++;
                        break;
                    case (int)Constants.resourceType.Physical:
                        physicalResourcesCollected++;
                        break;

                    default:
                        
                        break;
                }
                resourcesCollectedText.text = ("Resources Colected: " + resourcesCollected);
            }
            i++;
        }
            
    }

    public bool maintenanceRequired()
    {
        if (subCondition < maxSubCondition)
        {
            return true;
        }
        return false;
    }

    public void Maintenance (int count)
    {
        //audioSource.PlayOneShot(maintenanceClip, 1f);
        playAudio(maintenanceClip);
        improveCondition(count);
    }

    public void Repair(int count)
    {
        repairDamage(count);
    }

    public bool isUnexploredResources()
    {
        if (unexploredResources > 0)
        {
            Debug.Log("Explore");
            return true;
        }
        Debug.Log("NO Explore");
        return false;
    }
    public bool isExploredResources()
    {
        if (exploredResources > 0)
        {
            return true;
        }
        return false;
    }
    public void rest(bool condition)
    {
        doRest(true);

    }
    private void doRest(bool condition)
    {
        if (condition)
        {
            reduceCondition(2);
        }
        fillHand();
        reloadHand();
    }

    public void reduceCondition(int amount)
    {
        subCondition = subCondition - amount;
        if (subCondition < 0)
        {
            subCondition = 0;
        }
        
        updateConditionText();
        if (subCondition == 0)
        {
            sustainDamage(1);
        }
    }

    private void updateConditionText()
    {
        
        conditionText.text = "Condition: " + subCondition;
        
    }
    private void updateDamageText()
    {
        
        damageText.text = "Damage: " + subDamage;
    }

    public void improveCondition(int amount)
    {
        subCondition = subCondition + amount;
        if (subCondition > maxSubCondition)
        {
            subCondition = maxSubCondition;
        }
        updateConditionText();
    }

    public int getSubDamage()
    {
        return subDamage;
    }
    public void sustainDamage(int amount)
    {
        //audioSource.PlayOneShot(damageClip, 1f);
        playAudio(damageClip);
        subDamage = subDamage + amount;
        updateDamageText();
        if (subDamage >= maxSubDamage)
        {
            returnToBase(false);
        }
    }
        public void repairDamage(int amount)
    {
        subDamage = subDamage - amount;
        if (subDamage < 0)
        {
            subDamage = 0;
        }
        updateDamageText();
    }

    public void fillHand()
    {
        while ((cardHand.Count < maxHandSize) && (cardDeckQueue.Count > 0))
        {
            Card card = cardDeckQueue.Dequeue();
            cardHand.Add(card);
            cardDrawn++;
            currentHandSize++;
        }
        if (cardHand.Count < maxHandSize)
        {
            fillDeck();
            while ((cardHand.Count < maxHandSize) && (cardDeckQueue.Count > 0))
            {
                Card card = cardDeckQueue.Dequeue();
                cardHand.Add(card);
                cardDrawn++;
                currentHandSize++;
            }
        }
        
        //if ()
    }
    public void discardCard(Card card)
    {
        cardHand.Remove(card);
        cardDiscard.Add(card);
    }
    public void fillDeck()
    {
        foreach (Card card in cardDiscard)
        {
            cardDeck.Add(card);
        }
        cardDiscard.Clear();
        Utils.shuffleList(cardDeck);
        foreach (Card card in cardDeck)
        {
            cardDeckQueue.Enqueue(card);
        }
        cardDeck.Clear();
    }
    public Card getCard(GameObject cardGO)
    {
        Card card;
        gameObjectToCards.TryGetValue(cardGO, out card);
        return card;
    }
    private void reloadHand()
    {
        foreach (KeyValuePair<Card, GameObject> keyValue in cardsToGameObjects)
        {
            GameObject cardGo = keyValue.Value;
            cardGo.transform.position = unloadPos;
            cardGo.GetComponent<SpriteRenderer>().color = cWhite;
        }
        float startX = (float)cardHand.Count / 2f * 2.1f * -1;
        int iter = 0;
        foreach ( Card card in cardHand)
        { 
            float xPos = startX + (2.1f * iter);
            GameObject cardGO;
            if (cardsToGameObjects.TryGetValue(card, out cardGO))
            {
                cardGO.transform.position = new Vector2(xPos, -2f);
                iter++;
            }
            else
            {
                continue;
            }
        }
    }
    public Resource getResourceFromGO( GameObject resourceGO)
    {
        Resource resource;
        gameObjectToResource.TryGetValue(resourceGO, out resource);
        return resource;
    }
    
}
