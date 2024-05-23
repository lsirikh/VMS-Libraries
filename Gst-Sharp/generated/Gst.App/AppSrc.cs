// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst.App {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public partial class AppSrc : Gst.Base.BaseSrc, Gst.IURIHandler {

		public AppSrc (IntPtr raw) : base(raw) {}

		protected AppSrc() : base(IntPtr.Zero)
		{
			CreateNativeObject (new string [0], new GLib.Value [0]);
		}

		[GLib.Property ("block")]
		public bool Block {
			get {
				GLib.Value val = GetProperty ("block");
				bool ret = (bool) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value(value);
				SetProperty("block", val);
				val.Dispose ();
			}
		}

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gst_app_src_get_caps(IntPtr raw);

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gst_app_src_set_caps(IntPtr raw, IntPtr caps);

		[GLib.Property ("caps")]
		public Gst.Caps Caps {
			get  {
				IntPtr raw_ret = gst_app_src_get_caps(Handle);
				Gst.Caps ret = raw_ret == IntPtr.Zero ? null : (Gst.Caps) GLib.Opaque.GetOpaque (raw_ret, typeof (Gst.Caps), true);
				return ret;
			}
			set  {
				gst_app_src_set_caps(Handle, value == null ? IntPtr.Zero : value.Handle);
			}
		}

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern ulong gst_app_src_get_current_level_buffers(IntPtr raw);

		[GLib.Property ("current-level-buffers")]
		public ulong CurrentLevelBuffers {
			get  {
				ulong raw_ret = gst_app_src_get_current_level_buffers(Handle);
				ulong ret = raw_ret;
				return ret;
			}
		}

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern ulong gst_app_src_get_current_level_bytes(IntPtr raw);

		[GLib.Property ("current-level-bytes")]
		public ulong CurrentLevelBytes {
			get  {
				ulong raw_ret = gst_app_src_get_current_level_bytes(Handle);
				ulong ret = raw_ret;
				return ret;
			}
		}

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern ulong gst_app_src_get_current_level_time(IntPtr raw);

		[GLib.Property ("current-level-time")]
		public ulong CurrentLevelTime {
			get  {
				ulong raw_ret = gst_app_src_get_current_level_time(Handle);
				ulong ret = raw_ret;
				return ret;
			}
		}

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern ulong gst_app_src_get_duration(IntPtr raw);

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gst_app_src_set_duration(IntPtr raw, ulong duration);

		[GLib.Property ("duration")]
		public ulong Duration {
			get  {
				ulong raw_ret = gst_app_src_get_duration(Handle);
				ulong ret = raw_ret;
				return ret;
			}
			set  {
				gst_app_src_set_duration(Handle, value);
			}
		}

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern bool gst_app_src_get_emit_signals(IntPtr raw);

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gst_app_src_set_emit_signals(IntPtr raw, bool emit);

		[GLib.Property ("emit-signals")]
		public bool EmitSignals {
			get  {
				bool raw_ret = gst_app_src_get_emit_signals(Handle);
				bool ret = raw_ret;
				return ret;
			}
			set  {
				gst_app_src_set_emit_signals(Handle, value);
			}
		}

		[GLib.Property ("format")]
		public Gst.Format Format {
			get {
				GLib.Value val = GetProperty ("format");
				Gst.Format ret = (Gst.Format) (Enum) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value((Enum) value);
				SetProperty("format", val);
				val.Dispose ();
			}
		}

		[GLib.Property ("handle-segment-change")]
		public bool HandleSegmentChange {
			get {
				GLib.Value val = GetProperty ("handle-segment-change");
				bool ret = (bool) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value(value);
				SetProperty("handle-segment-change", val);
				val.Dispose ();
			}
		}

		[GLib.Property ("is-live")]
		public bool IsLive {
			get {
				GLib.Value val = GetProperty ("is-live");
				bool ret = (bool) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value(value);
				SetProperty("is-live", val);
				val.Dispose ();
			}
		}

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern int gst_app_src_get_leaky_type(IntPtr raw);

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gst_app_src_set_leaky_type(IntPtr raw, int leaky);

		[GLib.Property ("leaky-type")]
		public Gst.App.AppLeakyType LeakyType {
			get  {
				int raw_ret = gst_app_src_get_leaky_type(Handle);
				Gst.App.AppLeakyType ret = (Gst.App.AppLeakyType) raw_ret;
				return ret;
			}
			set  {
				gst_app_src_set_leaky_type(Handle, (int) value);
			}
		}

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern ulong gst_app_src_get_max_buffers(IntPtr raw);

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gst_app_src_set_max_buffers(IntPtr raw, ulong max);

		[GLib.Property ("max-buffers")]
		public ulong MaxBuffers {
			get  {
				ulong raw_ret = gst_app_src_get_max_buffers(Handle);
				ulong ret = raw_ret;
				return ret;
			}
			set  {
				gst_app_src_set_max_buffers(Handle, value);
			}
		}

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern ulong gst_app_src_get_max_bytes(IntPtr raw);

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gst_app_src_set_max_bytes(IntPtr raw, ulong max);

		[GLib.Property ("max-bytes")]
		public ulong MaxBytes {
			get  {
				ulong raw_ret = gst_app_src_get_max_bytes(Handle);
				ulong ret = raw_ret;
				return ret;
			}
			set  {
				gst_app_src_set_max_bytes(Handle, value);
			}
		}

		[GLib.Property ("max-latency")]
		public long MaxLatency {
			get {
				GLib.Value val = GetProperty ("max-latency");
				long ret = (long) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value(value);
				SetProperty("max-latency", val);
				val.Dispose ();
			}
		}

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern ulong gst_app_src_get_max_time(IntPtr raw);

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gst_app_src_set_max_time(IntPtr raw, ulong max);

		[GLib.Property ("max-time")]
		public ulong MaxTime {
			get  {
				ulong raw_ret = gst_app_src_get_max_time(Handle);
				ulong ret = raw_ret;
				return ret;
			}
			set  {
				gst_app_src_set_max_time(Handle, value);
			}
		}

		[GLib.Property ("min-latency")]
		public long MinLatency {
			get {
				GLib.Value val = GetProperty ("min-latency");
				long ret = (long) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value(value);
				SetProperty("min-latency", val);
				val.Dispose ();
			}
		}

		[GLib.Property ("min-percent")]
		public uint MinPercent {
			get {
				GLib.Value val = GetProperty ("min-percent");
				uint ret = (uint) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value(value);
				SetProperty("min-percent", val);
				val.Dispose ();
			}
		}

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern long gst_app_src_get_size(IntPtr raw);

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gst_app_src_set_size(IntPtr raw, long size);

		[GLib.Property ("size")]
		public long Size {
			get  {
				long raw_ret = gst_app_src_get_size(Handle);
				long ret = raw_ret;
				return ret;
			}
			set  {
				gst_app_src_set_size(Handle, value);
			}
		}

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern int gst_app_src_get_stream_type(IntPtr raw);

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gst_app_src_set_stream_type(IntPtr raw, int type);

		[GLib.Property ("stream-type")]
		public Gst.App.AppStreamType StreamType {
			get  {
				int raw_ret = gst_app_src_get_stream_type(Handle);
				Gst.App.AppStreamType ret = (Gst.App.AppStreamType) raw_ret;
				return ret;
			}
			set  {
				gst_app_src_set_stream_type(Handle, (int) value);
			}
		}

		[GLib.Signal("seek-data")]
		public event Gst.App.SeekDataHandler SeekData {
			add {
				this.AddSignalHandler ("seek-data", value, typeof (Gst.App.SeekDataArgs));
			}
			remove {
				this.RemoveSignalHandler ("seek-data", value);
			}
		}

		[GLib.Signal("push-sample")]
		public event Gst.App.PushSampleEventHandler PushSampleEvent {
			add {
				this.AddSignalHandler ("push-sample", value, typeof (Gst.App.PushSampleEventArgs));
			}
			remove {
				this.RemoveSignalHandler ("push-sample", value);
			}
		}

		[GLib.Signal("enough-data")]
		public event System.EventHandler EnoughData {
			add {
				this.AddSignalHandler ("enough-data", value);
			}
			remove {
				this.RemoveSignalHandler ("enough-data", value);
			}
		}

		[GLib.Signal("need-data")]
		public event Gst.App.NeedDataHandler NeedData {
			add {
				this.AddSignalHandler ("need-data", value, typeof (Gst.App.NeedDataArgs));
			}
			remove {
				this.RemoveSignalHandler ("need-data", value);
			}
		}

		[GLib.Signal("end-of-stream")]
		public event Gst.App.EndOfStreamEventHandler EndOfStreamEvent {
			add {
				this.AddSignalHandler ("end-of-stream", value, typeof (Gst.App.EndOfStreamEventArgs));
			}
			remove {
				this.RemoveSignalHandler ("end-of-stream", value);
			}
		}

		[GLib.Signal("push-buffer")]
		public event Gst.App.PushBufferEventHandler PushBufferEvent {
			add {
				this.AddSignalHandler ("push-buffer", value, typeof (Gst.App.PushBufferEventArgs));
			}
			remove {
				this.RemoveSignalHandler ("push-buffer", value);
			}
		}

		[GLib.Signal("push-buffer-list")]
		public event Gst.App.PushBufferListEventHandler PushBufferListEvent {
			add {
				this.AddSignalHandler ("push-buffer-list", value, typeof (Gst.App.PushBufferListEventArgs));
			}
			remove {
				this.RemoveSignalHandler ("push-buffer-list", value);
			}
		}

		static NeedDataNativeDelegate NeedData_cb_delegate;
		static NeedDataNativeDelegate NeedDataVMCallback {
			get {
				if (NeedData_cb_delegate == null)
					NeedData_cb_delegate = new NeedDataNativeDelegate (NeedData_cb);
				return NeedData_cb_delegate;
			}
		}

		static void OverrideNeedData (GLib.GType gtype)
		{
			OverrideNeedData (gtype, NeedDataVMCallback);
		}

		static void OverrideNeedData (GLib.GType gtype, NeedDataNativeDelegate callback)
		{
			unsafe {
				IntPtr* raw_ptr = (IntPtr*)(((long) gtype.GetClassPtr()) + (long) class_abi.GetFieldOffset("need_data"));
				*raw_ptr = Marshal.GetFunctionPointerForDelegate((Delegate) callback);
			}
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate void NeedDataNativeDelegate (IntPtr inst, uint length);

		static void NeedData_cb (IntPtr inst, uint length)
		{
			try {
				AppSrc __obj = GLib.Object.GetObject (inst, false) as AppSrc;
				__obj.OnNeedData (length);
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Gst.App.AppSrc), ConnectionMethod="OverrideNeedData")]
		protected virtual void OnNeedData (uint length)
		{
			InternalNeedData (length);
		}

		private void InternalNeedData (uint length)
		{
			NeedDataNativeDelegate unmanaged = null;
			unsafe {
				IntPtr* raw_ptr = (IntPtr*)(((long) this.LookupGType().GetThresholdType().GetClassPtr()) + (long) class_abi.GetFieldOffset("need_data"));
				unmanaged = (NeedDataNativeDelegate) Marshal.GetDelegateForFunctionPointer(*raw_ptr, typeof(NeedDataNativeDelegate));
			}
			if (unmanaged == null) return;

			unmanaged (this.Handle, length);
		}

		static EnoughDataNativeDelegate EnoughData_cb_delegate;
		static EnoughDataNativeDelegate EnoughDataVMCallback {
			get {
				if (EnoughData_cb_delegate == null)
					EnoughData_cb_delegate = new EnoughDataNativeDelegate (EnoughData_cb);
				return EnoughData_cb_delegate;
			}
		}

		static void OverrideEnoughData (GLib.GType gtype)
		{
			OverrideEnoughData (gtype, EnoughDataVMCallback);
		}

		static void OverrideEnoughData (GLib.GType gtype, EnoughDataNativeDelegate callback)
		{
			unsafe {
				IntPtr* raw_ptr = (IntPtr*)(((long) gtype.GetClassPtr()) + (long) class_abi.GetFieldOffset("enough_data"));
				*raw_ptr = Marshal.GetFunctionPointerForDelegate((Delegate) callback);
			}
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate void EnoughDataNativeDelegate (IntPtr inst);

		static void EnoughData_cb (IntPtr inst)
		{
			try {
				AppSrc __obj = GLib.Object.GetObject (inst, false) as AppSrc;
				__obj.OnEnoughData ();
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Gst.App.AppSrc), ConnectionMethod="OverrideEnoughData")]
		protected virtual void OnEnoughData ()
		{
			InternalEnoughData ();
		}

		private void InternalEnoughData ()
		{
			EnoughDataNativeDelegate unmanaged = null;
			unsafe {
				IntPtr* raw_ptr = (IntPtr*)(((long) this.LookupGType().GetThresholdType().GetClassPtr()) + (long) class_abi.GetFieldOffset("enough_data"));
				unmanaged = (EnoughDataNativeDelegate) Marshal.GetDelegateForFunctionPointer(*raw_ptr, typeof(EnoughDataNativeDelegate));
			}
			if (unmanaged == null) return;

			unmanaged (this.Handle);
		}

		static SeekDataNativeDelegate SeekData_cb_delegate;
		static SeekDataNativeDelegate SeekDataVMCallback {
			get {
				if (SeekData_cb_delegate == null)
					SeekData_cb_delegate = new SeekDataNativeDelegate (SeekData_cb);
				return SeekData_cb_delegate;
			}
		}

		static void OverrideSeekData (GLib.GType gtype)
		{
			OverrideSeekData (gtype, SeekDataVMCallback);
		}

		static void OverrideSeekData (GLib.GType gtype, SeekDataNativeDelegate callback)
		{
			unsafe {
				IntPtr* raw_ptr = (IntPtr*)(((long) gtype.GetClassPtr()) + (long) class_abi.GetFieldOffset("seek_data"));
				*raw_ptr = Marshal.GetFunctionPointerForDelegate((Delegate) callback);
			}
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate bool SeekDataNativeDelegate (IntPtr inst, ulong offset);

		static bool SeekData_cb (IntPtr inst, ulong offset)
		{
			try {
				AppSrc __obj = GLib.Object.GetObject (inst, false) as AppSrc;
				bool __result;
				__result = __obj.OnSeekData (offset);
				return __result;
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, true);
				// NOTREACHED: above call does not return.
				throw e;
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Gst.App.AppSrc), ConnectionMethod="OverrideSeekData")]
		protected virtual bool OnSeekData (ulong offset)
		{
			return InternalSeekData (offset);
		}

		private bool InternalSeekData (ulong offset)
		{
			SeekDataNativeDelegate unmanaged = null;
			unsafe {
				IntPtr* raw_ptr = (IntPtr*)(((long) this.LookupGType().GetThresholdType().GetClassPtr()) + (long) class_abi.GetFieldOffset("seek_data"));
				unmanaged = (SeekDataNativeDelegate) Marshal.GetDelegateForFunctionPointer(*raw_ptr, typeof(SeekDataNativeDelegate));
			}
			if (unmanaged == null) return false;

			bool __result = unmanaged (this.Handle, offset);
			return __result;
		}

		static PushBufferEventNativeDelegate PushBufferEvent_cb_delegate;
		static PushBufferEventNativeDelegate PushBufferEventVMCallback {
			get {
				if (PushBufferEvent_cb_delegate == null)
					PushBufferEvent_cb_delegate = new PushBufferEventNativeDelegate (PushBufferEvent_cb);
				return PushBufferEvent_cb_delegate;
			}
		}

		static void OverridePushBufferEvent (GLib.GType gtype)
		{
			OverridePushBufferEvent (gtype, PushBufferEventVMCallback);
		}

		static void OverridePushBufferEvent (GLib.GType gtype, PushBufferEventNativeDelegate callback)
		{
			unsafe {
				IntPtr* raw_ptr = (IntPtr*)(((long) gtype.GetClassPtr()) + (long) class_abi.GetFieldOffset("push_buffer"));
				*raw_ptr = Marshal.GetFunctionPointerForDelegate((Delegate) callback);
			}
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate int PushBufferEventNativeDelegate (IntPtr inst, IntPtr buffer);

		static int PushBufferEvent_cb (IntPtr inst, IntPtr buffer)
		{
			try {
				AppSrc __obj = GLib.Object.GetObject (inst, false) as AppSrc;
				Gst.FlowReturn __result;
				__result = __obj.OnPushBufferEvent (buffer == IntPtr.Zero ? null : (Gst.Buffer) GLib.Opaque.GetOpaque (buffer, typeof (Gst.Buffer), false));
				return (int) __result;
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, true);
				// NOTREACHED: above call does not return.
				throw e;
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Gst.App.AppSrc), ConnectionMethod="OverridePushBufferEvent")]
		protected virtual Gst.FlowReturn OnPushBufferEvent (Gst.Buffer buffer)
		{
			return InternalPushBufferEvent (buffer);
		}

		private Gst.FlowReturn InternalPushBufferEvent (Gst.Buffer buffer)
		{
			PushBufferEventNativeDelegate unmanaged = null;
			unsafe {
				IntPtr* raw_ptr = (IntPtr*)(((long) this.LookupGType().GetThresholdType().GetClassPtr()) + (long) class_abi.GetFieldOffset("push_buffer"));
				unmanaged = (PushBufferEventNativeDelegate) Marshal.GetDelegateForFunctionPointer(*raw_ptr, typeof(PushBufferEventNativeDelegate));
			}
			if (unmanaged == null) return (Gst.FlowReturn) 0;

			int __result = unmanaged (this.Handle, buffer == null ? IntPtr.Zero : buffer.Handle);
			return (Gst.FlowReturn) __result;
		}

		static EndOfStreamEventNativeDelegate EndOfStreamEvent_cb_delegate;
		static EndOfStreamEventNativeDelegate EndOfStreamEventVMCallback {
			get {
				if (EndOfStreamEvent_cb_delegate == null)
					EndOfStreamEvent_cb_delegate = new EndOfStreamEventNativeDelegate (EndOfStreamEvent_cb);
				return EndOfStreamEvent_cb_delegate;
			}
		}

		static void OverrideEndOfStreamEvent (GLib.GType gtype)
		{
			OverrideEndOfStreamEvent (gtype, EndOfStreamEventVMCallback);
		}

		static void OverrideEndOfStreamEvent (GLib.GType gtype, EndOfStreamEventNativeDelegate callback)
		{
			unsafe {
				IntPtr* raw_ptr = (IntPtr*)(((long) gtype.GetClassPtr()) + (long) class_abi.GetFieldOffset("end_of_stream"));
				*raw_ptr = Marshal.GetFunctionPointerForDelegate((Delegate) callback);
			}
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate int EndOfStreamEventNativeDelegate (IntPtr inst);

		static int EndOfStreamEvent_cb (IntPtr inst)
		{
			try {
				AppSrc __obj = GLib.Object.GetObject (inst, false) as AppSrc;
				Gst.FlowReturn __result;
				__result = __obj.OnEndOfStreamEvent ();
				return (int) __result;
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, true);
				// NOTREACHED: above call does not return.
				throw e;
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Gst.App.AppSrc), ConnectionMethod="OverrideEndOfStreamEvent")]
		protected virtual Gst.FlowReturn OnEndOfStreamEvent ()
		{
			return InternalEndOfStreamEvent ();
		}

		private Gst.FlowReturn InternalEndOfStreamEvent ()
		{
			EndOfStreamEventNativeDelegate unmanaged = null;
			unsafe {
				IntPtr* raw_ptr = (IntPtr*)(((long) this.LookupGType().GetThresholdType().GetClassPtr()) + (long) class_abi.GetFieldOffset("end_of_stream"));
				unmanaged = (EndOfStreamEventNativeDelegate) Marshal.GetDelegateForFunctionPointer(*raw_ptr, typeof(EndOfStreamEventNativeDelegate));
			}
			if (unmanaged == null) return (Gst.FlowReturn) 0;

			int __result = unmanaged (this.Handle);
			return (Gst.FlowReturn) __result;
		}

		static PushSampleEventNativeDelegate PushSampleEvent_cb_delegate;
		static PushSampleEventNativeDelegate PushSampleEventVMCallback {
			get {
				if (PushSampleEvent_cb_delegate == null)
					PushSampleEvent_cb_delegate = new PushSampleEventNativeDelegate (PushSampleEvent_cb);
				return PushSampleEvent_cb_delegate;
			}
		}

		static void OverridePushSampleEvent (GLib.GType gtype)
		{
			OverridePushSampleEvent (gtype, PushSampleEventVMCallback);
		}

		static void OverridePushSampleEvent (GLib.GType gtype, PushSampleEventNativeDelegate callback)
		{
			unsafe {
				IntPtr* raw_ptr = (IntPtr*)(((long) gtype.GetClassPtr()) + (long) class_abi.GetFieldOffset("push_sample"));
				*raw_ptr = Marshal.GetFunctionPointerForDelegate((Delegate) callback);
			}
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate int PushSampleEventNativeDelegate (IntPtr inst, IntPtr sample);

		static int PushSampleEvent_cb (IntPtr inst, IntPtr sample)
		{
			try {
				AppSrc __obj = GLib.Object.GetObject (inst, false) as AppSrc;
				Gst.FlowReturn __result;
				__result = __obj.OnPushSampleEvent (sample == IntPtr.Zero ? null : (Gst.Sample) GLib.Opaque.GetOpaque (sample, typeof (Gst.Sample), false));
				return (int) __result;
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, true);
				// NOTREACHED: above call does not return.
				throw e;
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Gst.App.AppSrc), ConnectionMethod="OverridePushSampleEvent")]
		protected virtual Gst.FlowReturn OnPushSampleEvent (Gst.Sample sample)
		{
			return InternalPushSampleEvent (sample);
		}

		private Gst.FlowReturn InternalPushSampleEvent (Gst.Sample sample)
		{
			PushSampleEventNativeDelegate unmanaged = null;
			unsafe {
				IntPtr* raw_ptr = (IntPtr*)(((long) this.LookupGType().GetThresholdType().GetClassPtr()) + (long) class_abi.GetFieldOffset("push_sample"));
				unmanaged = (PushSampleEventNativeDelegate) Marshal.GetDelegateForFunctionPointer(*raw_ptr, typeof(PushSampleEventNativeDelegate));
			}
			if (unmanaged == null) return (Gst.FlowReturn) 0;

			int __result = unmanaged (this.Handle, sample == null ? IntPtr.Zero : sample.Handle);
			return (Gst.FlowReturn) __result;
		}

		static PushBufferListEventNativeDelegate PushBufferListEvent_cb_delegate;
		static PushBufferListEventNativeDelegate PushBufferListEventVMCallback {
			get {
				if (PushBufferListEvent_cb_delegate == null)
					PushBufferListEvent_cb_delegate = new PushBufferListEventNativeDelegate (PushBufferListEvent_cb);
				return PushBufferListEvent_cb_delegate;
			}
		}

		static void OverridePushBufferListEvent (GLib.GType gtype)
		{
			OverridePushBufferListEvent (gtype, PushBufferListEventVMCallback);
		}

		static void OverridePushBufferListEvent (GLib.GType gtype, PushBufferListEventNativeDelegate callback)
		{
			unsafe {
				IntPtr* raw_ptr = (IntPtr*)(((long) gtype.GetClassPtr()) + (long) class_abi.GetFieldOffset("push_buffer_list"));
				*raw_ptr = Marshal.GetFunctionPointerForDelegate((Delegate) callback);
			}
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate int PushBufferListEventNativeDelegate (IntPtr inst, IntPtr buffer_list);

		static int PushBufferListEvent_cb (IntPtr inst, IntPtr buffer_list)
		{
			try {
				AppSrc __obj = GLib.Object.GetObject (inst, false) as AppSrc;
				Gst.FlowReturn __result;
				__result = __obj.OnPushBufferListEvent (buffer_list == IntPtr.Zero ? null : (Gst.BufferList) GLib.Opaque.GetOpaque (buffer_list, typeof (Gst.BufferList), false));
				return (int) __result;
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, true);
				// NOTREACHED: above call does not return.
				throw e;
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Gst.App.AppSrc), ConnectionMethod="OverridePushBufferListEvent")]
		protected virtual Gst.FlowReturn OnPushBufferListEvent (Gst.BufferList buffer_list)
		{
			return InternalPushBufferListEvent (buffer_list);
		}

		private Gst.FlowReturn InternalPushBufferListEvent (Gst.BufferList buffer_list)
		{
			PushBufferListEventNativeDelegate unmanaged = null;
			unsafe {
				IntPtr* raw_ptr = (IntPtr*)(((long) this.LookupGType().GetThresholdType().GetClassPtr()) + (long) class_abi.GetFieldOffset("push_buffer_list"));
				unmanaged = (PushBufferListEventNativeDelegate) Marshal.GetDelegateForFunctionPointer(*raw_ptr, typeof(PushBufferListEventNativeDelegate));
			}
			if (unmanaged == null) return (Gst.FlowReturn) 0;

			int __result = unmanaged (this.Handle, buffer_list == null ? IntPtr.Zero : buffer_list.Handle);
			return (Gst.FlowReturn) __result;
		}


		// Internal representation of the wrapped structure ABI.
		static GLib.AbiStruct _class_abi = null;
		static public new GLib.AbiStruct class_abi {
			get {
				if (_class_abi == null)
					_class_abi = new GLib.AbiStruct (new List<GLib.AbiField>{ 
						new GLib.AbiField("need_data"
							, Gst.Base.BaseSrc.class_abi.Fields
							, (uint) Marshal.SizeOf(typeof(IntPtr)) // need_data
							, null
							, "enough_data"
							, (uint) Marshal.SizeOf(typeof(IntPtr))
							, 0
							),
						new GLib.AbiField("enough_data"
							, -1
							, (uint) Marshal.SizeOf(typeof(IntPtr)) // enough_data
							, "need_data"
							, "seek_data"
							, (uint) Marshal.SizeOf(typeof(IntPtr))
							, 0
							),
						new GLib.AbiField("seek_data"
							, -1
							, (uint) Marshal.SizeOf(typeof(IntPtr)) // seek_data
							, "enough_data"
							, "push_buffer"
							, (uint) Marshal.SizeOf(typeof(IntPtr))
							, 0
							),
						new GLib.AbiField("push_buffer"
							, -1
							, (uint) Marshal.SizeOf(typeof(IntPtr)) // push_buffer
							, "seek_data"
							, "end_of_stream"
							, (uint) Marshal.SizeOf(typeof(IntPtr))
							, 0
							),
						new GLib.AbiField("end_of_stream"
							, -1
							, (uint) Marshal.SizeOf(typeof(IntPtr)) // end_of_stream
							, "push_buffer"
							, "push_sample"
							, (uint) Marshal.SizeOf(typeof(IntPtr))
							, 0
							),
						new GLib.AbiField("push_sample"
							, -1
							, (uint) Marshal.SizeOf(typeof(IntPtr)) // push_sample
							, "end_of_stream"
							, "push_buffer_list"
							, (uint) Marshal.SizeOf(typeof(IntPtr))
							, 0
							),
						new GLib.AbiField("push_buffer_list"
							, -1
							, (uint) Marshal.SizeOf(typeof(IntPtr)) // push_buffer_list
							, "push_sample"
							, "_gst_reserved"
							, (uint) Marshal.SizeOf(typeof(IntPtr))
							, 0
							),
						new GLib.AbiField("_gst_reserved"
							, -1
							, (uint) Marshal.SizeOf(typeof(IntPtr)) * 2 // _gst_reserved
							, "push_buffer_list"
							, null
							, (uint) Marshal.SizeOf(typeof(IntPtr))
							, 0
							),
					});

				return _class_abi;
			}
		}


		// End of the ABI representation.

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gst_app_src_get_type();

		public static new GLib.GType GType { 
			get {
				IntPtr raw_ret = gst_app_src_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern int gst_app_src_end_of_stream(IntPtr raw);

		public Gst.FlowReturn EndOfStream() {
			int raw_ret = gst_app_src_end_of_stream(Handle);
			Gst.FlowReturn ret = (Gst.FlowReturn) raw_ret;
			return ret;
		}

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gst_app_src_get_latency(IntPtr raw, out ulong min, out ulong max);

		public void GetLatency(out ulong min, out ulong max) {
			gst_app_src_get_latency(Handle, out min, out max);
		}

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern int gst_app_src_push_buffer(IntPtr raw, IntPtr buffer);

		public Gst.FlowReturn PushBuffer(Gst.Buffer buffer) {
			buffer.Owned = false;
			int raw_ret = gst_app_src_push_buffer(Handle, buffer == null ? IntPtr.Zero : buffer.Handle);
			Gst.FlowReturn ret = (Gst.FlowReturn) raw_ret;
			return ret;
		}

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern int gst_app_src_push_buffer_list(IntPtr raw, IntPtr buffer_list);

		public Gst.FlowReturn PushBufferList(Gst.BufferList buffer_list) {
			buffer_list.Owned = false;
			int raw_ret = gst_app_src_push_buffer_list(Handle, buffer_list == null ? IntPtr.Zero : buffer_list.Handle);
			Gst.FlowReturn ret = (Gst.FlowReturn) raw_ret;
			return ret;
		}

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern int gst_app_src_push_sample(IntPtr raw, IntPtr sample);

		public Gst.FlowReturn PushSample(Gst.Sample sample) {
			int raw_ret = gst_app_src_push_sample(Handle, sample == null ? IntPtr.Zero : sample.Handle);
			Gst.FlowReturn ret = (Gst.FlowReturn) raw_ret;
			return ret;
		}

		[DllImport("gstapp-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gst_app_src_set_latency(IntPtr raw, ulong min, ulong max);

		public void SetLatency(ulong min, ulong max) {
			gst_app_src_set_latency(Handle, min, max);
		}

		[DllImport("gstreamer-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gst_uri_handler_get_uri(IntPtr raw);

		public string Uri { 
			get {
				IntPtr raw_ret = gst_uri_handler_get_uri(Handle);
				string ret = GLib.Marshaller.PtrToStringGFree(raw_ret);
				return ret;
			}
		}

		[DllImport("gstreamer-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern int gst_uri_handler_get_uri_type(IntPtr raw);

		public Gst.URIType UriType { 
			get {
				int raw_ret = gst_uri_handler_get_uri_type(Handle);
				Gst.URIType ret = (Gst.URIType) raw_ret;
				return ret;
			}
		}

		[DllImport("gstreamer-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern bool gst_uri_handler_set_uri(IntPtr raw, IntPtr uri, out IntPtr error);

		public bool SetUri(string uri) {
			IntPtr native_uri = GLib.Marshaller.StringToPtrGStrdup (uri);
			IntPtr error = IntPtr.Zero;
			bool raw_ret = gst_uri_handler_set_uri(Handle, native_uri, out error);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_uri);
			if (error != IntPtr.Zero) throw new GLib.GException (error);
			return ret;
		}


		static AppSrc ()
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
							, Gst.Base.BaseSrc.abi_info.Fields
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
