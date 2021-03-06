namespace EasyLayoutNS
{
	using System.Collections.Generic;

	/// <summary>
	/// Sizes info.
	/// </summary>
	public struct SizesInfo
	{
		/// <summary>
		/// The summary minimum size.
		/// </summary>
		public float TotalMin;

		/// <summary>
		/// The summary preferred size.
		/// </summary>
		public float TotalPreferred;

		/// <summary>
		/// The summary flexiblem size.
		/// </summary>
		public float TotalFlexible;

		/// <summary>
		/// The sizes.
		/// </summary>
		public Size[] Sizes;

		/// <summary>
		/// Serves as a hash function for a EasyLayout.SizesInfo object.
		/// </summary>
		/// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a hash table.</returns>
		public override int GetHashCode()
		{
			return TotalMin.GetHashCode() ^ TotalPreferred.GetHashCode() ^ TotalFlexible.GetHashCode() ^ Sizes.GetHashCode();
		}

		/// <summary>
		/// Determines whether the specified System.Object is equal to the current EasyLayout.SizesInfo.
		/// </summary>
		/// <param name="obj">The System.Object to compare with the current EasyLayout.Size.</param>
		/// <returns><c>true</c> if the specified System.Object is equal to the current EasyLayout.Size;
		/// otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			if (!(obj is SizesInfo))
			{
				return false;
			}

			return Equals((SizesInfo)obj);
		}

		/// <summary>
		/// Determines whether the specified EasyLayout.Size is equal to the current EasyLayout.Size.
		/// </summary>
		/// <param name="other">The EasyLayout.Size to compare with the current EasyLayout.Size.</param>
		/// <returns><c>true</c> if the specified EasyLayout.Size is equal to the current EasyLayout.Size;
		/// otherwise, <c>false</c>.</returns>
		public bool Equals(SizesInfo other)
		{
			if (TotalMin != other.TotalMin)
			{
				return false;
			}

			if (TotalPreferred != other.TotalPreferred)
			{
				return false;
			}

			if (TotalFlexible != other.TotalFlexible)
			{
				return false;
			}

			return Sizes == other.Sizes;
		}

		/// <summary>
		/// Compare sizes.
		/// </summary>
		/// <param name="sizesInfo1">First size.</param>
		/// <param name="sizesInfo2">Seconds size.</param>
		/// <returns>True if sizes are equals; otherwise false.</returns>
		public static bool operator ==(SizesInfo sizesInfo1, SizesInfo sizesInfo2)
		{
			return sizesInfo1.Equals(sizesInfo2);
		}

		/// <summary>
		/// Compare sizes.
		/// </summary>
		/// <param name="sizesInfo1">First size.</param>
		/// <param name="sizesInfo2">Seconds size.</param>
		/// <returns>True if sizes are not equals; otherwise false.</returns>
		public static bool operator !=(SizesInfo sizesInfo1, SizesInfo sizesInfo2)
		{
			return !sizesInfo1.Equals(sizesInfo2);
		}

		/// <summary>
		/// Gets the sizes info.
		/// </summary>
		/// <returns>The sizes info.</returns>
		/// <param name="sizes">Sizes.</param>
		public static SizesInfo GetSizesInfo(Size[] sizes)
		{
			var result = new SizesInfo() { Sizes = sizes };
			for (int i = 0; i < sizes.Length; i++)
			{
				result.TotalMin += sizes[i].Min;
				result.TotalPreferred += sizes[i].Preferred;
				result.TotalFlexible += sizes[i].Flexible;
			}

			if (result.TotalFlexible == 0f)
			{
				for (int i = 0; i < sizes.Length; i++)
				{
					sizes[i].Flexible = 1f;
				}

				result.TotalFlexible += sizes.Length;
			}

			return result;
		}

		/// <summary>
		/// Gets the widths sizes info.
		/// </summary>
		/// <returns>The widths sizes info.</returns>
		/// <param name="elems">Elements.</param>
		public static SizesInfo GetWidths(List<LayoutElementInfo> elems)
		{
			var sizes = new Size[elems.Count];
			for (int i = 0; i < elems.Count; i++)
			{
				sizes[i] = new Size()
				{
					Min = elems[i].MinWidth,
					Preferred = elems[i].PreferredWidth,
					Flexible = elems[i].FlexibleWidth,
				};
			}

			return GetSizesInfo(sizes);
		}

		/// <summary>
		/// Gets the heights sizes info.
		/// </summary>
		/// <returns>The heights sizes info.</returns>
		/// <param name="elems">Elements.</param>
		public static SizesInfo GetHeights(List<LayoutElementInfo> elems)
		{
			var sizes = new Size[elems.Count];
			for (int i = 0; i < elems.Count; i++)
			{
				sizes[i] = new Size()
				{
					Min = elems[i].MinHeight,
					Preferred = elems[i].PreferredHeight,
					Flexible = elems[i].FlexibleHeight,
				};
			}

			return GetSizesInfo(sizes);
		}

		/// <summary>
		/// Gets the widths sizes info.
		/// </summary>
		/// <returns>The widths sizes info.</returns>
		/// <param name="elems">Elements group.</param>
		public static SizesInfo GetWidths(List<List<LayoutElementInfo>> elems)
		{
			var sizes = new Size[elems.Count];
			for (int i = 0; i < elems.Count; i++)
			{
				sizes[i] = Size.MaxWidths(elems[i]);
			}

			return GetSizesInfo(sizes);
		}

		/// <summary>
		/// Gets the heights sizes info.
		/// </summary>
		/// <returns>The heights sizes info.</returns>
		/// <param name="elems">Elements group.</param>
		public static SizesInfo GetHeights(List<List<LayoutElementInfo>> elems)
		{
			var sizes = new Size[elems.Count];
			for (int i = 0; i < elems.Count; i++)
			{
				sizes[i] = Size.MaxHeights(elems[i]);
			}

			return GetSizesInfo(sizes);
		}
	}
}