#if UIWIDGETS_DATABIND_SUPPORT
namespace UIWidgets.DataBind
{
	using Slash.Unity.DataBind.Foundation.Providers.Getters;
	using UnityEngine;
	
	/// <summary>
	/// Provides the SelectedItem of an FileListView.
	/// </summary>
	[AddComponentMenu("Data Bind/UIWidgets/Getters/[DB] FileListView SelectedItem Provider")]
	public class FileListViewSelectedItemProvider : ComponentDataProvider<UIWidgets.FileListView, UIWidgets.FileSystemEntry>
	{
		/// <inheritdoc />
		protected override void AddListener(UIWidgets.FileListView target)
		{
			target.OnSelectObject.AddListener(OnSelectObjectFileListView);
			target.OnDeselectObject.AddListener(OnDeselectObjectFileListView);
		}

		/// <inheritdoc />
		protected override UIWidgets.FileSystemEntry GetValue(UIWidgets.FileListView target)
		{
			return target.SelectedItem;
		}
		
		/// <inheritdoc />
		protected override void RemoveListener(UIWidgets.FileListView target)
		{
			target.OnSelectObject.RemoveListener(OnSelectObjectFileListView);
			target.OnDeselectObject.RemoveListener(OnDeselectObjectFileListView);
		}
		
		void OnSelectObjectFileListView(System.Int32 arg0)
		{
			OnTargetValueChanged();
		}

		void OnDeselectObjectFileListView(System.Int32 arg0)
		{
			OnTargetValueChanged();
		}
	}
}
#endif