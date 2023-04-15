using treeBuilder;

namespace Rhymes
{
    public class WordBank
    {
        private const string filePath = @"C:\Users\vladm\Desktop\stress.txt";

        private WordBank() { }

        private static Tree? instance;

        public static Tree getInstance()
        {
            if (instance == null)
            {
                instance = new Tree();
                instance.LoadWords(filePath);
            }

            return instance;
        }
    }
}
