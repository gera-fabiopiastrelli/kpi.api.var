using System;
using System.Collections.Generic;

namespace kpi.api.functions.Model.Events
{
    public class BusinessSegmentEventArgs : BaseEventArgs
    {
        /// <summary>
        /// People Code
        /// </summary>
        public int PeopleCode { get; set; }

        /// <summary>
        /// Business segment Code
        /// </summary>
        public int BusinessSegmentCode { get; set; }

        /// <summary>
        /// Segment Old values
        /// </summary>
        public List<int> OldValues { get; set; }

        /// <summary>
        /// Segment new values
        /// </summary>
        public List<int> NewValues { get; set; }

        /// <summary>
        /// Indicates that the event was generated during cycle closing process
        /// </summary>
        public bool IsCycleClosing { get; set; }
    }
}
