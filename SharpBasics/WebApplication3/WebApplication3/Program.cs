using System.Net;
using System.Net.Sockets;

using Socket udpsocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

var localIP = new IPEndPoint(IPAddress.Parse(), )