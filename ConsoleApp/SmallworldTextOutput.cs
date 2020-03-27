using System.IO;

namespace ConsoleApp
{
    class SmallworldTextOutput
    {
        private TextWriter textWriter;

        public SmallworldTextOutput(TextWriter textWriter)
        {
            this.textWriter = textWriter;
        }
    }
}
