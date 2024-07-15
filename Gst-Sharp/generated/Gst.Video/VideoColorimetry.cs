// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst.Video {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[StructLayout(LayoutKind.Sequential)]
	public partial struct VideoColorimetry : IEquatable<VideoColorimetry> {

		public Gst.Video.VideoColorRange Range;
		public Gst.Video.VideoColorMatrix Matrix;
		public Gst.Video.VideoTransferFunction Transfer;
		public Gst.Video.VideoColorPrimaries Primaries;

		public static Gst.Video.VideoColorimetry Zero = new Gst.Video.VideoColorimetry ();

		public static Gst.Video.VideoColorimetry New(IntPtr raw) {
			if (raw == IntPtr.Zero)
				return Gst.Video.VideoColorimetry.Zero;
			return (Gst.Video.VideoColorimetry) Marshal.PtrToStructure (raw, typeof (Gst.Video.VideoColorimetry));
		}

		[DllImport("gstvideo-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern bool gst_video_colorimetry_from_string(IntPtr raw, IntPtr color);

		public bool FromString(string color) {
			IntPtr this_as_native = System.Runtime.InteropServices.Marshal.AllocHGlobal (System.Runtime.InteropServices.Marshal.SizeOf (this));
			System.Runtime.InteropServices.Marshal.StructureToPtr (this, this_as_native, false);
			IntPtr native_color = GLib.Marshaller.StringToPtrGStrdup (color);
			bool raw_ret = gst_video_colorimetry_from_string(this_as_native, native_color);
			bool ret = raw_ret;
			ReadNative (this_as_native, ref this);
			System.Runtime.InteropServices.Marshal.FreeHGlobal (this_as_native);
			GLib.Marshaller.Free (native_color);
			return ret;
		}

		[DllImport("gstvideo-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern bool gst_video_colorimetry_is_equal(IntPtr raw, IntPtr other);

		public bool IsEqual(Gst.Video.VideoColorimetry other) {
			IntPtr this_as_native = System.Runtime.InteropServices.Marshal.AllocHGlobal (System.Runtime.InteropServices.Marshal.SizeOf (this));
			System.Runtime.InteropServices.Marshal.StructureToPtr (this, this_as_native, false);
			IntPtr native_other = GLib.Marshaller.StructureToPtrAlloc (other);
			bool raw_ret = gst_video_colorimetry_is_equal(this_as_native, native_other);
			bool ret = raw_ret;
			ReadNative (this_as_native, ref this);
			System.Runtime.InteropServices.Marshal.FreeHGlobal (this_as_native);
			Marshal.FreeHGlobal (native_other);
			return ret;
		}

		[DllImport("gstvideo-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern bool gst_video_colorimetry_is_equivalent(IntPtr raw, uint bitdepth, IntPtr other, uint other_bitdepth);

		public bool IsEquivalent(uint bitdepth, Gst.Video.VideoColorimetry other, uint other_bitdepth) {
			IntPtr this_as_native = System.Runtime.InteropServices.Marshal.AllocHGlobal (System.Runtime.InteropServices.Marshal.SizeOf (this));
			System.Runtime.InteropServices.Marshal.StructureToPtr (this, this_as_native, false);
			IntPtr native_other = GLib.Marshaller.StructureToPtrAlloc (other);
			bool raw_ret = gst_video_colorimetry_is_equivalent(this_as_native, bitdepth, native_other, other_bitdepth);
			bool ret = raw_ret;
			ReadNative (this_as_native, ref this);
			System.Runtime.InteropServices.Marshal.FreeHGlobal (this_as_native);
			Marshal.FreeHGlobal (native_other);
			return ret;
		}

		[DllImport("gstvideo-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern bool gst_video_colorimetry_matches(IntPtr raw, IntPtr color);

		public bool Matches(string color) {
			IntPtr this_as_native = System.Runtime.InteropServices.Marshal.AllocHGlobal (System.Runtime.InteropServices.Marshal.SizeOf (this));
			System.Runtime.InteropServices.Marshal.StructureToPtr (this, this_as_native, false);
			IntPtr native_color = GLib.Marshaller.StringToPtrGStrdup (color);
			bool raw_ret = gst_video_colorimetry_matches(this_as_native, native_color);
			bool ret = raw_ret;
			ReadNative (this_as_native, ref this);
			System.Runtime.InteropServices.Marshal.FreeHGlobal (this_as_native);
			GLib.Marshaller.Free (native_color);
			return ret;
		}

		[DllImport("gstvideo-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gst_video_colorimetry_to_string(IntPtr raw);

		public override string ToString() {
			IntPtr this_as_native = System.Runtime.InteropServices.Marshal.AllocHGlobal (System.Runtime.InteropServices.Marshal.SizeOf (this));
			System.Runtime.InteropServices.Marshal.StructureToPtr (this, this_as_native, false);
			IntPtr raw_ret = gst_video_colorimetry_to_string(this_as_native);
			string ret = GLib.Marshaller.PtrToStringGFree(raw_ret);
			ReadNative (this_as_native, ref this);
			System.Runtime.InteropServices.Marshal.FreeHGlobal (this_as_native);
			return ret;
		}

		static void ReadNative (IntPtr native, ref Gst.Video.VideoColorimetry target)
		{
			target = New (native);
		}

		public bool Equals (VideoColorimetry other)
		{
			return true && Range.Equals (other.Range) && Matrix.Equals (other.Matrix) && Transfer.Equals (other.Transfer) && Primaries.Equals (other.Primaries);
		}

		public override bool Equals (object other)
		{
			return other is VideoColorimetry && Equals ((VideoColorimetry) other);
		}

		public override int GetHashCode ()
		{
			return this.GetType ().FullName.GetHashCode () ^ Range.GetHashCode () ^ Matrix.GetHashCode () ^ Transfer.GetHashCode () ^ Primaries.GetHashCode ();
		}

		private static GLib.GType GType {
			get { return GLib.GType.Pointer; }
		}
#endregion
	}
}
