using System.Collections.Generic;
using System.Text;
using ReflectionUtility;
using NeoModLoader.api.attributes;
using NeoModLoader.General;
using UnityEngine;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using NeoModLoader.services;

namespace WarBox.Content;

internal static class WarBoxUtils
{
    // public static Sprite FetchSingleSprite(string path)
    // {
    //     return SpriteTextureLoader.getSprite(path);
    //     //var sprite = Resources.Load<Sprite>(path);
    //     //return new Sprite[] { sprite };
    // }

    public static void WarBoxLog(string message)
    {
        LogService.LogInfo("[WarBox]: " + message);
    }

    public static void WarBoxError(string message)
    {
        LogService.LogError("[WarBox] Error:" + message);
    }
}