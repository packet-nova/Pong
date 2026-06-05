namespace Assets.Scripts
{
    public struct ScoreData
    {
        public ScoreZone ScoreZone { get; }
        public Ball Ball { get; }

        public ScoreData(ScoreZone scoreZone, Ball ball)
        {
            ScoreZone = scoreZone;
            Ball = ball;
        }
    }
}
