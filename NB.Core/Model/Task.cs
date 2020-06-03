using DevExpress.Xpo;
using NB.Core.Enumerator;
using System;

namespace NB.Core.Model
{
    public class Task : XPCustomObject
    {
        private int fOid;
        [Key(AutoGenerate = true), MemberDesignTimeVisibility(false)]
        public int Oid
        {
            get { return fOid; }
            set { SetPropertyValue(nameof(Oid), ref fOid, value); }
        }

        public Task() { }
        public Task(Session session) : base(session) { }

        /// <summary>
        /// Наименование.
        /// </summary>
        [DisplayName("Наименование")]
        public string Name { get; set; }

        /// <summary>
        /// IP адрес.
        /// </summary>
        [DisplayName("IP адрес")]
        public string IPAddress { get; set; }

        /// <summary>
        /// Каталог копирования.
        /// </summary>
        [DisplayName("Каталог копирования")]
        public string CopyDirectory { get; set; }

        /// <summary>
        /// Каталог сохранения.
        /// </summary>
        [DisplayName("Каталог сохранения")]
        public string SaveDirectory { get; set; }

        /// <summary>
        /// Дата
        /// </summary>
        [DisplayName("Дата")]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Статус задачи.
        /// </summary>
        [DisplayName("Статус задачи")]
        public TaskStatus TaskStatus { get; set; }

        /// <summary>
        /// ID задачи на сервере.
        /// </summary>
        [MemberDesignTimeVisibility(false)]
        public int ServerOid { get; set; }

        /// <summary>
        /// События.
        /// </summary>
        [Association, Aggregated, MemberDesignTimeVisibility(false)]
        public XPCollection<EventLog> EventLogs
        {
            get
            {
                return GetCollection<EventLog>(nameof(EventLogs));
            }
        }

        [MemberDesignTimeVisibility(false)]
        public bool IsMonday { get; set; }

        [MemberDesignTimeVisibility(false)]
        public bool IsTuesday { get; set; }

        [MemberDesignTimeVisibility(false)]
        public bool IsWednesday { get; set; }

        [MemberDesignTimeVisibility(false)]
        public bool IsThursday { get; set; }

        [MemberDesignTimeVisibility(false)]
        public bool IsFriday { get; set; }

        [MemberDesignTimeVisibility(false)]
        public bool IsSaturday { get; set; }

        [MemberDesignTimeVisibility(false)]
        public bool IsSunday { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
