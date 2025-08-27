using System;
using System.IO;
using WarBox.Content;
using WarBox.UI;
// using WarBox.UI;
using NeoModLoader.api;
using NeoModLoader.api.attributes;
using NeoModLoader.General;
using UnityEngine;

namespace WarBox;

/// <summary>
///     <para>
///         This class is the main class of the mod. It can be named as you like, be placed in any namespace, be placed
///         in any folder and be internal.
///     </para>
///     <para><see cref="BasicMod{T}" /> is a common mod class, it implements some useful functions.</para>
///     <para>
///         <see cref="IReloadable" /> let the mod can be reloaded. It's optional. If you implement this interface, you
///         can see reload button in mod list.
///     </para>
///     <para>
///         <see cref="IUnloadable"/> let the mod can be unloaded. It's optional. If you implement this interface, you
///         can "unload" this mod when disable this mod.
///     </para>
///     <para>这个类是模组的主类, 你可以把它放到任何地方, 也可以起任意的名字, 也可以设置为internal</para>
///     <para><see cref="BasicMod{T}" /> 是一个比较通用的模组基类, 它实现了一些有用的函数</para>
///     <para><see cref="IReloadable" /> 让模组可以重载. 是可选的. 如果你实现了这个接口, 你可在模组列表里看到模组重载按钮</para>
///     <para><see cref="IUnloadable"/> 让模组可以卸载. 是可选的. 如果你实现了这个接口, 你可以在禁用模组时即使"卸载"该模组</para>
/// </summary>
public class WarBox: BasicMod<WarBox>, IReloadable//, IReloadable, IUnloadable
{
    internal static Transform prefab_library;

    [Hotfixable]
    public void Reload()
    {
        
    }
    
    public void OnUnload()
    {

    }

    protected override void OnModLoad()
    {
        if (Environment.UserName == "sourojeetshyam")
        {
            Config.isEditor = true;
        }

        WarBoxContent.Init();
        WarBoxUI.Init();
    }

    public static void Called()
    {
        LogInfo("Hello World From Another!");
    }
}