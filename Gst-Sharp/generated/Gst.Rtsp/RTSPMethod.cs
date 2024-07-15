// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst.Rtsp {

	using System;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[Flags]
	[GLib.GType (typeof (Gst.Rtsp.RTSPMethodGType))]
	public enum RTSPMethod : uint {

		Invalid = 0,
		Describe = 1,
		Announce = 2,
		GetParameter = 4,
		Options = 8,
		Pause = 16,
		Play = 32,
		Record = 64,
		Redirect = 128,
		Setup = 256,
		SetParameter = 512,
		Teardown = 1024,
		Get = 2048,
		Post = 4096,
	}

	internal class RTSPMethodGType {
		[DllImport ("gstrtsp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gst_rtsp_method_get_type ();

		public static GLib.GType GType {
			get {
				return new GLib.GType (gst_rtsp_method_get_type ());
			}
		}
	}
#endregion
}
