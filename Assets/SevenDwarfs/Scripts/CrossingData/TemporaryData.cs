namespace SevenDwarfs.CrossingData
{
    /// <summary>
    /// 受け渡しのために一時的に使用するデータ
    /// 一度受け渡ししたらもう使わないものはこれを継承
    /// </summary>
    public abstract class TemporaryData : CrossingDataBase
    {
        private enum State
        {
            Unavailable,
            Available,
        }

        private State state = State.Unavailable;

        public TemporaryData()
        {
            state = State.Available;
        }

        /// <summary>
        /// 一時データがロード可能かどうか
        /// </summary>
        /// <returns></returns>
        public bool CanReceive()
        {
            return state == State.Available;
        }

        /// <summary>
        /// 一時データの初期化
        /// </summary>
        public override void Unload()
        {
            base.Unload();

            state = State.Unavailable;
        }
    }
}
