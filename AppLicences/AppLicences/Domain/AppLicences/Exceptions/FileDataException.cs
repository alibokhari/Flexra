using System;

namespace AppLicences.Domain.AppLicences.Exceptions {
    public class FileDataException : Exception {
        public FileDataException(string message) : base(message) {
        }
    }
}
