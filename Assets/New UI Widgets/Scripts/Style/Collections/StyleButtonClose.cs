namespace UIWidgets.Styles
{
	using System;
	using UnityEngine;

	/// <summary>
	/// Style for close button.
	/// </summary>
	[Serializable]
	public class StyleButtonClose : IStyleDefaultValues
	{
		/// <summary>
		/// Style for the background.
		/// </summary>
		[SerializeField]
		public StyleImage Background;

		/// <summary>
		/// Style for the text.
		/// </summary>
		[SerializeField]
		public StyleText Text;

#if UNITY_EDITOR
		/// <summary>
		/// Sets the default values.
		/// </summary>
		public void SetDefaultValues()
		{
			Background.SetDefaultValues();
			Text.SetDefaultValues();
		}
#endif
	}
}