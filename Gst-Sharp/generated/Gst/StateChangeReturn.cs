// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst {

	using System;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[GLib.GType (typeof (Gst.StateChangeReturnGType))]
	public enum StateChangeReturn {

		Failure = 0,
		Success = 1,
		Async = 2,
		NoPreroll = 3,
	}

	internal class StateChangeReturnGType {
		[DllImport ("gstreamer-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gst_state_change_return_get_type ();

		public static GLib.GType GType {
			get {
				return new GLib.GType (gst_state_change_return_get_type ());
			}
		}
	}
#endregion
}
