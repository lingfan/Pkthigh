﻿namespace UIWidgets.Styles
{
	/// <summary>
	/// Style support for the big button.
	/// </summary>
	public class StyleSupportButtonBig : StyleSupportButton, IStylable
	{
		#region IStylable implementation

		/// <summary>
		/// Set the specified style.
		/// </summary>
		/// <returns><c>true</c>, if style was set for children gameobjects, <c>false</c> otherwise.</returns>
		/// <param name="style">Style data.</param>
		public virtual bool SetStyle(Style style)
		{
			style.ButtonBig.ApplyTo(this);

			return true;
		}
		#endregion
	}
}