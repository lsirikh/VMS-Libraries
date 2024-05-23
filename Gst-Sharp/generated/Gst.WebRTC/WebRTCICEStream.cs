// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst.WebRTC {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public partial class WebRTCICEStream : Gst.Object {

		protected WebRTCICEStream (IntPtr raw) : base(raw) {}

		protected WebRTCICEStream() : base(IntPtr.Zero)
		{
			CreateNativeObject (new string [0], new GLib.Value [0]);
		}

		[GLib.Property ("stream-id")]
		public uint StreamId {
			get {
				GLib.Value val = GetProperty ("stream-id");
				uint ret = (uint) val;
				val.Dispose ();
				return ret;
			}
		}

		public uint StreamIdField {
			get {
				unsafe {
					uint* raw_ptr = (uint*)(((byte*)Handle) + abi_info.GetFieldOffset("stream_id"));
					return (*raw_ptr);
				}
			}
		}

		static FindTransportNativeDelegate FindTransport_cb_delegate;
		static FindTransportNativeDelegate FindTransportVMCallback {
			get {
				if (FindTransport_cb_delegate == null)
					FindTransport_cb_delegate = new FindTransportNativeDelegate (FindTransport_cb);
				return FindTransport_cb_delegate;
			}
		}

		static void OverrideFindTransport (GLib.GType gtype)
		{
			OverrideFindTransport (gtype, FindTransportVMCallback);
		}

		static void OverrideFindTransport (GLib.GType gtype, FindTransportNativeDelegate callback)
		{
			unsafe {
				IntPtr* raw_ptr = (IntPtr*)(((long) gtype.GetClassPtr()) + (long) class_abi.GetFieldOffset("find_transport"));
				*raw_ptr = Marshal.GetFunctionPointerForDelegate((Delegate) callback);
			}
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate IntPtr FindTransportNativeDelegate (IntPtr inst, int component);

		static IntPtr FindTransport_cb (IntPtr inst, int component)
		{
			try {
				WebRTCICEStream __obj = GLib.Object.GetObject (inst, false) as WebRTCICEStream;
				Gst.WebRTC.WebRTCICETransport __result;
				__result = __obj.OnFindTransport ((Gst.WebRTC.WebRTCICEComponent) component);
				return __result == null ? IntPtr.Zero : __result.OwnedHandle;
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, true);
				// NOTREACHED: above call does not return.
				throw e;
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Gst.WebRTC.WebRTCICEStream), ConnectionMethod="OverrideFindTransport")]
		protected virtual Gst.WebRTC.WebRTCICETransport OnFindTransport (Gst.WebRTC.WebRTCICEComponent component)
		{
			return InternalFindTransport (component);
		}

		private Gst.WebRTC.WebRTCICETransport InternalFindTransport (Gst.WebRTC.WebRTCICEComponent component)
		{
			FindTransportNativeDelegate unmanaged = null;
			unsafe {
				IntPtr* raw_ptr = (IntPtr*)(((long) this.LookupGType().GetThresholdType().GetClassPtr()) + (long) class_abi.GetFieldOffset("find_transport"));
				unmanaged = (FindTransportNativeDelegate) Marshal.GetDelegateForFunctionPointer(*raw_ptr, typeof(FindTransportNativeDelegate));
			}
			if (unmanaged == null) return null;

			IntPtr __result = unmanaged (this.Handle, (int) component);
			return GLib.Object.GetObject(__result, true) as Gst.WebRTC.WebRTCICETransport;
		}

		static GatherCandidatesNativeDelegate GatherCandidates_cb_delegate;
		static GatherCandidatesNativeDelegate GatherCandidatesVMCallback {
			get {
				if (GatherCandidates_cb_delegate == null)
					GatherCandidates_cb_delegate = new GatherCandidatesNativeDelegate (GatherCandidates_cb);
				return GatherCandidates_cb_delegate;
			}
		}

		static void OverrideGatherCandidates (GLib.GType gtype)
		{
			OverrideGatherCandidates (gtype, GatherCandidatesVMCallback);
		}

		static void OverrideGatherCandidates (GLib.GType gtype, GatherCandidatesNativeDelegate callback)
		{
			unsafe {
				IntPtr* raw_ptr = (IntPtr*)(((long) gtype.GetClassPtr()) + (long) class_abi.GetFieldOffset("gather_candidates"));
				*raw_ptr = Marshal.GetFunctionPointerForDelegate((Delegate) callback);
			}
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate bool GatherCandidatesNativeDelegate (IntPtr inst);

		static bool GatherCandidates_cb (IntPtr inst)
		{
			try {
				WebRTCICEStream __obj = GLib.Object.GetObject (inst, false) as WebRTCICEStream;
				bool __result;
				__result = __obj.OnGatherCandidates ();
				return __result;
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, true);
				// NOTREACHED: above call does not return.
				throw e;
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Gst.WebRTC.WebRTCICEStream), ConnectionMethod="OverrideGatherCandidates")]
		protected virtual bool OnGatherCandidates ()
		{
			return InternalGatherCandidates ();
		}

		private bool InternalGatherCandidates ()
		{
			GatherCandidatesNativeDelegate unmanaged = null;
			unsafe {
				IntPtr* raw_ptr = (IntPtr*)(((long) this.LookupGType().GetThresholdType().GetClassPtr()) + (long) class_abi.GetFieldOffset("gather_candidates"));
				unmanaged = (GatherCandidatesNativeDelegate) Marshal.GetDelegateForFunctionPointer(*raw_ptr, typeof(GatherCandidatesNativeDelegate));
			}
			if (unmanaged == null) return false;

			bool __result = unmanaged (this.Handle);
			return __result;
		}


		// Internal representation of the wrapped structure ABI.
		static GLib.AbiStruct _class_abi = null;
		static public new GLib.AbiStruct class_abi {
			get {
				if (_class_abi == null)
					_class_abi = new GLib.AbiStruct (new List<GLib.AbiField>{ 
						new GLib.AbiField("find_transport"
							, Gst.Object.class_abi.Fields
							, (uint) Marshal.SizeOf(typeof(IntPtr)) // find_transport
							, null
							, "gather_candidates"
							, (uint) Marshal.SizeOf(typeof(IntPtr))
							, 0
							),
						new GLib.AbiField("gather_candidates"
							, -1
							, (uint) Marshal.SizeOf(typeof(IntPtr)) // gather_candidates
							, "find_transport"
							, null
							, (uint) Marshal.SizeOf(typeof(IntPtr))
							, 0
							),
					});

				return _class_abi;
			}
		}


		// End of the ABI representation.

		[DllImport("gstwebrtc-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gst_webrtc_ice_stream_get_type();

		public static new GLib.GType GType { 
			get {
				IntPtr raw_ret = gst_webrtc_ice_stream_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

		[DllImport("gstwebrtc-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gst_webrtc_ice_stream_find_transport(IntPtr raw, int component);

		public Gst.WebRTC.WebRTCICETransport FindTransport(Gst.WebRTC.WebRTCICEComponent component) {
			IntPtr raw_ret = gst_webrtc_ice_stream_find_transport(Handle, (int) component);
			Gst.WebRTC.WebRTCICETransport ret = GLib.Object.GetObject(raw_ret, true) as Gst.WebRTC.WebRTCICETransport;
			return ret;
		}

		[DllImport("gstwebrtc-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern bool gst_webrtc_ice_stream_gather_candidates(IntPtr raw);

		public bool GatherCandidates() {
			bool raw_ret = gst_webrtc_ice_stream_gather_candidates(Handle);
			bool ret = raw_ret;
			return ret;
		}


		static WebRTCICEStream ()
		{
			GtkSharp.GstreamerSharp.ObjectManager.Initialize ();
		}

		// Internal representation of the wrapped structure ABI.
		static GLib.AbiStruct _abi_info = null;
		static public new GLib.AbiStruct abi_info {
			get {
				if (_abi_info == null)
					_abi_info = new GLib.AbiStruct (new List<GLib.AbiField>{ 
						new GLib.AbiField("stream_id"
							, Gst.Object.abi_info.Fields
							, (uint) Marshal.SizeOf(typeof(uint)) // stream_id
							, null
							, null
							, (long) Marshal.OffsetOf(typeof(GstWebRTCICEStream_stream_idAlign), "stream_id")
							, 0
							),
					});

				return _abi_info;
			}
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct GstWebRTCICEStream_stream_idAlign
		{
			sbyte f1;
			private uint stream_id;
		}


		// End of the ABI representation.

#endregion
	}
}