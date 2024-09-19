using System;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

class Program
{
    private static MqttClient mqttClient;

    static void Main(string[] args)
    {
        Task.Run(() =>
        {
            MqttClient mqttClient = new MqttClient("144.126.135.248", 1883, false, null, null, MqttSslProtocols.None);

            mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
            string username = "Agri365";
            string password = "ICfm[47yiqV";
            string clientId = "Mqttrecive";
            mqttClient.Connect(clientId , username , password);

            if (mqttClient.IsConnected)
            {
                Console.WriteLine("Successfully connected to the broker.");

                // Subscribe to topic after ensuring connection
                mqttClient.Subscribe(new string[] { "test/topic" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
                Console.WriteLine("Subscribed to topic: test/topic");
            }
            else
            {
                Console.WriteLine("Failed to connect to the broker.");
            }
        });

        // Keep the application running
        Console.ReadLine();
    }

    private static void MqttClient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {
        string msg = Encoding.UTF8.GetString(e.Message);
        Console.WriteLine($"Message received: {msg}");
    }
}