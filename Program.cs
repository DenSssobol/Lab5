using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lab5
{
    class Punct
    {
        List<string> listp;
        public Punct()
        {
            listp = new List<string>();
            listp.Add(",");
            listp.Add(":");
            listp.Add("-");
        }
        public bool Cont(string lastLetter)
        {
            foreach (string p in listp)
            {
                if (lastLetter == p)
                    return true;
            }
            return false;
        }
    }
    class Let
    {
        private char letter;
        public Let(char l)
        {
            this.letter = l;
        }

        public string GetLet
        {
            get { return letter.ToString(); }
        }
    }
    class Word
    {
        private string word;
        private Let[] arrayLet;
        public Word(string w)
        {
            this.word = w;
            arrayLet = new Let[word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                Let l = new Let(word[i]);
                arrayLet[i] = l;
            }
        }
        public int GetLenArrayLet
        {
            get { return arrayLet.Length; }
        }

        public Let GetLet(int k)
        {
            return arrayLet[k];
        }
        public string GetWord
        {
            get { return word; }
        }
    }
    class Sent
    {
        private Word[] arrayW;
        public Sent(string sent)
        {
            string[] sentArrayW = sent.Replace(", ", ",+").Split(new char[] { ' ', '+' }, StringSplitOptions.RemoveEmptyEntries);
            arrayW = new Word[sentArrayW.Length];
            for (int i = 0; i < sentArrayW.Length; i++)
            {
                Word word = new Word(sentArrayW[i]);
                arrayW[i] = word;
            }
        }
        public int GetLenArrayW
        {
            get { return arrayW.Length; }
        }
        public Word GetW(int j)
        {
            return arrayW[j];
        }
    }
    class Text
    {
        private int givlen;
        private string listcons = "бвгджзйклмнпрстфхцчшщьБВГДЖЗЙКЛМНПРСТФХШЩЦЧ";
        private Sent[] arraySent;
        private string result = "";
        public Text(string t, int g)
        {
            this.givlen = g;
            string[] textArraySent = t.Split(new char[] { '!', '?', '.' }, StringSplitOptions.RemoveEmptyEntries);
            arraySent = new Sent[textArraySent.Length];
            for (int i = 0; i < textArraySent.Length; i++)
            {
                Sent s = new Sent(textArraySent[i]);
                arraySent[i] = s;
            }
            EditText();
        }
        private void EditText()
        {
            for (int i = 0; i < arraySent.Length; i++)
            {
                Sent a = arraySent[i];
                for (int j = 0; j < a.GetLenArrayW; j++)
                {
                    Word b = a.GetW(j);
                    string x1 = b.GetLet(0).GetLet;
                    string x2 = b.GetLet(b.GetLenArrayLet - 1).GetLet;
                    Punct punct = new Punct();
                    if (punct.Cont(x2))
                    {
                        if (listcons.Contains(x1) == false | b.GetLenArrayLet != givlen + 1)
                        {
                            result += b.GetWord + " ";
                        }
                    }
                    else
                    {
                        if (listcons.Contains(x1) == false | b.GetLenArrayLet != givlen)
                        {
                            result += b.GetWord + " ";
                        }
                    }
                }
                result += ".";
            }
        }
        public string GetResult
        {
            get { return result.Replace(" .",". "); }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string myText = "У нас в городе цветы - розы, тюльпаны, ромашки. Лида почему тебя не было в школе? Учёбу свет, не учёба тьма. Ура! Марина пришла! Когда же наступят каникулы? ";
            Console.WriteLine(myText);

            Text comon = new Text(myText,5);
            string rez = comon.GetResult;

            Console.WriteLine(rez);
            Console.ReadKey();
        }
    }
}
