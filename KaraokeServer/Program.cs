using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class ClientInfo
{
    public string Name { get; set; }
    public string Image { get; set; }
}

public class Room
{
    public string RoomId { get; set; }
    public List<(TcpClient client, ClientInfo info)> Clients { get; set; }

    public Room(string roomId)
    {
        RoomId = roomId;
        Clients = new List<(TcpClient client, ClientInfo info)>();
    }
}

public class KaraokeServer
{
    private TcpListener server;
    private bool isRunning;
    private Dictionary<string, Room> rooms;
    private Random random;

    public KaraokeServer()
    {
        server = new TcpListener(IPAddress.Any, 8888);
        server.Start();
        isRunning = true;
        rooms = new Dictionary<string, Room>();
        random = new Random();
        Listen();
    }

    private void Listen()
    {
        Console.WriteLine("Server started, waiting for connections...");
        while (isRunning)
        {
            // Accept incoming connection requests and handle them in separate threads
            TcpClient newClient = server.AcceptTcpClient();
            Console.WriteLine("New client connected.");
            Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
            t.Start(newClient);
        }
    }

    private void HandleClient(object obj)
    {
        TcpClient client = (TcpClient)obj;
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];

        try
        {
            while (true)
            {
                int byteCount = stream.Read(buffer, 0, buffer.Length);
                if (byteCount == 0)
                {
                    // Client disconnected
                    break;
                }

                string message = Encoding.ASCII.GetString(buffer, 0, byteCount);
                Console.WriteLine(message);
                ProcessMessage(client, message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            client.Close();
            Console.WriteLine("Client disconnected.");
        }
    }

    private void ProcessMessage(TcpClient client, string message)
    {
        NetworkStream stream = client.GetStream();

        if (message.StartsWith("CREATE_ROOM"))
        {
            var jsonData = message.Substring("CREATE_ROOM ".Length);
            var clientData = JsonConvert.DeserializeObject<dynamic>(jsonData);

            string roomId = GenerateRoomId();
            Room newRoom = new Room(roomId);

            ClientInfo newClientInfo = new ClientInfo
            {
                Name = clientData.name.ToString(),
                Image = clientData.image.ToString()
            };
            newRoom.Clients.Add((client, newClientInfo));

            rooms.Add(roomId, newRoom);
            Console.WriteLine($"Room {roomId} created.");

            string successMessage = $"CREATE_ROOM_SUCCESS {roomId}";
            byte[] successMessageBytes = Encoding.ASCII.GetBytes(successMessage);
            stream.Write(successMessageBytes, 0, successMessageBytes.Length);

            SendExistingClientsInfo(roomId, client);
        }
        else if (message.StartsWith("JOIN_ROOM"))
        {
            var jsonData = message.Substring("JOIN_ROOM ".Length);
            var clientData = JsonConvert.DeserializeObject<dynamic>(jsonData);

            string roomId = clientData.roomId;
            if (rooms.ContainsKey(roomId))
            {
                rooms[roomId].Clients.Add((client, new ClientInfo
                {
                    Name = clientData.name.ToString(),
                    Image = clientData.image.ToString()
                }));
                Console.WriteLine($"Client joined room {roomId}.");

                string successMessage = $"JOIN_ROOM_SUCCESS {roomId}";
                byte[] successMessageBytes = Encoding.ASCII.GetBytes(successMessage);
                stream.Write(successMessageBytes, 0, successMessageBytes.Length);

                SendNewClientInfo(roomId, clientData.name.ToString(), clientData.image.ToString());
                SendExistingClientsInfo(roomId, client);
            }
        }
        else if (message.StartsWith("GET_CLIENTS_INFO"))
        {
            var roomId = message.Substring("GET_CLIENTS_INFO ".Length);
            if (rooms.ContainsKey(roomId))
            {
                SendExistingClientsInfo(roomId, client);
            }
        }
    }

    private void SendNewClientInfo(string roomId, string newClientName, string newClientImage)
    {
        Room room = rooms[roomId];
        foreach ((TcpClient client, ClientInfo info) in room.Clients)
        {
            NetworkStream stream = client.GetStream();

            var data = new
            {
                type = "NEW_CLIENT_JOIN",
                name = newClientName,
                image = newClientImage
            };

            string jsonData = JsonConvert.SerializeObject(data);
            byte[] jsonDataBytes = Encoding.ASCII.GetBytes(jsonData);

            stream.Write(jsonDataBytes, 0, jsonDataBytes.Length);
        }
    }

    private void SendExistingClientsInfo(string roomId, TcpClient newClient)
    {
        Room room = rooms[roomId];
        foreach ((TcpClient client, ClientInfo info) in room.Clients)
        {

            NetworkStream stream = newClient.GetStream();

            var data = new
            {
                type = "EXISTING_CLIENT_INFO",
                name = info.Name,
                image = info.Image
            };

            string jsonData = JsonConvert.SerializeObject(data);
            byte[] jsonDataBytes = Encoding.ASCII.GetBytes(jsonData);

            stream.Write(jsonDataBytes, 0, jsonDataBytes.Length);

        }
    }

    private string GenerateRoomId()
    {
        string roomId;
        do
        {
            roomId = random.Next(100000, 999999).ToString();
        } while (rooms.ContainsKey(roomId));

        return roomId;
    }

    public static void Main()
    {
        new KaraokeServer();
    }
}
