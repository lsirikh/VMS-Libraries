// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst.Audio {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[StructLayout(LayoutKind.Sequential)]
	public partial struct AudioMeta : IEquatable<AudioMeta> {

		public Gst.Meta Meta;
		private IntPtr _info;
		public Gst.Audio.AudioInfo Info {
			get {
				return _info == IntPtr.Zero ? null : (Gst.Audio.AudioInfo) GLib.Opaque.GetOpaque (_info, typeof (Gst.Audio.AudioInfo), false);
			}
			set {
				_info = value == null ? IntPtr.Zero : value.Handle;
			}
		}
		private UIntPtr samples;
		public ulong Samples {
			get {
				return (ulong) samples;
			}
			set {
				samples = new UIntPtr (value);
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

		public static Gst.Audio.AudioMeta Zero = new Gst.Audio.AudioMeta ();

		public static Gst.Audio.AudioMeta New(IntPtr raw) {
			if (raw == IntPtr.Zero)
				return Gst.Audio.AudioMeta.Zero;
			return (Gst.Audio.AudioMeta) Marshal.PtrToStructure (raw, typeof (Gst.Audio.AudioMeta));
		}

		public bool Equals (AudioMeta other)
		{
			return true && Meta.Equals (other.Meta) && Info.Equals (other.Info) && Samples.Equals (other.Samples) && Offsets.Equals (other.Offsets);
		}

		public override bool Equals (object other)
		{
			return other is AudioMeta && Equals ((AudioMeta) other);
		}

		public override int GetHashCode ()
		{
			return this.GetType ().FullName.GetHashCode () ^ Meta.GetHashCode () ^ Info.GetHashCode () ^ Samples.GetHashCode () ^ Offsets.GetHashCode ();
		}

		private static GLib.GType GType {
			get { return GLib.GType.Pointer; }
		}
#endregion
	}
}
