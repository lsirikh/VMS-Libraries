// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst {

	using System;

	public delegate void UnlinkedHandler(object o, UnlinkedArgs args);

	public class UnlinkedArgs : GLib.SignalArgs {
		public Gst.Pad Peer{
			get {
				return (Gst.Pad) Args [0];
			}
		}

	}
}
