using System;

namespace zadanie.Models
{
    /// <summary>
    /// Klasa sprawdzaj�ca, czy nie ma b��du.
    /// </summary>
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}