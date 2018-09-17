using System;

namespace Game.Utils
{
	public static class Delegates
	{
		public delegate void EventHandler();
		public delegate void EventHandlerT<in T>(T value);
	}
}