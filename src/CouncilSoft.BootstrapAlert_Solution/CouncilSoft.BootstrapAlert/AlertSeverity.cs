using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouncilSoft.BootstrapAlert
{
    /// <summary>
    /// Enum for message severities
    /// </summary>
    public enum AlertSeverity
    {
        /// <summary>
        /// Severity of error or bootstrap "Danger".
        /// </summary>
        Danger = -2,
        /// <summary>
        /// Severity of warning.
        /// </summary>
        Warning = -1,
        /// <summary>
        /// Severity of informational.
        /// </summary>
        Info = 0,
        /// <summary>
        /// Severity of success.
        /// </summary>
        Success = 1,
    }
}
