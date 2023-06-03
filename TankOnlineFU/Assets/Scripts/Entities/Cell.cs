namespace Entities
{
    public class Cell
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public Position Position { get; set; }
        public Cell()
        {

        }
        public Cell(float width, float height, Position position)
        {
            Width = width;
            Height = height;
            Position = position;
        }
    }
}
