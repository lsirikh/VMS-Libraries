// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst.RtspServer {

	using System;

	public delegate void NewStateHandler(object o, NewStateArgs args);

	public class NewStateArgs : GLib.SignalArgs {
		public int Object{
			get {
				return (int) Args [0];
			}
		}

	}
}
