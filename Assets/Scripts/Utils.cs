using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    static public List<T> shuffleList<T>(List<T> inputlist)
    {
        for (int i = 0; i < inputlist.Count; i++)
        {
            var temp = inputlist[i];
            int randomIndex = Random.Range(i, inputlist.Count);
            inputlist[i] = inputlist[randomIndex];
            inputlist[randomIndex] = temp;
        }
        return inputlist;
    }
}
