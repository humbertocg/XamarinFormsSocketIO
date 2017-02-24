using System;
using Android.Speech.Tts;
using Xamarin.Forms;
using test2projects1.Droid.SocketIO;
using System.Collections.Generic;
using Android.App;
using Quobject.SocketIoClientDotNet.Client;
using Newtonsoft.Json;
//using test2projects1.Droid.Notificacion;

[assembly: Dependency(typeof(SocketIOAndroid))]

namespace test2projects1.Droid.SocketIO
{
    public class SocketIOAndroid : Java.Lang.Object, ISocket
    {
        public SocketIOAndroid()
        {

        }
        public void OpenConnection(String URL)
        {
            //DependencyService.Get<backservices>().returnprincipal("regresando", "regresando");
            //App mp = (App)Xamarin.Forms.Application.Current; 
            //MessagingCenter.Send<object, string>("texto", "Hi", "StackOverFlow Rocks");
            //MessagingCenter.Send("texto", "Hi", "Connected to Socket.io ");

            //Notificacion.Notificacion n = new Notificacion.Notificacion("Test notification offline");

            var option = new IO.Options
            {
                Reconnection = true,
                ReconnectionDelay = 1000,
                ReconnectionDelayMax = 3000,
                Timeout = 20000,
                ForceNew = true
            };
            var socket = IO.Socket(URL, option);
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
                //MessagingCenter.Send("texto", "Hi", "Mensaje " + resp.Mensaje);
                Notificacion.Notificacion n = new Notificacion.Notificacion("Mensaje " + resp.Mensaje);
            });
            //socket.Connect();
            //Console.ReadLine();
        }
        public bool Connected()
        {
            return false;
        }
        public String SendMessage(String Method, String data)
        {

            return "";
        }
        public string ReceiveMessage()
        {
            return "Mensaje recibido";
        }
    }
}