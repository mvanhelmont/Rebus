using System;
using System.Collections.Generic;

namespace Rebus
{
    /// <summary>
    /// This is 
    /// </summary>
    public interface IMessageContext
    {
        /// <summary>
        /// Gets the return address of the message that is currently being handled.
        /// </summary>
        string ReturnAddress { get; }

        /// <summary>
        /// Gets the ID of the message that is currently being handled.
        /// </summary>
        string TransportMessageId { get; }

        /// <summary>
        /// Gets the dictionary of objects associated with this message context.
        /// </summary>
        IDictionary<string, object> Items { get; }

        /// <summary>
        /// Aborts processing the current message - i.e., after exiting from the
        /// current handler, no more handlers will be called. Note that this does
        /// not cause the current transaction to be rolled back.
        /// </summary>
        void Abort();

        event Action Disposed;

        /// <summary>
        /// Returns the logical message currently being handled.
        /// </summary>
        object CurrentMessage { get; }

#if DEBUG
        string StackTrace { get; set; }
#endif
    }
}