// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst.WebRTC {

	using System;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[GLib.GType (typeof (Gst.WebRTC.WebRTCFECTypeGType))]
	public enum WebRTCFECType {

		None = 0,
		UlpRed = 1,
	}

	internal class WebRTCFECTypeGType {
		[DllImport ("gstwebrtc-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gst_webrtc_fec_type_get_type ();

		public static GLib.GType GType {
			get {
				return new GLib.GType (gst_webrtc_fec_type_get_type ());
			}
		}
	}
#endregion
}
