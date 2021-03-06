#if UIWIDGETS_DATABIND_SUPPORT
namespace UIWidgets.DataBind
{
	using Slash.Unity.DataBind.Foundation.Providers.Getters;
	using UnityEngine;
	
	/// <summary>
	/// Provides the Value of an CenteredSlider.
	/// </summary>
	[AddComponentMenu("Data Bind/UIWidgets/Getters/[DB] CenteredSlider Value Provider")]
	public class CenteredSliderValueProvider : ComponentDataProvider<UIWidgets.CenteredSlider, System.Int32>
	{
		/// <inheritdoc />
		protected override void AddListener(UIWidgets.CenteredSlider target)
		{
			target.OnValuesChange.AddListener(OnValuesChangeCenteredSlider);
		}

		/// <inheritdoc />
		protected override System.Int32 GetValue(UIWidgets.CenteredSlider target)
		{
			return target.Value;
		}
		
		/// <inheritdoc />
		protected override void RemoveListener(UIWidgets.CenteredSlider target)
		{
			target.OnValuesChange.RemoveListener(OnValuesChangeCenteredSlider);
		}
		
		void OnValuesChangeCenteredSlider(System.Int32 arg0)
		{
			OnTargetValueChanged();
		}
	}
}
#endif