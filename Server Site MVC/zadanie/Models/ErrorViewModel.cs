using System;

namespace zadanie.Models
{
    /// <summary>
    /// Klasa sprawdzaj¹ca, czy nie ma b³êdu.
    /// </summary>
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}