using System.Runtime.CompilerServices;

namespace Saltarelle.Utils
{
	/// <summary>
	/// Requirements:
	/// - jquery.js
	/// - jquery.mousewheel.js
	/// <example>
	/// <code><![CDATA[
	/// myElement.On("mousewheel", OnMouseWheel);
	/// private void OnMouseWheel(jQueryEvent e)
	/// {
	/// 	var ev = Utils.UnsafeSafeCast<jQueryEventMouseWheel>(e);
	/// 	var deltaY = ev.DeltaY;
	/// 	ev.StopImmediatePropagation();
	/// 	ev.PreventDefault();
	/// 	ev.StopPropagation();
	///		...
	/// }
	/// ]]></code>
	/// </example>
	/// 
	/// </summary>
	public class jQueryEventMouseWheel
	{
		/// <summary>
		/// How many ticks do the user has scrolled horizontally ?
		/// </summary>
		public int DeltaX
		{
			[InlineCode("{this}.deltaX")]
			get { return 0; }
		}

		/// <summary>
		/// How many ticks do the user has scrolled vertically ?
		/// </summary>
		public int DeltaY
		{
			[InlineCode("{this}.deltaY")]
			get { return 0; }
		}

		/// <summary>
		/// DeltyY * DelatFactor is the amount of pixels the user wants to scroll vertically
		/// </summary>
		public double DeltaFactor
		{
			[InlineCode("{this}.deltaFactor")]
			get { return 0; }
		}

		/// <summary>
		/// Gets whether PreventDefault has been called on this event.
		/// </summary>
		/// <returns>
		/// True if PreventDefault was called. False otherwise.
		/// </returns>
		[InlineCode("{this}.isDefaultPrevented()")]
		public bool IsDefaultPrevented()
		{
			return false;
		}

		/// <summary>
		/// Gets whether StopImmediatePropagation has been called on this event.
		/// </summary>
		/// <returns>
		/// True if StopImmediatePropagation was called. False otherwise.
		/// </returns>
		[InlineCode("{this}.isImmediatePropagationStopped()")]
		public bool IsImmediatePropagationStopped()
		{
			return false;
		}

		/// <summary>
		/// Gets whether StopPropagation has been called on this event.
		/// </summary>
		/// <returns>
		/// True if StopPropagation was called. False otherwise.
		/// </returns>
		[InlineCode("{this}.isPropagationStopped()")]
		public bool IsPropagationStopped()
		{
			return false;
		}

		/// <summary>
		/// Prevents the default action associated with the event.
		/// </summary>
		[InlineCode("{this}.preventDefault()")]
		public void PreventDefault()
		{
		}

		/// <summary>
		/// Prevents the rest of the handlers associated with the event from being invoked.
		/// </summary>
		[InlineCode("{this}.stopImmediatePropagation()")]
		public void StopImmediatePropagation()
		{
		}

		/// <summary>
		/// Prevents the event from being bubbled up the DOM tree.
		/// </summary>
		[InlineCode("{this}.stopPropagation()")]
		public void StopPropagation()
		{
		}
	}
}
