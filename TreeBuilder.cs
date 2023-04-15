using System.Text;

namespace treeBuilder
{
    public class WordNode
    {
        public string val;
        public bool isAWord;
        public Dictionary<string, WordNode> children;
        public WordNode? parrent;

        public WordNode(string val, WordNode parrent)
        {
            this.val = val;
            isAWord = false;
            children = new Dictionary<string, WordNode>();
            this.parrent = parrent;
        }

        public void show()
        {
            Console.WriteLine("[" + val + "]");
        }
    }

    public class Tree
    {
        public WordNode root;

        public Tree()
        {
            root = new WordNode("", null);
        }

        public List<string> GetAllChildrenOfWord(WordNode current, string omitNode)
        {
            List<string> rhymes = new List<string>();

            foreach (WordNode node in current.children.Values)
            {
                if (omitNode != null && omitNode == node.val)
                {
                    continue;
                }

                if (node.isAWord)
                {
                    rhymes.Add(node.val);
                }
                rhymes.AddRange(GetAllChildrenOfWord(node, omitNode));
            }

            return rhymes;
        }

        public IEnumerable<string> GetRhymes(string word)
        {
            WordNode current = root;
            int wordLength = word.Length; // 4

            for (int i = 1; i <= wordLength; ++i)
            {
                WordNode next;
                if (!current.children.TryGetValue(word.Substring(wordLength - i), out next))
                {
                    next = new WordNode(word.Substring(wordLength - i), current);

                    if (i == wordLength)
                    {
                        next.isAWord = true;
                    }
                    current.children.Add(word.Substring(wordLength - i), next);
                }
                current = next;
            }

            List<string> rhymes = new List<string>();
            string omitNode = string.Empty;

            while (current.val.Length != 0)
            {
                rhymes.AddRange(GetAllChildrenOfWord(current, omitNode));
                omitNode = current.val;
                current = current.parrent;

                if (rhymes.Count > 150)
                    break;
            }

            return rhymes;
        }

        public void Insert(string word)
        {
            WordNode current = root;
            int wordLength = word.Length; // 4

            for (int i = 1; i <= wordLength; ++i)
            {
                WordNode next;
                if (!current.children.TryGetValue(word.Substring(wordLength - i), out next))
                {
                    next = new WordNode(word.Substring(wordLength - i), current);

                    if (i == wordLength)
                    {
                        next.isAWord = true;
                    }
                    current.children.Add(word.Substring(wordLength - i), next);
                }
                else if (next.val == word)
                {
                    next.isAWord = true;
                }
                current = next;
            }
        }

        public void LoadWords(string filePath)
        {
            // Зчитуємо файли по рядках
            string fileContent = File.ReadAllText(filePath, Encoding.UTF8);
            string[] words = fileContent.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // Виводимо кількість знайдених слів та список слів
            // Console.WriteLine($"Знайдено {words.Count()} слів:");
            foreach (string word in words)
            {
                //word.Replace("?", "");
                //Console.WriteLine(word);
                this.Insert(word);
            }
        }
    }
}
