using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LoadSave
{
    public CampaignValuesSave LocalCopyOfData;
    public bool IsSceneBeingLoaded = false;

    public void SaveData()
    {
        if (!Directory.Exists("Saves"))
            Directory.CreateDirectory("Saves");

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Create("Saves/save.binary");

        createSaveObject();

        formatter.Serialize(saveFile, LocalCopyOfData);

        saveFile.Close();
    }

    public void LoadData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Open("Saves/save.binary", FileMode.Open);

        LocalCopyOfData = (CampaignValuesSave)formatter.Deserialize(saveFile);
        pushToStatic();

        saveFile.Close();
    }

    void createSaveObject()
    {
        LocalCopyOfData = new CampaignValuesSave();


        LocalCopyOfData.newCampaign = CampaignValues.newCampaign;
        LocalCopyOfData.expeditionSuccess = CampaignValues.expeditionSuccess;
        LocalCopyOfData.resources = CampaignValues.resources;
        LocalCopyOfData.money = CampaignValues.money;
        LocalCopyOfData.player = CampaignValues.player;
        LocalCopyOfData.captain = CampaignValues.captain;
        LocalCopyOfData.sub = CampaignValues.sub;
        LocalCopyOfData.ExpeditionSummary = CampaignValues.ExpeditionSummary;
    }

    void pushToStatic()

    { 

        CampaignValues.newCampaign = LocalCopyOfData.newCampaign;
        CampaignValues.expeditionSuccess = LocalCopyOfData.expeditionSuccess;
        CampaignValues.resources = LocalCopyOfData.resources;
        CampaignValues.money = LocalCopyOfData.money;
        CampaignValues.player = LocalCopyOfData.player;
        CampaignValues.captain = LocalCopyOfData.captain;
        CampaignValues.sub = LocalCopyOfData.sub;
        CampaignValues.ExpeditionSummary = LocalCopyOfData.ExpeditionSummary;
    }
}
