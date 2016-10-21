using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Accela.Apps.Core;

namespace Accela.Core.Resources
{
	public class Messages : IList<Message>
	{
		private readonly IList<Message> messages;

		private int[] messageTypeCounts;

		public Messages()
		{
			messages = new List<Message>();
			messageTypeCounts = new int[9];
		}

		public Messages(params Message[] messages) : this()
		{
			foreach (var message in messages)
				Add(message);
		}

		public Messages(params ValidationResult[] validationResults)
		{
			Add(validationResults);
		}

		private void ReCalculate()
		{
			messageTypeCounts = new int[9];

			if (messages != null && messages.Count > 0)
			{
				foreach (var message in messages)
					messageTypeCounts[(int) message.Type]++;
			}
		}

		public int Count
		{
			get { return messages.Count; }
		}

		public int GetCount(MessageType type)
		{
			return messageTypeCounts[(int) type];
		}

		public Messages Add(Message message)
		{
			if (message != null)
			{
				messages.Add(message);
				messageTypeCounts[(int) message.Type]++;
			}
			else
			{
				throw (new NullReferenceException());
			}
			return this;
		}

		public Messages Add(string value, MessageType messageType, object sender = null)
		{
			return Add(new Message {Value = value, Type = messageType, Sender = sender});
		}

		public Messages Add(Messages messages)
		{
			return Add((IEnumerable<Message>) messages);
		}


		public Messages Add(IEnumerable<Message> messages)
		{
			if (messages != null)
			{
				foreach (var item in messages)
					Add(item);
			}
			return this;
		}

		public Messages Add(IEnumerable<ValidationResult> validationResults)
		{
			if (validationResults != null)
			{
				foreach (var item in validationResults)
					Add(item);
			}
			return this;
		}

		public Messages Add(ValidationResult validationResult)
		{
			if (validationResult != null && validationResult != ValidationResult.Success)
			{
				Add(new Message
				{
					Type = MessageType.Error,
					Value = validationResult.ErrorMessage,
					Sender =
						(validationResult.MemberNames.MoreThanOne())
							? validationResult.MemberNames
							: (object) validationResult.MemberNames.FirstOrDefault()
				});
			}
			return this;
		}

		public bool Contains(MessageType messageType)
		{
			var found = false;

			if (messageTypeCounts[(int) messageType] > 0)
				found = true;

			return found;
		}

		public void Clear()
		{
			messages.Clear();
			messageTypeCounts = new int[9];
		}

		public bool ContainsError()
		{
			return Contains(MessageType.Error);
		}

		public bool NoErrors()
		{
			return (Contains(MessageType.Error) == false);
		}

		public IEnumerator<Message> GetEnumerator()
		{
			return messages.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public int IndexOf(Message message)
		{
			return messages.IndexOf(message);
		}

		public void Insert(int index, Message message)
		{
			if (message != null)
			{
				messages.Insert(index, message);
				messageTypeCounts[(int) message.Type]++;
			}
			else
			{
				throw (new NullReferenceException());
			}
		}

		public void RemoveAt(int index)
		{
			var message = messages[index];
			messages.RemoveAt(index);
			messageTypeCounts[(int) message.Type]--;
		}

		public Message this[int index]
		{
			get { return messages[index]; }
			set
			{
				var message = messages[index];
				messages[index] = value;

				if (message.Type != value.Type)
					messageTypeCounts[(int) message.Type]--;
			}
		}

		void ICollection<Message>.Add(Message message)
		{
			Add(message);
		}

		public bool Contains(Message message)
		{
			return messages.Contains(message);
		}

		public void CopyTo(Message[] array, int arrayIndex)
		{
			messages.CopyTo(array, arrayIndex);
		}

		public bool IsReadOnly
		{
			get { return false; }
		}

		public bool Remove(Message message)
		{
			RemoveAt(IndexOf(message));
			return true;
		}

		public override string ToString()
		{
			return ToString(Environment.NewLine, MessageType.Undefined);
		}

		public string ToString(string separator, MessageType messageType)
		{
			IEnumerable<Message> messages = this.messages;
			if (messageType != MessageType.Undefined)
				messages = messages.Where(x => messageType.HasFlag(x.Type));

			return messages.Select(x => x.Value).Join(separator);
		}
	}
}