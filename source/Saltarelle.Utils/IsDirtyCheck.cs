using System;
using System.Collections.Generic;
using System.Html;
using System.Linq;
using System.Text;
using jQueryApi;

namespace Saltarelle.Utils
{
	public static class IsDirtyCheck
	{
		public static bool IsDirty = false;
		private static List<string> _originalValues = new List<string>();
		private static List<InputElement> _inputs = new List<InputElement>();
		private static List<HtmlElement> _enableElements = new List<HtmlElement>();
		private static List<HtmlElement> _disableElements = new List<HtmlElement>();

		public static void init()
		{
			jQuery.OnDocumentReady(() =>
			{
				_inputs = jQuery.Select(":input").GetElements().Cast<InputElement>().ToList();
				int id = 0;
				foreach (InputElement inp in _inputs)
				{
					inp.OnChange += OnChange;
					_originalValues.Add(inp.Value);
					id++;
				}

				_enableElements.AddRange(jQuery.Select(":input[enableOnFormIsDirty]").GetElements().Cast<HtmlElement>().ToList());
				_disableElements.AddRange(jQuery.Select(":input[disableOnFormIsDirty]").GetElements().Cast<HtmlElement>().ToList());
				Update();
			});
		}

		private static void Update()
		{
			for (int id = 0; id < _inputs.Count; id++)
			{
				if (_inputs[id].Value != _originalValues[id])
				{
					SetDirty(true);
					return;
				}
			}
			SetDirty(false);
		}

		private static void OnChange(Event @event)
		{
			Update();
		}

		private static void SetDirty(bool isDirty)
		{
			IsDirty = isDirty;
			foreach (var element in _enableElements)
			{
				if (isDirty)
					element.RemoveAttribute("disabled");
				else
					element.SetAttribute("disabled", "true");
			}
			foreach (var element in _disableElements)
			{
				if (isDirty)
					element.SetAttribute("disabled", "true"); 
				else
					element.RemoveAttribute("disabled");
			}
		}
	}
}
