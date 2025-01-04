namespace DsAlRankToGlory.Problems.SortingAndSearching;

public class AnagramCount
{
    public static void CountAnagrams(string[] arr)
    {
        if (arr.Length > 5000)
        {
            return;
        }

        foreach (var pair in arr)
        {
            var pairStrings = pair.Split(' ');
            var sentence = pairStrings[0];
            var word = pairStrings[1];

            if (sentence.Length > 2500)
            {
                break;
            }

            if (word.Length > 500)
            {
                break;
            }

            var wordLetters = new Dictionary<char, int>();

            foreach (var c in word)
            {
                if (!wordLetters.TryGetValue(c, out var charCount))
                {
                    charCount = 1;
                    wordLetters.Add(c, charCount);
                }
                else
                {
                    charCount += 1;
                    wordLetters[c] = charCount;
                }
            }

            var position = 0;

            var outputPositions = new List<int>();

            while (position <= sentence.Length - word.Length)
            {
                var wordLettersCopy = new Dictionary<char, int>(wordLetters);

                for (var i = position; i < sentence.Length; i++)
                {
                    var currentLetter = sentence[i];

                    if (!wordLettersCopy.TryGetValue(currentLetter, out var charCount))
                    {
                        break;
                    }

                    charCount -= 1;
                    wordLettersCopy[currentLetter] = charCount;

                    if (charCount == 0)
                    {
                        wordLettersCopy.Remove(currentLetter);
                    }

                    if (i - position == word.Length - 1 && wordLettersCopy.Count == 0)
                    {
                        outputPositions.Add(position);
                        break;
                    }

                    if (wordLettersCopy.Count > 0 && i - position == word.Length - 1)
                    {
                        break;
                    }
                }

                position += 1;
            }
            
            Console.Write(outputPositions.Count);
        }
    }

    public static void CountAnagramsImproved(string[] arr)
    {
        if (arr.Length > 5000)
        {
            return;
        }

        foreach (var pair in arr)
        {
            var pairStrings = pair.Split(' ');
            var sentence = pairStrings[0];
            var word = pairStrings[1];

            if (sentence.Length > 2500)
            {
                break;
            }

            if (word.Length > 500)
            {
                break;
            }

            var wordLetters = new Dictionary<char, int>();

            foreach (var c in word)
            {
                if (!wordLetters.TryGetValue(c, out var charCount))
                {
                    charCount = 1;
                    wordLetters.Add(c, charCount);
                }
                else
                {
                    charCount += 1;
                    wordLetters[c] = charCount;
                }
            }

            var position = 0;
            var outputPositions = new List<int>();

            while (position <= sentence.Length - word.Length)
            {
                var wordLettersCopy = new Dictionary<char, int>(wordLetters);

                for (var i = position; i < sentence.Length; i++)
                {
                    var currentLetter = sentence[i];

                    if (!wordLettersCopy.TryGetValue(currentLetter, out var charCount))
                    {
                        break;
                    }

                    charCount -= 1;
                    wordLettersCopy[currentLetter] = charCount;

                    if (charCount == 0)
                    {
                        wordLettersCopy.Remove(currentLetter);
                    }

                    if (i - position == word.Length - 1 && wordLettersCopy.Count == 0)
                    {
                        outputPositions.Add(position);
                        break;
                    }

                    if (wordLettersCopy.Count > 0 && i - position == word.Length - 1)
                    {
                        break;
                    }
                }

                position += 1;
            }

            Console.Write(outputPositions.Count);

            if (outputPositions.Count > 0)
            {
                foreach (var letterPosition in outputPositions)
                {
                    Console.Write(String.Concat(" ", letterPosition));
                }
            }

            Console.WriteLine();
        }
    }

    public static void FasterAnagram(string[] tests)
    {
        for (var testIndex = 0; testIndex < tests.Length; testIndex++)
        {
            var source = tests[testIndex];

            var parts = source.Split(' ');

            var sentence = parts[0];
            var word = parts[1];

            const int firstCharOffset = 97;

            // Arrays to count letters in the word.
            var remainingLettersOriginal = new int[26];

            foreach (var letter in word)
            {
                var letterIndex = letter - firstCharOffset;

                remainingLettersOriginal[letterIndex] += 1;
            }

            var remainingLetters = new int[26];
            var remainingLettersCount = word.Length;
            var windowWidth = 0;

            Buffer.BlockCopy(remainingLettersOriginal, 0, remainingLetters, 0, remainingLetters.Length);

            var entries = new List<int>();

            var position = 0;
            var isSliding = false;

            while (position < sentence.Length)
            {
                var letterIndexCurrent = sentence[position] - firstCharOffset;
                var windowPosition = position - windowWidth;
                var letterIndexAtWindowPosition = sentence[windowPosition] - firstCharOffset;

                // If there're still remaining letters in anagram and current one is suitable.
                if (remainingLetters[letterIndexCurrent] > 0)
                {
                    remainingLetters[letterIndexCurrent] -= 1;

                    // We've found an anagram. Try to slide a window.
                    if (remainingLettersCount == 1)
                    {
                        entries.Add(windowPosition);

                        isSliding = true;

                        remainingLetters[letterIndexAtWindowPosition] += 1;
                    }
                    else
                    {
                        remainingLettersCount -= 1;
                        windowWidth += 1;
                    }
                }
                // Current letter is missing in remaining letters and we can't slide the window further. So, we need to reset.
                else if (letterIndexCurrent != letterIndexAtWindowPosition)
                {
                    // Sliding by one letter was wrong. Reset and not forget to include that wrong letter in new window.
                    // position - 2 + 1 = position - 1. The new windows will start from that letter. 
                    if (isSliding)
                    {
                        isSliding = false;
                        position -= 2;
                    }

                    Buffer.BlockCopy(remainingLettersOriginal, 0, remainingLetters, 0, remainingLetters.Length);

                    remainingLettersCount = word.Length;
                    windowWidth = 0;
                }

                position += 1;
            }
        }
    }
}