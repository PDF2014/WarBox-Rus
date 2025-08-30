using System;
using NeoModLoader.api.attributes;

namespace WarBox.Content;

internal static class WarBoxContent
{
    public static void Init()
    {
        WarBoxBuildings.Init();
        WarBoxGuns.Init();
        WarBoxCulture.Init();
    }
}