using System;
using System.Linq;

namespace LeeCodeAnswers
{
    public class ChangeLetters
    {
        public int MinimumSwap(string s1, string s2)
        {
            if (s1.Equals(s2))
                return 0;

            if (s1.Length != s2.Length)
                return -1;            

            char[] char1 = s1.ToCharArray();
            char[] char2 = s2.ToCharArray();

            int countX = char1.Count(c => c == 'x') + char2.Count(c => c == 'x');
            int countY = char1.Count(c => c == 'y') + char2.Count(c => c == 'y');

            if (countX % 2 > 0 || countY % 2 > 0)
                return -1;

            char different = 'x';
            int count = 0;
            for(int i = 0; i < char1.Length; i++)
            {
                if(char1[i] != char2[i])
                {
                    different = char1[i];
                    for (int j = i + 1; j < char1.Length; j++)
                    {
                        if(char1[j] != char2[j] && char1[i] != char2[j])
                        {
                            char1[i] = char2[j];
                            char2[j] = different;
                            count++;
                            break;
                        }
                    }
                }
            }

            if (char1.Equals(char2))
                return count;

            for (int i = 0; i < char1.Length; i++)
            {
                if (char1[i] != char2[i])
                {
                    different = char1[i];
                    for (int j = i; j < char1.Length; j++)
                    {
                        if (char1[j] != char2[j] && char1[i] == char2[j])
                        {
                            char1[i] = char2[j];
                            char2[j] = different;
                            count++;
                            break;
                        }
                    }
                }
            }

            if (char1.Equals(char2))
                return count;

            for (int i = 0; i < char1.Length; i++)
            {
                if (char1[i] != char2[i])
                {
                    different = char1[i];
                    for (int j = i; j < char1.Length; j++)
                    {
                        if (char1[j] != char2[j] && char1[i] != char2[j])
                        {
                            char1[i] = char2[j];
                            char2[j] = different;
                            count++;
                            break;
                        }
                    }
                }
            }

            return count;
        }
    }
}
