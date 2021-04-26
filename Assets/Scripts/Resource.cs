using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource
{
    private int type;
    private bool hidden = true;
    private bool investigated = false;

    public Resource()
    {
        //testsprite = GameObject.Find("event_test").GetComponent<Sprite>();
    }
    public Resource(int type)
    {
        
        this.type = type;
    }
    public bool isHidden()
    {
        return hidden;
    }
    
    public void reveal()
    {
        hidden = false;
    }
    public bool isInvestigated()
    {
        return investigated;
    }
    public void investigate()
    {
        investigated = true;
    }
    public int getType()
    {
        return type;
    }

    public void setType(int rType)
    {
        type = rType;
    }
}
