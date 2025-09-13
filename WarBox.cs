using System;
using System.IO;
using WarBox.Content;
using WarBox.UI;
using NeoModLoader.api;
using NeoModLoader.api.attributes;
using NeoModLoader.General;
using UnityEngine;
using System.Reflection;
using System.Collections.Generic;
using HarmonyLib;

namespace WarBox;

public class WarBox : BasicMod<WarBox>, IReloadable
{
    public static Transform prefab_library;
    internal static Harmony harmony;

    public static bool warbox_factories = true;

    [Hotfixable]
    public void Reload()
    {

    }

    public void OnUnload()
    {

    }

    protected override void OnModLoad()
    {
        prefab_library = new GameObject("PrefabLibrary").transform;
        prefab_library.SetParent(transform);

        if (Environment.UserName == "sourojeetshyam")
        {
            Config.isEditor = true;
            //DebugConfig.
        }

        WarBoxContent.Init();
        WarBoxUI.Init();

        harmony = new Harmony("com.Erex147.WarBox");
        Assembly assembly = Assembly.GetExecutingAssembly();
        harmony.PatchAll(assembly);
    }

    public static void Called()
    {
        LogInfo("Hello World From Another!");
    }
}