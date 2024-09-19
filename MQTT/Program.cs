using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

class Program
{
    static void Main(string[] args)
    {
        string message = Console.ReadLine();  // Read message from console

        // Create and connect the MQTT client
        MqttClient mqttClient = new MqttClient("144.126.135.248", 1883, false, null, null, MqttSslProtocols.None);
        string username = "agri365";
        string password = "ICfm[47yiqV";
        // Generate a unique client ID and connect
        string clientId = Guid.NewGuid().ToString();
        mqttClient.Connect(clientId , username, password);

        if (mqttClient.IsConnected)
        {
            Console.WriteLine("Connected to MQTT broker.");

            // Publish the message to the topic "test/topic" with QoS level 2 (exactly once) and no retained flag
            mqttClient.Publish("test/topic", Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
           // Console.WriteLine("Message Published: " + message);
        }
        else
        {
            Console.WriteLine("Failed to connect to the broker.");
        }

        // Disconnect the client
      //  mqttClient.Disconnect();
    }
}
