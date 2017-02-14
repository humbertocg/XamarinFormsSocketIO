using System;

namespace test2projects1
{
    public interface ISocket
    {
        void OpenConnection(String URL);
        bool Connected();
        String SendMessage(String Method, String data);
        string ReceiveMessage();
    }
}
