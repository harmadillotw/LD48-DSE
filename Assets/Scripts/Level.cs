using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{

    public Resource[] resources;
    public int numResources = 0;

    public Level()
    {
        // set number of resources
        numResources = Random.Range(1, 4);
        // create resources
        Debug.Log("level:numResources = " + numResources);
        resources = new Resource[numResources];
        for (int i=0; i < numResources; i++)
        {
            resources[i] = new Resource(Random.Range(0, 5));
        }
    }
}
