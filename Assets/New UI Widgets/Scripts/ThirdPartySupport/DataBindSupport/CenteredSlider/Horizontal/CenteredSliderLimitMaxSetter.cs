#if UIWIDGETS_DATABIND_SUPPORT
namespace UIWidgets.DataBind
{
	using Slash.Unity.DataBind.Foundation.Setters;
	using UnityEngine;
	
	/// <summary>
	/// Set the LimitMax of a CenteredSlider depending on the System.Int32 data value.
	/// </summary>
	[AddComponentMenu("Data Bind/UIWidgets/Setters/[DB] CenteredSlider LimitMax Setter")]
	public class CenteredSliderLimitMaxSetter : ComponentSingleSetter<UIWidgets.CenteredSlider, System.Int32>
	{
		/// <inheritdoc />
		protected override void UpdateTargetValue(UIWidgets.CenteredSlider target, System.Int32 value)
		{
			target.LimitMax = value;
		}
	}
}
#endif