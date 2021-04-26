using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ExpeditionSummary 
{

    public bool success;
    public int resourcesCollected;
    public int physicalResourcesCollected;
    public int chemicalResourcesCollected;
    public int archaeologicalResourcesCollected;
    public int geologicalResourcesCollected;
    public int biologicalResourcesCollected;
    public int levelReached;
    public int damageSustained;
    public ExpeditionSummary()
    {
        clearSummary();
    }

    public void clearSummary()
    {
        success = false;
        resourcesCollected = 0;
        physicalResourcesCollected = 0;
        chemicalResourcesCollected = 0;
        archaeologicalResourcesCollected = 0;
        geologicalResourcesCollected = 0;
        biologicalResourcesCollected = 0;
        levelReached = 0;
        damageSustained = 0;
    }
}
