﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class SynchronousSocketClient
{

    public static void StartClient(string input)
    {
        // Data buffer for incoming data.  
        byte[] bytes = new byte[1024];

        // Connect to a remote device.  
        try
        {
            // Establish the remote endpoint for the socket.  
            // This example uses port 11000 on the local computer.  
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 9601);

            // Create a TCP/IP  socket.  
            Socket sender = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Connect the socket to the remote endpoint. Catch any errors.  
            try
            {
                sender.Connect(remoteEP);

                Console.WriteLine("Socket connected to {0}",
                    sender.RemoteEndPoint.ToString());

                // Encode the data string into a byte array.  
                byte[] msg = Encoding.ASCII.GetBytes(input + " <EOF>");

                // Send the data through the socket.  
                int bytesSent = sender.Send(msg);

                // Receive the response from the remote device.  
                //int bytesRec = sender.Receive(bytes);
                //Console.WriteLine("Echoed test = {0}",
                    //Encoding.ASCII.GetString(bytes, 0, bytesRec));

                // Release the socket.  
                //sender.Shutdown(SocketShutdown.Both);
                sender.Close();

            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public static int Main(String[] args)
    {
        while(true)
            StartClient(Console.ReadLine());
        

        return 0;
    }
}