using HarmonyLib;
using IPA;
using IPA.Loader;
using IPALogger = IPA.Logging.Logger;
using System.Net.Http;
using SiraUtil.Zenject;
using CutieCore.HarmonyPatches;
using CutieCore.Utilities;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using IPA.Config;
using IPA.Config.Stores;
using CutieCore.Installers;

namespace CutieCore
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        public static readonly string HarmonyId = "com.github.Goobwabber.CutieCore";

        internal static Plugin Instance { get; private set; } = null!;
        internal static PluginMetadata Metadata = null!;
        internal static IPALogger Log { get; private set; } = null!;
        internal static PluginConfig Config = null!;

        internal static HttpClient HttpClient { get; private set; } = null!;
        internal static Harmony? _harmony;
        internal static Harmony Harmony
        {
            get
            {
                return _harmony ??= new Harmony(HarmonyId);
            }
        }

        [Init]
        public Plugin(IPALogger logger, Config conf, Zenjector zenjector, PluginMetadata pluginMetadata)
        {
            Instance = this;
            Metadata = pluginMetadata;
            Log = logger;
            Config = conf.Generated<PluginConfig>();
            zenjector.OnMenu<CCMenuInstaller>();
            zenjector.OnGame<CCGameInstaller>();
        }

        [OnStart]
        public void OnApplicationStart()
        {
            HarmonyManager.ApplyDefaultPatches();
        }

        [OnExit]
        public void OnApplicationQuit()
        {
            
        }
    }
}
