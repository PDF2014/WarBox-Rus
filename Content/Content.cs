using System;
using NeoModLoader.api.attributes;

namespace WarBox.Content;

internal static class WarBoxContent//, IReloadable, IUnloadable
{
    public static void Init()
    {
        WarBoxBuildings.Init();
        WarBoxGuns.Init();
        WarBoxCulture.Init();
        WarBoxGodPowers.Init();
    }
}