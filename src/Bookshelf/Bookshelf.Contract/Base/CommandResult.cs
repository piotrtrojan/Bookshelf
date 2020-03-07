using System;
using System.Runtime.Serialization;

namespace Bookshelf.Contract.Base
{
    [Serializable]
    public class CommandResult : ISerializable
    {
        public bool IsFailure { get; }
        public bool IsSuccess { get; }
        public string Error { get; }
        public string Message { get; }

        private CommandResult(bool isFailure, string error, string message)
        {
            IsFailure = isFailure;
            IsSuccess = !isFailure;
            Error = error;
            Message = message;
        }

        public static CommandResult Fail(string error)
        {
            return new CommandResult(true, error, string.Empty);
        }

        public static CommandResult Ok()
        {
            return new CommandResult(false, string.Empty, string.Empty);
        }

        public static CommandResult Ok(int message)
        {
            return new CommandResult(false, string.Empty, message.ToString());
        }

        public static CommandResult Ok(string message)
        {
            return new CommandResult(false, string.Empty, message);
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        protected CommandResult(SerializationInfo serializationInfo, StreamingContext streamingContext)
        {
            throw new NotImplementedException();
        }
    }
}
