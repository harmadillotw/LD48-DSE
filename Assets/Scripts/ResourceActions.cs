using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceActions : MonoBehaviour
{
    public ExpeditionController expeditionController;
    // Start is called before the first frame update
    void Start()
    {
        expeditionController = GameObject.Find("GameController").GetComponent<ExpeditionController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateSprite(Sprite newSprite)
    {
        GetComponent<SpriteRenderer>().sprite = newSprite;
    }
}
