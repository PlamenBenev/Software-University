using P01_StudentSystem.Data;

namespace P01_StudentSystem;

public class StartUp
{
    public static void Main()
    {
        var ctx = new StudentSystemContext();
        ctx.Database.EnsureDeleted();
        ctx.Database.EnsureCreated();
    }
}