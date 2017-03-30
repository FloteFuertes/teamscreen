﻿using System;
using System.Threading;
using Common.Listener;
using LiteNetLib;
using LiteNetLib.Utils;
using Network;
using Network.Messages.Connection;
using Network.Messages.System;

namespace Common
{
	public class ClientThread
	{
		
		public ClientListener ClientListener { get; set; }
		public ClientManager Manager { get; set; }
		public Config.Manager ConfigManager { get; set; }

		public ClientThread()
		{
			ConfigManager = new Config.Manager();
			ClientListener = new ClientListener();

			Manager = new ClientManager(ClientListener, "teamscreen");
			ClientListener._clientManager = Manager;
		}

		public void Start()
		{
			if (!Manager.Start())
			{
				return;
			}
			Manager.Connect(ConfigManager.ClientConfig.ServerName, ConfigManager.ClientConfig.ServerPort);

			Manager.sendMessage(new RequestClientIntroducerRegistrationMessage());

		}

        public void Reconnect()
        {
            Manager.Connect(ConfigManager.ClientConfig.ServerName, ConfigManager.ClientConfig.ServerPort);

            Manager.sendMessage(new RequestClientIntroducerRegistrationMessage());
        }

		public void Stop()
		{
			Manager.Stop();
		}

	}
}
