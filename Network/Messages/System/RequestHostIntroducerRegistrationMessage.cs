﻿using System;
using Network.Utils;
using Model;
using LiteNetLib.Utils;

namespace Network.Messages.System
{
	public class RequestHostIntroducerRegistrationMessage : BaseMessage
	{

		public String SystemId { get;set; }

		public RequestHostIntroducerRegistrationMessage()
			: base((ushort)CustomMessageType.RequestHostIntroducerRegistration)
		{
		}

		public override void WritePayload(NetDataWriter message)
		{
			base.WritePayload(message);
			message.Put(SystemId);
		}

		public override void ReadPayload(NetDataReader message)
		{
			base.ReadPayload(message);
			SystemId = message.GetString(100);
		}

	}
}
