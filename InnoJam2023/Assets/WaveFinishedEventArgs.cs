namespace DefaultNamespace
{
    public class WaveFinishedEventArgs : System.EventArgs
    {
        public WaveFinishedEventArgs(int waveSize, int enemyKillCount, int enemyReachedGoalCount)
        {
            WaveSize = waveSize;
            EnemyKillCount = enemyKillCount;
            EnemyReachedGoalCount = enemyReachedGoalCount;
        }

        public int WaveSize { get; }
        public int EnemyKillCount { get; }
        public int EnemyReachedGoalCount { get; }
    }
}