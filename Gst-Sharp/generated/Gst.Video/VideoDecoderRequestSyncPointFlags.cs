// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst.Video {

	using System;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[Flags]
	[GLib.GType (typeof (Gst.Video.VideoDecoderRequestSyncPointFlagsGType))]
	public enum VideoDecoderRequestSyncPointFlags : uint {

		DiscardInput = 1,
		CorruptOutput = 2,
	}

	internal class VideoDecoderRequestSyncPointFlagsGType {
		[DllImport ("gstvideo-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gst_video_decoder_request_sync_point_flags_get_type ();

		public static GLib.GType GType {
			get {
				return new GLib.GType (gst_video_decoder_request_sync_point_flags_get_type ());
			}
		}
	}
#endregion
}
