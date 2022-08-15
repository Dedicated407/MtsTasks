namespace ElephantOutOfFly;

internal static class Program
{
    private static void Main(string[] args)
    {
        TransformToElephant();
        Console.WriteLine("Муха");
        //... custom application code
    }
    
    private static void TransformToElephant()
    {
        Console.SetOut(new TransformToElephantTextWriter(Console.Out));
    }

    private class TransformToElephantTextWriter : StringWriter
    {
        private readonly TextWriter _out;

        public TransformToElephantTextWriter(TextWriter @out)
        {
            _out = @out;
        }

        public override void WriteLine(string? value)
        {
            if (value == "Муха")
            {
                value = "Слон";
            }
         
            _out.WriteLine(value);
        }
    }
}
