// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst.FFT {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[StructLayout(LayoutKind.Sequential)]
	public partial struct FFTF32Complex : IEquatable<FFTF32Complex> {

		public float R;
		public float I;

		public static Gst.FFT.FFTF32Complex Zero = new Gst.FFT.FFTF32Complex ();

		public static Gst.FFT.FFTF32Complex New(IntPtr raw) {
			if (raw == IntPtr.Zero)
				return Gst.FFT.FFTF32Complex.Zero;
			return (Gst.FFT.FFTF32Complex) Marshal.PtrToStructure (raw, typeof (Gst.FFT.FFTF32Complex));
		}

		public bool Equals (FFTF32Complex other)
		{
			return true && R.Equals (other.R) && I.Equals (other.I);
		}

		public override bool Equals (object other)
		{
			return other is FFTF32Complex && Equals ((FFTF32Complex) other);
		}

		public override int GetHashCode ()
		{
			return this.GetType ().FullName.GetHashCode () ^ R.GetHashCode () ^ I.GetHashCode ();
		}

		private static GLib.GType GType {
			get { return GLib.GType.Pointer; }
		}
#endregion
	}
}
