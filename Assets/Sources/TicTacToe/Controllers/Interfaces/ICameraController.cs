namespace Sources.TicTacToe.Controllers.Interfaces
{
    public interface ICameraController
    {
        float Height { get; }
        float Width { get; }
        float FieldSize { get; set; }
        void FixCameraOrthographicSizeSize();
    }
}