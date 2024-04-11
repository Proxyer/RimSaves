﻿using System.Collections.Generic;
using System.Linq;
using System;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;
using System.Reflection;
using Verse.AI;
using System.IO;

namespace aRandomKiwi.ARS
{
    internal static class MainMenuDrawer_Patch
    {
        [HarmonyPatch(typeof(MainMenuDrawer), "Init")]
        public class MainMenuDrawer_Init
        {
            [HarmonyPostfix]
            public static void Listener()
            {
                try
                {
                    /*PlayerKnowledgeDatabase.Save();
                    ShipCountdown.CancelCountdown();*/
                    //We force the display of the save menu
                    typeof(MainMenuDrawer).GetField("anyMapFiles", BindingFlags.NonPublic | BindingFlags.Static).SetValue(null,true); //").Field("anyMapFilesx").SetValue(true);

                    //return false;
                }
                catch (Exception e)
                {
                    Utils.logMsg("MainMenuDrawer.Init Error : " + e.Message);
                    //return true;
                }
            }
        }
    }
}