#if UIWIDGETS_DATABIND_SUPPORT
namespace UIWidgets.DataBind
{
	using Slash.Unity.DataBind.Foundation.Setters;
	using UnityEngine;
	
	/// <summary>
	/// Set the ValueMin of a CenteredSliderVertical depending on the System.Int32 data value.
	/// </summary>
	[AddComponentMenu("Data Bind/UIWidgets/Setters/[DB] CenteredSliderVertical ValueMin Setter")]
	public class CenteredSliderVerticalValueMinSetter : ComponentSingleSetter<UIWidgets.CenteredSliderVertical, System.Int32>
	{
		/// <inheritdoc />
		protected override void UpdateTargetValue(UIWidgets.CenteredSliderVertical target, System.Int32 value)
		{
			target.ValueMin = value;
		}
	}
}
#endif