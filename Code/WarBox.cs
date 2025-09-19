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
    public static bool warbox_army_limits = true;

    [Hotfixable]
    public void Reload()
    {
        var locale_dir = GetLocaleFilesDirectory(GetDeclaration());
        foreach (var file in Directory.GetFiles(locale_dir))
        {
            if (file.EndsWith(".json"))
            {
                LM.LoadLocale(Path.GetFileNameWithoutExtension(file), file);
            }
            else if (file.EndsWith(".csv"))
            {
                LM.LoadLocales(file);
            }
        }
    }

    protected override void OnModLoad()
    {
        prefab_library = new GameObject("PrefabLibrary").transform;
        prefab_library.SetParent(transform);

        if (Environment.UserName == "sourojeetshyam")
        {
            Config.isEditor = true;
        }

        WarBoxContent.Init();
        WarBoxUI.Init();

        harmony = new Harmony("com.Erex147.WarBox");
        Assembly assembly = Assembly.GetExecutingAssembly();

        try
        {
            harmony.PatchAll(assembly);
        }
        catch (Exception e)
        {
            WarBox.LogError(e.ToString());
        }
        
    }

    public static void Called()
    {
        LogInfo("Hello World From Another!");
    }
}