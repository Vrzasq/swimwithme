namespace api.commons
{
    public class TrainingBasicVolume
    {
        public TrainingBasicVolume() { }
        public TrainingBasicVolume(int volume)
        {
            BasicVolume = volume;
            VolumeVariation = GetVolumevariation(volume);
        }

        public int BasicVolume { get; set; }
        public int VolumeVariation { get; set; }

        public static TrainingBasicVolume Amateur =>
            new TrainingBasicVolume { BasicVolume = 1500, VolumeVariation = 200 };

        public static TrainingBasicVolume SemiPro =>
            new TrainingBasicVolume { BasicVolume = 3000, VolumeVariation = 500 };

        public static TrainingBasicVolume Pro =>
            new TrainingBasicVolume { BasicVolume = 5000, VolumeVariation = 700 };

        private int GetVolumevariation(int volume)
        {
            if (volume <= 2200)
                return 200;
            else if (volume > 2200 && volume <= 4000)
                return 500;
            else if (volume > 4000 && volume <= 5500)
                return 700;
            else
                return 1000;
        }
    }
}
