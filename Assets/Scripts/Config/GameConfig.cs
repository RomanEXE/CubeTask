namespace Config
{
    public static class GameConfig
    {
        public static int Speed = 1;
        public static int Distance = 100;
        public static int Time = 1;
        
        public static void ChangeValue(ConfigValueType type, int value)
        {
            GetValue(type) = value;
        }
        
        public static ref int GetValue(ConfigValueType type)
        {
            switch (type)
            {
                case ConfigValueType.Speed:
                    return ref Speed;
                case ConfigValueType.Distance:
                    return ref Distance;
            }

            return ref Time;
        }
    }
}