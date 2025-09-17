using System;
using NeoModLoader.api.attributes;

namespace WarBox.Content;

internal static class WarBoxContent
{
    public static void Init()
    {
        WarBoxMisc.Init();
        WarBoxTraits.Init();
        WarBoxBuildings.Init();
        WarBoxGuns.Init();
        WarBoxCulture.Init();
        WarBoxGodPowers.Init();
        WarBoxActors.Init();
    }
}