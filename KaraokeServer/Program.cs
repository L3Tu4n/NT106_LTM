using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class Room
{
    public string RoomId { get; set; }
    public List<TcpClient> Clients { get; set; }

    public Room(string roomId)
    {
        RoomId = roomId;
        Clients = new List<TcpClient>();
    }
}

public class KaraokeServer
{
    private TcpListener server;
    private bool isRunning;
    private Dictionary<string, Room> rooms;

    public KaraokeServer()
    {
        server = new TcpListener(IPAddress.Any, 8888);
        server.Start();
        isRunning = true;
        rooms = new Dictionary<string, Room>();
        Listen();
    }

    private void Listen()
    {
        while (isRunning)
        {
            if (server.Pending())
            {
                TcpClient newClient = server.AcceptTcpClient();
                Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
                t.Start(newClient);
            }
        }
    }

    private void HandleClient(object obj)
    {
        TcpClient client = (TcpClient)obj;
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];
        int byteCount = stream.Read(buffer, 0, buffer.Length);
        string message = System.Text.Encoding.ASCII.GetString(buffer, 0, byteCount);

        if (message.StartsWith("JOIN_ROOM"))
        {
            string roomId = message.Split(' ')[1];
            if (rooms.ContainsKey(roomId))
            {
                rooms[roomId].Clients.Add(client);
            }
            else
            {
                Room newRoom = new Room(roomId);
                newRoom.Clients.Add(client);
                rooms.Add(roomId, newRoom);
            }
        }

        // Thêm logic xử lý dữ liệu âm thanh từ client và phát tới các client khác trong cùng phòng
    }

    public static void Main()
    {
        new KaraokeServer();
    }
}
