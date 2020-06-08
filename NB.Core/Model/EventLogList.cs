using System;
using System.Collections.Generic;
using System.Linq;

namespace NB.Core.Model
{
    /// <summary>
    /// Список событий.
    /// </summary>
    public class EventLogList
    {
        public Task Task { get; }
        public List<EventLog> EventLogs { get; }

        public EventLogList(Task task)
        {
            Task = task ?? throw new Exception();
            EventLogs = task.EventLogs.ToList();
        }

        public override string ToString()
        {
            return Task.Name;
        }
    }
}