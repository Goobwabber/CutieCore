using UnityEngine;

namespace CutieCore.Utilities
{
    class PluginConfig
    {
        public virtual string Cutie { get; set; } = "Pink";
        public virtual string Color { get; set; } = "#FF69B4";
        public virtual string AltColor { get; set; } = "#FFFFFF";

        public virtual Color GetColor()
		{
            Color color = UnityEngine.Color.black;
            if (!ColorUtility.TryParseHtmlString(Color, out color))
                ColorUtility.TryParseHtmlString("#FF69B4", out color);
            return color;
		}

        public virtual Color GetAltColor()
        {
            Color color = UnityEngine.Color.black;
            if (!ColorUtility.TryParseHtmlString(AltColor, out color))
                ColorUtility.TryParseHtmlString("#FFFFFF", out color);
            return color;
        }
    }
}
