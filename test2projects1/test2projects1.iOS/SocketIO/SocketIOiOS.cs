using Xamarin.Forms;
using Quobject.SocketIoClientDotNet.Client;
using test2projects1.iOS.SocketIO;
using System;
using Newtonsoft.Json;

[assembly: Dependency(typeof(SocketIOiOS))]

namespace test2projects1.iOS.SocketIO
{
    class SocketIOiOS : ISocket
    {
        public bool Connected()
        {
            return true;
        }

        public void OpenConnection(string URL)
        {
            var socket = IO.Socket(URL);
            socket.On(Socket.EVENT_CONNECT, () =>
            {
                //socket.Emit("hi");
                //MessagingCenter.Send("texto", "Hi", "Connected to Socket.io "+ URL);
                socket.Emit("MovilToSocket", "mensaje a socket");
            });

            socket.On("hi", (data) =>
            {
                Console.WriteLine(data);
                socket.Disconnect();
            });

            socket.On("MensajeSocket", (data) =>
            {
                RespuestaSocketIO resp = JsonConvert.DeserializeObject<RespuestaSocketIO>((string)data);
                MessagingCenter.Send("texto", "Hi", "Mensaje " + resp.Mensaje);
            });
        }

        public string ReceiveMessage()
        {
            return "";
        }

        public string SendMessage(string Method, string data)
        {
            return "";
        }
    }
}