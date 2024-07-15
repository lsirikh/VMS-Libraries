// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst.VideoSharp {

	using System;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
	internal delegate bool VideoAffineTransformationGetMatrixNative(IntPtr meta, float matrix);

	internal class VideoAffineTransformationGetMatrixInvoker {

		VideoAffineTransformationGetMatrixNative native_cb;
		IntPtr __data;
		GLib.DestroyNotify __notify;

		~VideoAffineTransformationGetMatrixInvoker ()
		{
			if (__notify == null)
				return;
			__notify (__data);
		}

		internal VideoAffineTransformationGetMatrixInvoker (VideoAffineTransformationGetMatrixNative native_cb) : this (native_cb, IntPtr.Zero, null) {}

		internal VideoAffineTransformationGetMatrixInvoker (VideoAffineTransformationGetMatrixNative native_cb, IntPtr data) : this (native_cb, data, null) {}

		internal VideoAffineTransformationGetMatrixInvoker (VideoAffineTransformationGetMatrixNative native_cb, IntPtr data, GLib.DestroyNotify notify)
		{
			this.native_cb = native_cb;
			__data = data;
			__notify = notify;
		}

		internal Gst.Video.VideoAffineTransformationGetMatrix Handler {
			get {
				return new Gst.Video.VideoAffineTransformationGetMatrix(InvokeNative);
			}
		}

		bool InvokeNative (Gst.Video.VideoAffineTransformationMeta meta, float matrix)
		{
			IntPtr native_meta = GLib.Marshaller.StructureToPtrAlloc (meta);
			bool __result = native_cb (native_meta, matrix);
			Marshal.FreeHGlobal (native_meta);
			return __result;
		}
	}

	internal class VideoAffineTransformationGetMatrixWrapper {

		public bool NativeCallback (IntPtr meta, float matrix)
		{
			try {
				bool __ret = managed (Gst.Video.VideoAffineTransformationMeta.New (meta), matrix);
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

		internal VideoAffineTransformationGetMatrixNative NativeDelegate;
		Gst.Video.VideoAffineTransformationGetMatrix managed;

		public VideoAffineTransformationGetMatrixWrapper (Gst.Video.VideoAffineTransformationGetMatrix managed)
		{
			this.managed = managed;
			if (managed != null)
				NativeDelegate = new VideoAffineTransformationGetMatrixNative (NativeCallback);
		}

		public static Gst.Video.VideoAffineTransformationGetMatrix GetManagedDelegate (VideoAffineTransformationGetMatrixNative native)
		{
			if (native == null)
				return null;
			VideoAffineTransformationGetMatrixWrapper wrapper = (VideoAffineTransformationGetMatrixWrapper) native.Target;
			if (wrapper == null)
				return null;
			return wrapper.managed;
		}
	}
#endregion
}
