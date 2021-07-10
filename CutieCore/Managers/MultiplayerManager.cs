using System;
using System.Runtime.CompilerServices;
using Zenject;

namespace CutieCore.Managers
{
	class MultiplayerManager : IInitializable, IDisposable
	{
		protected MultiplayerExtensions.Environments.LobbyEnvironmentManager _lobbyEnvironmentManager = null!;

		[Inject]
		internal void Inject(MultiplayerExtensions.Environments.LobbyEnvironmentManager lobbyEnvironmentManager)
		{
			_lobbyEnvironmentManager = lobbyEnvironmentManager;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Initialize()
		{
			MultiplayerExtensions.MPEvents.LobbyEnvironmentLoaded += this.HandleLobbyEnvironmentLoaded;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Dispose()
		{
			MultiplayerExtensions.MPEvents.LobbyEnvironmentLoaded -= this.HandleLobbyEnvironmentLoaded;
		}

		private void HandleLobbyEnvironmentLoaded(object sender, System.EventArgs e)
		{
			_lobbyEnvironmentManager.SetAllPlayerPlaceColors(Plugin.Config.GetColor(), true);
		}
	}
}
