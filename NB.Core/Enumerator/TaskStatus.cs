using System.ComponentModel;

namespace NB.Core.Enumerator
{
    /// <summary>
    /// Статус задачи.
    /// </summary>
    public enum TaskStatus
    {
        /// <summary>
        /// Выполняется.
        /// </summary>
        [Description("Выполняется")]
        Performed = 1,

        /// <summary>
        /// Ошибка.
        /// </summary>
        [Description("Ошибка")]
        Error = 2,

        /// <summary>
        /// Остановлено.
        /// </summary>
        [Description("Остановлено")]
        IsStopped = 3,
    }
}
