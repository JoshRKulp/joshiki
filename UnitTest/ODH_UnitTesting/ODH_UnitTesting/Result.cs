namespace ODH_UnitTesting
{
    public class Result
    {
        public string Transaction { get; set; }
        public int SampleCount { get; set; }
        public int ErrorCount { get; set; }
        public double ErrorPct { get; set; }
        public double MeanResTime { get; set; }
        public double MinResTime { get; set; }
        public double MaxResTime { get; set; }
        public double Pct1ResTime { get; set; }
        public double Pct2ResTime { get; set; }
        public double Pct3ResTime { get; set; }
        public double Throughput { get; set; }
        public double ReceivedKBytesPerSec { get; set; }
        public double SentKBytesPerSec { get; set; }
    }
}