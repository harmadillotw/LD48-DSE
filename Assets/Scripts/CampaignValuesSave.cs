using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class CampaignValuesSave 
{
        public  bool newCampaign { get; set; }

        public  bool expeditionSuccess { get; set; }
        public  int resources { get; set; }

        public  int money { get; set; }

        public  Player player { get; set; }

        public  Captain captain { get; set; }
        public  Submarine sub { get; set; }

        public  ExpeditionSummary ExpeditionSummary { get; set; }

}
