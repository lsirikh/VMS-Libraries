// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst.RtspServer {

	using System;

	public delegate void MediaConfigureHandler(object o, MediaConfigureArgs args);

	public class MediaConfigureArgs : GLib.SignalArgs {
		public Gst.RtspServer.RTSPMedia Object{
			get {
				return (Gst.RtspServer.RTSPMedia) Args [0];
			}
		}

	}
}
