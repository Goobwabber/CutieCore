using CutieCore.Managers;
using IPA.Loader;
using Zenject;

namespace CutieCore.Installers
{
	class CCGameInstaller : Installer
	{
		public override void InstallBindings()
		{
			PluginMetadata hsvMetaData = PluginManager.GetPluginFromId("HitScoreVisualizer");

			if (hsvMetaData != null && hsvMetaData.Version >= new SemVer.Version(3, 1, 0))
				Container.BindInterfacesAndSelfTo<HSVManager>().AsSingle();
		}
	}
}
