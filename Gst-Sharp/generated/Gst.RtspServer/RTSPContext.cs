// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst.RtspServer {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[StructLayout(LayoutKind.Sequential)]
	public partial struct RTSPContext : IEquatable<RTSPContext> {

		private IntPtr _server;
		public Gst.RtspServer.RTSPServer Server {
			get {
				return GLib.Object.GetObject(_server) as Gst.RtspServer.RTSPServer;
			}
			set {
				_server = value == null ? IntPtr.Zero : value.Handle;
			}
		}
		private IntPtr _conn;
		public Gst.Rtsp.RTSPConnection Conn {
			get {
				return _conn == IntPtr.Zero ? null : (Gst.Rtsp.RTSPConnection) GLib.Opaque.GetOpaque (_conn, typeof (Gst.Rtsp.RTSPConnection), false);
			}
			set {
				_conn = value == null ? IntPtr.Zero : value.Handle;
			}
		}
		private IntPtr _client;
		public Gst.RtspServer.RTSPClient Client {
			get {
				return GLib.Object.GetObject(_client) as Gst.RtspServer.RTSPClient;
			}
			set {
				_client = value == null ? IntPtr.Zero : value.Handle;
			}
		}
		private IntPtr _request;

		public Gst.Rtsp.RTSPMessage request {
			get { return Gst.Rtsp.RTSPMessage.New (_request); }
		}
		private IntPtr _uri;

		public Gst.Rtsp.RTSPUrl uri {
			get { return Gst.Rtsp.RTSPUrl.New (_uri); }
		}
		public Gst.Rtsp.RTSPMethod Method;
		private IntPtr _auth;
		public Gst.RtspServer.RTSPAuth Auth {
			get {
				return GLib.Object.GetObject(_auth) as Gst.RtspServer.RTSPAuth;
			}
			set {
				_auth = value == null ? IntPtr.Zero : value.Handle;
			}
		}
		private IntPtr _token;
		public Gst.RtspServer.RTSPToken Token {
			get {
				return _token == IntPtr.Zero ? null : (Gst.RtspServer.RTSPToken) GLib.Opaque.GetOpaque (_token, typeof (Gst.RtspServer.RTSPToken), false);
			}
			set {
				_token = value == null ? IntPtr.Zero : value.Handle;
			}
		}
		private IntPtr _session;
		public Gst.RtspServer.RTSPSession Session {
			get {
				return GLib.Object.GetObject(_session) as Gst.RtspServer.RTSPSession;
			}
			set {
				_session = value == null ? IntPtr.Zero : value.Handle;
			}
		}
		private IntPtr _sessmedia;
		public Gst.RtspServer.RTSPSessionMedia Sessmedia {
			get {
				return GLib.Object.GetObject(_sessmedia) as Gst.RtspServer.RTSPSessionMedia;
			}
			set {
				_sessmedia = value == null ? IntPtr.Zero : value.Handle;
			}
		}
		private IntPtr _factory;
		public Gst.RtspServer.RTSPMediaFactory Factory {
			get {
				return GLib.Object.GetObject(_factory) as Gst.RtspServer.RTSPMediaFactory;
			}
			set {
				_factory = value == null ? IntPtr.Zero : value.Handle;
			}
		}
		private IntPtr _media;
		public Gst.RtspServer.RTSPMedia Media {
			get {
				return GLib.Object.GetObject(_media) as Gst.RtspServer.RTSPMedia;
			}
			set {
				_media = value == null ? IntPtr.Zero : value.Handle;
			}
		}
		private IntPtr _stream;
		public Gst.RtspServer.RTSPStream Stream {
			get {
				return GLib.Object.GetObject(_stream) as Gst.RtspServer.RTSPStream;
			}
			set {
				_stream = value == null ? IntPtr.Zero : value.Handle;
			}
		}
		private IntPtr _response;

		public Gst.Rtsp.RTSPMessage response {
			get { return Gst.Rtsp.RTSPMessage.New (_response); }
		}
		private IntPtr _trans;
		public Gst.RtspServer.RTSPStreamTransport Trans {
			get {
				return GLib.Object.GetObject(_trans) as Gst.RtspServer.RTSPStreamTransport;
			}
			set {
				_trans = value == null ? IntPtr.Zero : value.Handle;
			}
		}
		[MarshalAs (UnmanagedType.ByValArray, SizeConst=3)]
		private IntPtr[] _gstGstReserved;

		public static Gst.RtspServer.RTSPContext Zero = new Gst.RtspServer.RTSPContext ();

		public static Gst.RtspServer.RTSPContext New(IntPtr raw) {
			if (raw == IntPtr.Zero)
				return Gst.RtspServer.RTSPContext.Zero;
			return (Gst.RtspServer.RTSPContext) Marshal.PtrToStructure (raw, typeof (Gst.RtspServer.RTSPContext));
		}

		[DllImport("gstrtspserver-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gst_rtsp_context_pop_current(IntPtr raw);

		public void PopCurrent() {
			IntPtr this_as_native = System.Runtime.InteropServices.Marshal.AllocHGlobal (System.Runtime.InteropServices.Marshal.SizeOf (this));
			System.Runtime.InteropServices.Marshal.StructureToPtr (this, this_as_native, false);
			gst_rtsp_context_pop_current(this_as_native);
			ReadNative (this_as_native, ref this);
			System.Runtime.InteropServices.Marshal.FreeHGlobal (this_as_native);
		}

		[DllImport("gstrtspserver-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gst_rtsp_context_push_current(IntPtr raw);

		public void PushCurrent() {
			IntPtr this_as_native = System.Runtime.InteropServices.Marshal.AllocHGlobal (System.Runtime.InteropServices.Marshal.SizeOf (this));
			System.Runtime.InteropServices.Marshal.StructureToPtr (this, this_as_native, false);
			gst_rtsp_context_push_current(this_as_native);
			ReadNative (this_as_native, ref this);
			System.Runtime.InteropServices.Marshal.FreeHGlobal (this_as_native);
		}

		static void ReadNative (IntPtr native, ref Gst.RtspServer.RTSPContext target)
		{
			target = New (native);
		}

		public bool Equals (RTSPContext other)
		{
			return true && Server.Equals (other.Server) && Conn.Equals (other.Conn) && Client.Equals (other.Client) && request.Equals (other.request) && uri.Equals (other.uri) && Method.Equals (other.Method) && Auth.Equals (other.Auth) && Token.Equals (other.Token) && Session.Equals (other.Session) && Sessmedia.Equals (other.Sessmedia) && Factory.Equals (other.Factory) && Media.Equals (other.Media) && Stream.Equals (other.Stream) && response.Equals (other.response) && Trans.Equals (other.Trans);
		}

		public override bool Equals (object other)
		{
			return other is RTSPContext && Equals ((RTSPContext) other);
		}

		public override int GetHashCode ()
		{
			return this.GetType ().FullName.GetHashCode () ^ Server.GetHashCode () ^ Conn.GetHashCode () ^ Client.GetHashCode () ^ request.GetHashCode () ^ uri.GetHashCode () ^ Method.GetHashCode () ^ Auth.GetHashCode () ^ Token.GetHashCode () ^ Session.GetHashCode () ^ Sessmedia.GetHashCode () ^ Factory.GetHashCode () ^ Media.GetHashCode () ^ Stream.GetHashCode () ^ response.GetHashCode () ^ Trans.GetHashCode ();
		}

		private static GLib.GType GType {
			get { return GLib.GType.Pointer; }
		}
#endregion
	}
}
