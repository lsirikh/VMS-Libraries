// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst.Base {

	using System;

	public delegate void BufferConsumedHandler(object o, BufferConsumedArgs args);

	public class BufferConsumedArgs : GLib.SignalArgs {
		public Gst.Buffer Object{
			get {
				return (Gst.Buffer) Args [0];
			}
		}

	}
}
