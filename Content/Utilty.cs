using System.Collections.Generic;
using System.Text;
using ReflectionUtility;
using NeoModLoader.api.attributes;
using NeoModLoader.General;
using UnityEngine;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace WarBox.Content;

internal static class WarBoxUtils
{
    public static Sprite[] FetchSingleSprite(string path)
    {
        var sprite = Resources.Load<Sprite>(path);
        return new Sprite[] { sprite };
    }
}