using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradbook : BaseGradeBook
    {
        public RankedGradbook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }
    }
}
