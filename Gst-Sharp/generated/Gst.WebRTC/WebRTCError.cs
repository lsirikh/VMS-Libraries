// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst.WebRTC {

	using System;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[GLib.GType (typeof (Gst.WebRTC.WebRTCErrorGType))]
	public enum WebRTCError {

		DataChannelFailure = 0,
		DtlsFailure = 1,
		FingerprintFailure = 2,
		SctpFailure = 3,
		SdpSyntaxError = 4,
		HardwareEncoderNotAvailable = 5,
		EncoderError = 6,
		InvalidState = 7,
		InternalFailure = 8,
		InvalidModification = 9,
		TypeError = 10,
	}

	internal class WebRTCErrorGType {
		[DllImport ("gstwebrtc-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gst_webrtc_error_get_type ();

		public static GLib.GType GType {
			get {
				return new GLib.GType (gst_webrtc_error_get_type ());
			}
		}
	}
#endregion
}
