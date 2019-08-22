namespace KG.UI
{
    public class Settings
    {
        public static Settings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Settings();
                }

                return _instance;
            }
        }

        private static Settings _instance;

        public bool AudioEnabled = true;
    }
}