using System;
using DevExpress.Xpo;
using NB.Core.Enumerator;

namespace NB.Core.Model
{
    /// <summary>
    /// Журнад событий.
    /// </summary>
    public class EventLog : XPCustomObject
    {
        private int fOid;
        [Key(AutoGenerate = true), MemberDesignTimeVisibility(false)]
        public int Oid
        {
            get { return fOid; }
            set { SetPropertyValue(nameof(Oid), ref fOid, value); }
        }

        public EventLog() { }
        public EventLog(Session session) : base(session) { }

        [DisplayName("Наименование задачи")]
        public string Name => Task?.Name;

        [DisplayName("IP")]
        public string TaskIPAddress => Task?.IPAddress;

        /// <summary>
        /// Дата события.
        /// </summary>
        [DisplayName("Дата события")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Код события.
        /// </summary>
        [DisplayName("Тип события")]
        public Event? Event { get; set; }

        [DisplayName("Каталог сохранения")]
        public string TaskSaveDirectory => Task?.SaveDirectory;

        [DisplayName("Каталог копирования")]
        public string TaskCopyDirectory => Task?.CopyDirectory;

        /// <summary>
        /// Задача.
        /// </summary>
        [Association, MemberDesignTimeVisibility(false)]
        public Task Task { get; set; }
    }
}