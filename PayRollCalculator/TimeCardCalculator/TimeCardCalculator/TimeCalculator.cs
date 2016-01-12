using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCardCalculator
{
    /// <summary>
    /// TimeCalculator trackes and adds the total time based on a 12 hour day and 
    /// 40 hour work week. Verifys text input accuracy. 
    /// </summary>
    class TimeCalculator
    {
        private TimeSpan monTime;
        private TimeSpan tueTime;
        private TimeSpan wedTime;
        private TimeSpan thurTime;
        private TimeSpan friTime;
        private TimeSpan satTime;
        private TimeSpan sunTime;
        private int totalHours;
        private int totalMin;


        /// <summary>
        /// Constructor Resets Totals
        /// </summary>
        public TimeCalculator()
        {
            ResetTotals();
        }
        /// <summary>
        /// Adds time to specific day of the week
        /// </summary>
        /// <param name="hour">Hours worked</param>
        /// <param name="min">Minites worked</param>
        /// <param name="d">The day of the week </param>
        public void AddTime(string inHour, string inMin, Day d)
        {
            int hour;
            int min;
            hour = CheckHour(inHour);
            min = CheckMin(inMin);

            switch (d)
            {
                case Day.Monday:
                    monTime = new TimeSpan(hour, min, 0);
                    break;
                case Day.Tuesday:
                    tueTime = new TimeSpan(hour, min, 0);
                    break;
                case Day.Wendsday:
                    wedTime = new TimeSpan(hour, min, 0);
                    break;
                case Day.Thursday:
                    thurTime = new TimeSpan(hour, min, 0);
                    break;
                case Day.Friday:
                    friTime = new TimeSpan(hour, min, 0);
                    break;
                case Day.Saturday:
                    satTime = new TimeSpan(hour, min, 0);
                    break;
                case Day.Sunday:
                    sunTime = new TimeSpan(hour, min, 0);
                    break;
            }
            TotalTime();
        }
        /// <summary>
        /// Adds time for all days of the week
        /// </summary>
        /// <returns>total time worked</returns>
        private void TotalTime()
        {
            TimeSpan totalTime = new TimeSpan();

            totalTime = totalTime.Add(monTime);
            totalTime = totalTime.Add(tueTime);
            totalTime = totalTime.Add(wedTime);
            totalTime = totalTime.Add(thurTime);
            totalTime = totalTime.Add(friTime);
            totalTime = totalTime.Add(satTime);
            totalTime = totalTime.Add(sunTime);

            totalHours = (totalTime.Days * 24) + totalTime.Hours;
            totalMin = totalTime.Minutes;
        }
        /// <summary>
        /// Removes saved data in class
        /// </summary>
        public void ResetTotals()
        {
            monTime = new TimeSpan();
            tueTime = new TimeSpan();
            wedTime = new TimeSpan();
            thurTime = new TimeSpan();
            friTime = new TimeSpan();
            satTime = new TimeSpan();
            sunTime = new TimeSpan();
        }
        /// <summary>
        /// Checks for hour accuracy 1-12
        /// </summary>
        /// <param name="hourText"></param>
        /// <returns>hour in int if between 1-13, or 0 if out of range</returns>
        private int CheckHour(string hourText)
        {
            int hour;
            if (int.TryParse(hourText, out hour))
            {
                if (hour < 0 && hour > 12)
                {
                    hour = 0;
                }
                hour = int.Parse(hourText);
            }
            return hour;
        }
        /// <summary>
        /// Checks for Minite accuracy 1-60
        /// </summary>
        /// <param name="minText"></param>
        /// <returns>minites in int if between 1-60 or 0 if out of range</returns>
        private int CheckMin(string minText)
        {
            int min;
            if (int.TryParse(minText, out min))
            {
                if (min < 0 && min > 60)
                {
                    min = 0;
                }

            }
            return min;
        }
        /// <summary>
        /// display total time worked in the week
        /// </summary>
        /// <returns>total time worked in the week</returns>
        public string DisplayWorkedTime()
        {
            string workedTime;

            workedTime = FormatToString(totalHours, totalMin);
            return workedTime;
        }
        /// <summary>
        /// formates overtime for display
        /// </summary>
        /// <returns>total hours over 40 for the work week</returns>
        public string DisplayOverTime()
        {
            string overTime;

            if (totalHours >= 40)
            {
                overTime = FormatToString(totalHours - 40, totalMin);
            }
            else
            {
                overTime = FormatToString(0, 0);
            }
            return overTime;
        }
        /// <summary>
        /// formats hours worked for reguler hours
        /// </summary>
        /// <returns>upto 40 hours in a work week</returns>
        public string DisplayRegulerHours()
        {
            string regTime;

            if (totalHours < 40)
            {
                regTime = FormatToString(totalHours, totalMin);
            }
            else
            {
                regTime = FormatToString(40, 0);
            }

            return regTime;
        }
        /// <summary>
        /// Changes hours and minites into a string time format
        /// </summary>
        /// <param name="hour">int hours</param>
        /// <param name="min">int minites</param>
        /// <returns>string in time format</returns>
        private string FormatToString(int hour, int min)
        {
            string timeFormat = String.Format("{0:00}:{1:00}", hour, min);
            return timeFormat;
        }
    }


    /// <summary>
    /// Days of the week enum
    /// </summary>
    public enum Day
    {
        Monday,
        Tuesday,
        Wendsday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
}

