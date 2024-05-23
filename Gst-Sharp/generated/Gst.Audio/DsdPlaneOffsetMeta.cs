// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst.Audio {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[StructLayout(LayoutKind.Sequential)]
	public partial struct DsdPlaneOffsetMeta : IEquatable<DsdPlaneOffsetMeta> {

		public Gst.Meta Meta;
		public int NumChannels;
		private UIntPtr num_bytes_per_channel;
		public ulong NumBytesPerChannel {
			get {
				return (ulong) num_bytes_per_channel;
			}
			set {
				num_bytes_per_channel = new UIntPtr (value);
			}
		}
		private UIntPtr offsets;
		public ulong Offsets {
			get {
				return (ulong) offsets;
			}
			set {
				offsets = new UIntPtr (value);
			}
		}
		[MarshalAs (UnmanagedType.ByValArray, SizeConst=4)]
		private IntPtr[] _gstGstReserved;

		public static Gst.Audio.DsdPlaneOffsetMeta Zero = new Gst.Audio.DsdPlaneOffsetMeta ();

		public static Gst.Audio.DsdPlaneOffsetMeta New(IntPtr raw) {
			if (raw == IntPtr.Zero)
				return Gst.Audio.DsdPlaneOffsetMeta.Zero;
			return (Gst.Audio.DsdPlaneOffsetMeta) Marshal.PtrToStructure (raw, typeof (Gst.Audio.DsdPlaneOffsetMeta));
		}

		[DllImport("gstaudio-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gst_dsd_plane_offset_meta_get_info();

		public static Gst.MetaInfo Info { 
			get {
				IntPtr raw_ret = gst_dsd_plane_offset_meta_get_info();
				Gst.MetaInfo ret = Gst.MetaInfo.New (raw_ret);
				return ret;
			}
		}

		public bool Equals (DsdPlaneOffsetMeta other)
		{
			return true && Meta.Equals (other.Meta) && NumChannels.Equals (other.NumChannels) && NumBytesPerChannel.Equals (other.NumBytesPerChannel) && Offsets.Equals (other.Offsets);
		}

		public override bool Equals (object other)
		{
			return other is DsdPlaneOffsetMeta && Equals ((DsdPlaneOffsetMeta) other);
		}

		public override int GetHashCode ()
		{
			return this.GetType ().FullName.GetHashCode () ^ Meta.GetHashCode () ^ NumChannels.GetHashCode () ^ NumBytesPerChannel.GetHashCode () ^ Offsets.GetHashCode ();
		}

		private static GLib.GType GType {
			get { return GLib.GType.Pointer; }
		}
#endregion
	}
}
