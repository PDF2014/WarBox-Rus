using System;
using NeoModLoader.api.attributes;

namespace WarBox.Content;

internal static class WarBoxContent//, IReloadable, IUnloadable
{
    public static void Init()
    {
        if (Environment.UserName == "sourojeetshyam")
        {
            Config.isEditor = true;
        }

        WarBoxGuns.Init();
        WarBoxCulture.Init();
        WarBoxBuildings.Init();
        WarBoxGodPowers.Init();
    }
}