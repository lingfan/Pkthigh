#if UIWIDGETS_DATABIND_SUPPORT
namespace UIWidgets.DataBind
{
	using Slash.Unity.DataBind.Foundation.Setters;
	using UnityEngine;
	
	/// <summary>
	/// Set the Value of a Spinner depending on the System.Int32 data value.
	/// </summary>
	[AddComponentMenu("Data Bind/UIWidgets/Setters/[DB] Spinner Value Setter")]
	public class SpinnerValueSetter : ComponentSingleSetter<UIWidgets.Spinner, System.Int32>
	{
		/// <inheritdoc />
		protected override void UpdateTargetValue(UIWidgets.Spinner target, System.Int32 value)
		{
			target.Value = value;
		}
	}
}
#endif