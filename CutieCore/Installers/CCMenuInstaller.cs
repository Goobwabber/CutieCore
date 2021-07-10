using CutieCore.Managers;
using IPA.Loader;
using Zenject;

namespace CutieCore.Installers
{
	class CCMenuInstaller : Installer
	{
		public override void InstallBindings()
		{
			PluginMetadata customMenuTextMetaData = PluginManager.GetPluginFromId("CustomMenuText");
			PluginMetadata multiplayerExtensionsMetaData = PluginManager.GetPluginFromId("MultiplayerExtensions");
			PluginMetadata diColorsMetaData = PluginManager.GetPluginFromId("DiColors");

			if (customMenuTextMetaData != null && customMenuTextMetaData.Version >= new SemVer.Version(3, 4, 0))
				Container.BindInterfacesAndSelfTo<MenuTextManager>().AsSingle();

			if (multiplayerExtensionsMetaData != null && multiplayerExtensionsMetaData.Version >= new SemVer.Version(0, 5, 4))
				Container.BindInterfacesAndSelfTo<MultiplayerManager>().AsSingle();

			if (diColorsMetaData != null && diColorsMetaData.Version >= new SemVer.Version(1, 0, 4))
				Container.BindInterfacesAndSelfTo<DiColorsManager>().AsSingle();
		}
	}
}
