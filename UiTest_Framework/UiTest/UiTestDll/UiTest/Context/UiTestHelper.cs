using System;

namespace Assets.UiTest.Context
{
    public class UiTestHelper
    {
        private static DateTime _date = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        private static DateTime _dateTimeStart;

        public static void Start()
        {
            _dateTimeStart = DateTime.UtcNow;
        }

        public static double GetTsNow()
        {
            return (DateTime.UtcNow - _date).TotalSeconds;
        }

        public static float GetTimeFromStart()
        {
            return (float) (DateTime.UtcNow - _dateTimeStart).TotalSeconds;
        }
    }
}