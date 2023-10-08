namespace DefaultNamespace
{
    public class WaveFinishedEventArgs : System.EventArgs
    {
        public WaveFinishedEventArgs(int waveSize, int waveIndex, int enemyKillCount, int enemyReachedGoalCount)
        {
            WaveSize = waveSize;
            WaveIndex = waveIndex;
            EnemyKillCount = enemyKillCount;
            EnemyReachedGoalCount = enemyReachedGoalCount;
        }

        public int WaveSize { get; }
        
        public int WaveIndex { get; }
        public int EnemyKillCount { get; }
        public int EnemyReachedGoalCount { get; }
    }
}