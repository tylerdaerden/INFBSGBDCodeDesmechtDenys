using System;

namespace SGBDJeremy.Tools.CheckTools
{
    public static class Date_Check_Entries
    {
        /// <summary>
        /// Vérifie si une combinaison date + heure est antérieure à l’instant présent
        /// </summary>
        /// <param name="date">Date sélectionnée</param>
        /// <param name="time">Heure sélectionnée</param>
        /// <returns>True si dans le passé, false sinon</returns>
        public static bool IsDateInPast(DateTime date, TimeSpan time)
        {
            var selectedDateTime = date.Date + time;
            return selectedDateTime < DateTime.Now;
        }
    }
}
