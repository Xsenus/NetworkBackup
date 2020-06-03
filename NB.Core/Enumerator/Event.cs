using System.ComponentModel;

namespace NB.Core.Enumerator
{
    /// <summary>
    /// Событие.
    /// </summary>
    public enum Event
    {
        /// <summary>
        /// Старт.
        /// </summary>
        [Description("Старт")]
        Start = 1,

        /// <summary>
        /// Стоп.
        /// </summary>
        [Description("Стоп")]
        Stop = 2,

        /// <summary>
        /// Архивация.
        /// </summary>
        [Description("Архивация")]
        Archiving = 3,

        /// <summary>
        /// Ошибка.
        /// </summary>
        [Description("Ошибка")]
        Error = 4,

        /// <summary>
        /// Создание.
        /// </summary>
        [Description("Создание")]
        Creature = 5,

        /// <summary>
        /// Удаление.
        /// </summary>
        [Description("Удаление")]
        Delete = 6,

        /// <summary>
        /// Изменение.
        /// </summary>
        [Description("Изменение")]
        Edit = 7
    }
}
