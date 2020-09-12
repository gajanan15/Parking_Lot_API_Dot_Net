// <copyright file="MSMQService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotBussinessLayer.Implementation
{
    using System;
    using System.IO;
    using Experimental.System.Messaging;

    public class MSMQService
    {
        private MessageQueue messageQueue = new MessageQueue();

        public MSMQService()
        {
            this.messageQueue.Path = @".\private$\ParkingLot";
            if (MessageQueue.Exists(this.messageQueue.Path))
            {
                this.messageQueue = new MessageQueue(this.messageQueue.Path);
            }
            else
            {
                this.messageQueue = MessageQueue.Create(this.messageQueue.Path);
            }
        }

        public void AddToQueue(string message)
        {
            this.messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });

            this.messageQueue.ReceiveCompleted += this.ReceiverQueue;

            this.messageQueue.Send(message);

            this.messageQueue.BeginReceive();

            this.messageQueue.Close();
        }

        public void ReceiverQueue(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {
                var msg = this.messageQueue.EndReceive(e.AsyncResult);

                string data = msg.Body.ToString();

                // Process the logic be sending the message
                using (StreamWriter file = new StreamWriter(Directory.GetCurrentDirectory() + @"\ParkingRecords.txt", true))
                {
                    file.WriteLine(data);
                }

                // Restart the asynchronous receive operation.
                this.messageQueue.BeginReceive();
            }
            catch (MessageQueueException)
            {
            }
        }
    }
}
