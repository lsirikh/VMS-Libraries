// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[StructLayout(LayoutKind.Sequential)]
	public partial struct StaticCaps : IEquatable<StaticCaps> {

		private IntPtr _caps;
		public Gst.Caps Caps {
			get {
				return _caps == IntPtr.Zero ? null : (Gst.Caps) GLib.Opaque.GetOpaque (_caps, typeof (Gst.Caps), false);
			}
			set {
				_caps = value == null ? IntPtr.Zero : value.Handle;
			}
		}
		public string String;
		[MarshalAs (UnmanagedType.ByValArray, SizeConst=4)]
		private IntPtr[] _gstGstReserved;

		public static Gst.StaticCaps Zero = new Gst.StaticCaps ();

		public static Gst.StaticCaps New(IntPtr raw) {
			if (raw == IntPtr.Zero)
				return Gst.StaticCaps.Zero;
			return (Gst.StaticCaps) Marshal.PtrToStructure (raw, typeof (Gst.StaticCaps));
		}

		[DllImport("gstreamer-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gst_static_caps_cleanup(IntPtr raw);

		public void Cleanup() {
			IntPtr this_as_native = System.Runtime.InteropServices.Marshal.AllocHGlobal (System.Runtime.InteropServices.Marshal.SizeOf (this));
			System.Runtime.InteropServices.Marshal.StructureToPtr (this, this_as_native, false);
			gst_static_caps_cleanup(this_as_native);
			ReadNative (this_as_native, ref this);
			System.Runtime.InteropServices.Marshal.FreeHGlobal (this_as_native);
		}

		[DllImport("gstreamer-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gst_static_caps_get(IntPtr raw);

		public Gst.Caps Get() {
			IntPtr this_as_native = System.Runtime.InteropServices.Marshal.AllocHGlobal (System.Runtime.InteropServices.Marshal.SizeOf (this));
			System.Runtime.InteropServices.Marshal.StructureToPtr (this, this_as_native, false);
			IntPtr raw_ret = gst_static_caps_get(this_as_native);
			Gst.Caps ret = raw_ret == IntPtr.Zero ? null : (Gst.Caps) GLib.Opaque.GetOpaque (raw_ret, typeof (Gst.Caps), true);
			ReadNative (this_as_native, ref this);
			System.Runtime.InteropServices.Marshal.FreeHGlobal (this_as_native);
			return ret;
		}

		static void ReadNative (IntPtr native, ref Gst.StaticCaps target)
		{
			target = New (native);
		}

		public bool Equals (StaticCaps other)
		{
			return true && Caps.Equals (other.Caps) && String.Equals (other.String);
		}

		public override bool Equals (object other)
		{
			return other is StaticCaps && Equals ((StaticCaps) other);
		}

		public override int GetHashCode ()
		{
			return this.GetType ().FullName.GetHashCode () ^ Caps.GetHashCode () ^ String.GetHashCode ();
		}

		private static GLib.GType GType {
			get { return GLib.GType.Pointer; }
		}
#endregion
	}
}
