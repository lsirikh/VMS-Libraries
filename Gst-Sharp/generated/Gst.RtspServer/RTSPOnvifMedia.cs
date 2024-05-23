// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst.RtspServer {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public partial class RTSPOnvifMedia : Gst.RtspServer.RTSPMedia {

		public RTSPOnvifMedia (IntPtr raw) : base(raw) {}

		protected RTSPOnvifMedia() : base(IntPtr.Zero)
		{
			CreateNativeObject (new string [0], new GLib.Value [0]);
		}


		// Internal representation of the wrapped structure ABI.
		static GLib.AbiStruct _class_abi = null;
		static public new GLib.AbiStruct class_abi {
			get {
				if (_class_abi == null)
					_class_abi = new GLib.AbiStruct (new List<GLib.AbiField>{ 
						new GLib.AbiField("_gst_reserved"
							, Gst.RtspServer.RTSPMedia.class_abi.Fields
							, (uint) Marshal.SizeOf(typeof(IntPtr)) * 20 // _gst_reserved
							, null
							, null
							, (uint) Marshal.SizeOf(typeof(IntPtr))
							, 0
							),
					});

				return _class_abi;
			}
		}


		// End of the ABI representation.

		[DllImport("gstrtspserver-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gst_rtsp_onvif_media_get_type();

		public static new GLib.GType GType { 
			get {
				IntPtr raw_ret = gst_rtsp_onvif_media_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

		[DllImport("gstrtspserver-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern bool gst_rtsp_onvif_media_collect_backchannel(IntPtr raw);

		public bool CollectBackchannel() {
			bool raw_ret = gst_rtsp_onvif_media_collect_backchannel(Handle);
			bool ret = raw_ret;
			return ret;
		}

		[DllImport("gstrtspserver-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern uint gst_rtsp_onvif_media_get_backchannel_bandwidth(IntPtr raw);

		[DllImport("gstrtspserver-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gst_rtsp_onvif_media_set_backchannel_bandwidth(IntPtr raw, uint bandwidth);

		public uint BackchannelBandwidth { 
			get {
				uint raw_ret = gst_rtsp_onvif_media_get_backchannel_bandwidth(Handle);
				uint ret = raw_ret;
				return ret;
			}
			set {
				gst_rtsp_onvif_media_set_backchannel_bandwidth(Handle, value);
			}
		}


		static RTSPOnvifMedia ()
		{
			GtkSharp.GstreamerSharp.ObjectManager.Initialize ();
		}

		// Internal representation of the wrapped structure ABI.
		static GLib.AbiStruct _abi_info = null;
		static public new GLib.AbiStruct abi_info {
			get {
				if (_abi_info == null)
					_abi_info = new GLib.AbiStruct (new List<GLib.AbiField>{ 
						new GLib.AbiField("priv"
							, Gst.RtspServer.RTSPMedia.abi_info.Fields
							, (uint) Marshal.SizeOf(typeof(IntPtr)) // priv
							, null
							, "_gst_reserved"
							, (uint) Marshal.SizeOf(typeof(IntPtr))
							, 0
							),
						new GLib.AbiField("_gst_reserved"
							, -1
							, (uint) Marshal.SizeOf(typeof(IntPtr)) * 4 // _gst_reserved
							, "priv"
							, null
							, (uint) Marshal.SizeOf(typeof(IntPtr))
							, 0
							),
					});

				return _abi_info;
			}
		}


		// End of the ABI representation.

#endregion
	}
}
