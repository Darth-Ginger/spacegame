﻿// Copyright Gamelogic (c) http://www.gamelogic.co.za

using System;

namespace Gamelogic.Extensions
{
	/// <summary>
	/// Wraps a variable in a class that triggers an
	/// event if the value changes. This is useful when
	/// values can be meaningfully compared using Equals,
	/// and when the variable changes infrequently in
	/// comparison to the number of times it is updated.
	/// </summary>
	/// <typeparam name="T">The type of the value you want to observe</typeparam>
	/// <remarks>This is a typical use case:
	/// <code>
	/// <![CDATA[
	/// ObservedValue<bool> showWindow;
	/// 
	/// public void Start()
	/// {
	///		show = new ObservedValue(false);
	///		show.OnValueChanged += ShowHideWindow;
	/// }
	/// public void OnGUI()
	/// {
	///		showWindow.Value = GUILayout.Toggle("Show Window", showWindow.Value);
	/// }
	/// 
	/// public void ShowHideWindow()
	/// {
	///		window.gameObject.SetActive(showWindow.Value);
	/// }
	/// ]]>
	/// </code>
	/// </remarks>
	public class ObservedValue<T>
	{
		private T currentValue;

		/// <summary>
		/// Subscribe to this event to get notified when the value changes.
		/// </summary>
#pragma warning disable 0067
		public event Action OnValueChange;
#pragma warning restore 0067

		public ObservedValue(T initialValue)
		{
			currentValue = initialValue;
		}
		
		public T Value
		{
			get => currentValue;

			set
			{
				if (currentValue.Equals(value))
				{
					return;
				}
				
				currentValue = value;
				OnValueChange?.Invoke();
			}
		}

		/// <summary>
		/// Sets the value without notification.
		/// </summary>
		/// <param name="value">The value.</param>
		public void SetSilently(T value)
		{
			currentValue = value;
		}
	}
}
