using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardActions : MonoBehaviour
{
    private ExpeditionController expeditionController;
    private SpriteRenderer m_SpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        expeditionController = GameObject.Find("GameController").GetComponent<ExpeditionController>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // discard
            Card card = expeditionController.getCard(gameObject);
            gameObject.transform.position = Constants.unloadPos;
            card.discarded = true;
            expeditionController.discardCard(card);
        }
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Card card = expeditionController.getCard(gameObject);
            switch (card.type)
            {
                case Constants.cardType.Explore:

                    if (expeditionController.isUnexploredResources())
                    {
                        expeditionController.Explore(1);
                        gameObject.transform.position = Constants.unloadPos;
                        card.discarded = true;
                        expeditionController.discardCard(card);
                    }
                    break;
                case Constants.cardType.Investigate:
                    if (expeditionController.isExploredResources())
                    {
                        expeditionController.Investigate(1);
                        gameObject.transform.position = Constants.unloadPos;
                        card.discarded = true;
                        expeditionController.discardCard(card);
                    }
                    break;
                case Constants.cardType.Repair:
                    if (expeditionController.getSubDamage() > 0)
                    {
                        expeditionController.Repair(1);
                        gameObject.transform.position = Constants.unloadPos;
                        card.discarded = true;
                        expeditionController.discardCard(card);
                    }
                    break;

                case Constants.cardType.Maintenance:
                    if (expeditionController.maintenanceRequired())
                    {
                        expeditionController.Maintenance(1);
                        gameObject.transform.position = Constants.unloadPos;
                        card.discarded = true;
                        expeditionController.discardCard(card);
                    }
                    break;
                default:
                    Debug.Log("Card Type does not exist");
                    break;
            }

        }
    }
}
