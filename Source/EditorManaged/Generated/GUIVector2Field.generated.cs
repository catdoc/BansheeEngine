//********************************** Banshee Engine (www.banshee3d.com) **************************************************//
//************** Copyright (c) 2016-2019 Marko Pintera (marko.pintera@gmail.com). All rights reserved. *******************//
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using bs;

namespace bs.Editor
{
	/** @addtogroup GUIEditor
	 *  @{
	 */

	/// <summary>
	/// A composite GUI object representing an editor field. Editor fields are a combination of a label and an input field. 
	/// Label is optional. This specific implementation displays a Vector2 input field.
	/// </summary>
	[ShowInInspector]
	public partial class GUIVector2Field : GUIElement
	{
		private GUIVector2Field(bool __dummy0) { }
		protected GUIVector2Field() { }

		/// <summary>Creates a new GUI editor field with a label.</summary>
		/// <param name="labelContent">Content to display in the editor field label.</param>
		/// <param name="labelWidth">Width of the label in pixels.</param>
		/// <param name="style">
		/// Optional style to use for the element. Style will be retrieved from GUISkin of the GUIWidget the element is used on. 
		/// If not specified default style is used.
		/// </param>
		public GUIVector2Field(GUIContent labelContent, int labelWidth, string style = "")
		{
			Internal_create(this, ref labelContent, labelWidth, style);
		}

		/// <summary>Creates a new GUI editor field with a label.</summary>
		/// <param name="labelContent">Content to display in the editor field label.</param>
		/// <param name="style">
		/// Optional style to use for the element. Style will be retrieved from GUISkin of the GUIWidget the element is used on. 
		/// If not specified default style is used.
		/// </param>
		public GUIVector2Field(GUIContent labelContent, string style = "")
		{
			Internal_create0(this, ref labelContent, style);
		}

		/// <summary>Creates a new GUI editor field with a label.</summary>
		/// <param name="labelText">String to display in the editor field label.</param>
		/// <param name="labelWidth">Width of the label in pixels.</param>
		/// <param name="style">
		/// Optional style to use for the element. Style will be retrieved from GUISkin of the GUIWidget the element is used on. 
		/// If not specified default style is used.
		/// </param>
		public GUIVector2Field(LocString labelText, int labelWidth, string style = "")
		{
			Internal_create1(this, labelText, labelWidth, style);
		}

		/// <summary>Creates a new GUI editor field with a label.</summary>
		/// <param name="labelText">String to display in the editor field label.</param>
		/// <param name="style">
		/// Optional style to use for the element. Style will be retrieved from GUISkin of the GUIWidget the element is used on. 
		/// If not specified default style is used.
		/// </param>
		public GUIVector2Field(LocString labelText, string style = "")
		{
			Internal_create2(this, labelText, style);
		}

		/// <summary>Creates a new GUI editor field without a label.</summary>
		/// <param name="style">
		/// Optional style to use for the element. Style will be retrieved from GUISkin of the GUIWidget the element is used on. 
		/// If not specified default style is used.
		/// </param>
		public GUIVector2Field(string style = "")
		{
			Internal_create3(this, style);
		}

		/// <summary>Sets a new value in the input field.</summary>
		[ShowInInspector]
		[NativeWrapper]
		public Vector2 Value
		{
			get
			{
				Vector2 temp;
				Internal_getValue(mCachedPtr, out temp);
				return temp;
			}
			set { Internal_setValue(mCachedPtr, ref value); }
		}

		/// <summary>Checks is the input field currently active.</summary>
		[NativeWrapper]
		public bool HasInputFocus
		{
			get { return Internal_hasInputFocus(mCachedPtr); }
		}

		/// <summary>
		/// Reports the new value of the vector when the user changes the value of any of the vector components.
		/// </summary>
		public event Action<Vector2> OnValueChanged;

		/// <summary>Reports the new value of an individual vector component when the user changes it.</summary>
		public event Action<float, VectorComponent> OnComponentChanged;

		/// <summary>Triggered when the user hits the Enter key with any of the component input boxes in focus.</summary>
		public event Action<VectorComponent> OnConfirm;

		/// <summary>Sets input focus to a specific component&apos;s input box.</summary>
		public void SetInputFocus(VectorComponent component, bool focus)
		{
			Internal_setInputFocus(mCachedPtr, component, focus);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_getValue(IntPtr thisPtr, out Vector2 __output);
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_setValue(IntPtr thisPtr, ref Vector2 value);
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Internal_hasInputFocus(IntPtr thisPtr);
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_setInputFocus(IntPtr thisPtr, VectorComponent component, bool focus);
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_create(GUIVector2Field managedInstance, ref GUIContent labelContent, int labelWidth, string style);
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_create0(GUIVector2Field managedInstance, ref GUIContent labelContent, string style);
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_create1(GUIVector2Field managedInstance, LocString labelText, int labelWidth, string style);
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_create2(GUIVector2Field managedInstance, LocString labelText, string style);
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_create3(GUIVector2Field managedInstance, string style);
		private void Internal_onValueChanged(ref Vector2 p0)
		{
			OnValueChanged?.Invoke(p0);
		}
		private void Internal_onComponentChanged(float p0, VectorComponent p1)
		{
			OnComponentChanged?.Invoke(p0, p1);
		}
		private void Internal_onConfirm(VectorComponent p0)
		{
			OnConfirm?.Invoke(p0);
		}
	}

	/** @} */
}
