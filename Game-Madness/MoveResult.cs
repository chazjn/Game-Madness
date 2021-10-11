namespace Game_Madness
{
    public class MoveResult
    {
        public bool Success { get; set; }
        public bool Jump { get; set; }

        public MoveResult(bool sucess)
        {
            Success = sucess;
            Jump = false;
        }

        public MoveResult(bool success, bool jump)
        {
            Success = success;
            Jump = jump;
        }
    }
}
