using UnityEngine;
using NeoModLoader.services;

namespace WarBox.Content;

internal static class WarBoxUtils
{
    public static void WarBoxLog(string message)
    {
        LogService.LogInfo("[WarBox]: " + message);
    }

    public static void WarBoxError(string message)
    {
        LogService.LogError("[WarBox] Error:" + message);
    }
}