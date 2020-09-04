// <copyright file="ResponseEntity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParkingLotModelLayer
{
    using System.Net;

    /// <summary>
    /// Craete Response Entity.
    /// </summary>
    public class ResponseEntity
    {
        public HttpStatusCode HttpStatusCode;
        public string Message;
        public object Data;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseEntity"/> class.
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        public ResponseEntity(HttpStatusCode statusCode, string message, object data)
        {
            this.HttpStatusCode = statusCode;
            this.Message = message;
            this.Data = data;
        }
    }
}
