// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace GstSharp {

	using System;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
	internal delegate bool CapsMapFuncNative(IntPtr features, IntPtr structure, IntPtr user_data);

	internal class CapsMapFuncInvoker {

		CapsMapFuncNative native_cb;
		IntPtr __data;
		GLib.DestroyNotify __notify;

		~CapsMapFuncInvoker ()
		{
			if (__notify == null)
				return;
			__notify (__data);
		}

		internal CapsMapFuncInvoker (CapsMapFuncNative native_cb) : this (native_cb, IntPtr.Zero, null) {}

		internal CapsMapFuncInvoker (CapsMapFuncNative native_cb, IntPtr data) : this (native_cb, data, null) {}

		internal CapsMapFuncInvoker (CapsMapFuncNative native_cb, IntPtr data, GLib.DestroyNotify notify)
		{
			this.native_cb = native_cb;
			__data = data;
			__notify = notify;
		}

		internal Gst.CapsMapFunc Handler {
			get {
				return new Gst.CapsMapFunc(InvokeNative);
			}
		}

		bool InvokeNative (Gst.CapsFeatures features, Gst.Structure structure)
		{
			IntPtr native_features = GLib.Marshaller.StructureToPtrAlloc (features);
			bool __result = native_cb (native_features, structure == null ? IntPtr.Zero : structure.Handle, __data);
			Marshal.FreeHGlobal (native_features);
			return __result;
		}
	}

	internal class CapsMapFuncWrapper {

		public bool NativeCallback (IntPtr features, IntPtr structure, IntPtr user_data)
		{
			try {
				bool __ret = managed (Gst.CapsFeatures.New (features), structure == IntPtr.Zero ? null : (Gst.Structure) GLib.Opaque.GetOpaque (structure, typeof (Gst.Structure), false));
				if (release_on_call)
					gch.Free ();
				return __ret;
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
				return false;
			}
		}

		bool release_on_call = false;
		GCHandle gch;

		public void PersistUntilCalled ()
		{
			release_on_call = true;
			gch = GCHandle.Alloc (this);
		}

		internal CapsMapFuncNative NativeDelegate;
		Gst.CapsMapFunc managed;

		public CapsMapFuncWrapper (Gst.CapsMapFunc managed)
		{
			this.managed = managed;
			if (managed != null)
				NativeDelegate = new CapsMapFuncNative (NativeCallback);
		}

		public static Gst.CapsMapFunc GetManagedDelegate (CapsMapFuncNative native)
		{
			if (native == null)
				return null;
			CapsMapFuncWrapper wrapper = (CapsMapFuncWrapper) native.Target;
			if (wrapper == null)
				return null;
			return wrapper.managed;
		}
	}
#endregion
}
