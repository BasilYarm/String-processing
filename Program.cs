using System;
using System.IO;
using System.Text;

namespace ProcString
{
    class Program
    {
        #region Fields
        static string allText = "";

        // File address
        static string fileAddress = "";

        static string maxWord = "";

        static string[] maxNumbers;

        // All words of the text without punctuation marks.
        static string[] allWordsOfText;

        // An array in which numbers are replaced by their verbal representation.
        static string[] numbersIntoWords;

        static string[] sentences;

        // Non-comma sentences.
        static string[] nonComSent;

        // Words on the same letter
        static string[] wordOnSammeLet;

        static int numMenu = 0;
        #endregion

        #region Main
        static void Main(string[] args)
        {
            StartProgram();
        }
        #endregion

        /// <summary>
        /// All logic.
        /// </summary>
        #region StartProgram
        static void StartProgram()
        {
            Console.Title = "String processing program";

            ShowGreeting();

            var helper = 0;

            // The general cycle of work of the program.
            while (true)
            {
                // If to leave as is, if nothing is entered, old operation is carried out.
                numMenu = 0;

                // On a following circle if to not clear the screen there will be 2 menus.
                if (helper > 0)
                {
                    Console.Clear();
                }

                Menu();

                EnterNumberMenu();

                var condition = allText != "";

                var message = "You yet did not count the text. Execute following operation:";

                switch (numMenu)
                {
                    case 1:
                        
                        allText = "";

                        Console.Clear();

                        var cond = helper == 0 && allText == "";

                        // We exclude processing not entered text at restart. 
                        if (!cond)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(message);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }


                        Case1();

                        break;

                    case 2:

                        // We exclude processing not entered text.
                        if (condition)
                        {
                            Case2();
                        }
                        else
                        {
                            helper++;

                            goto case 1;
                        }

                        break;

                    case 3:
                        if (condition)
                        {
                            Case3();
                        }
                        else
                        {
                            helper++;

                            goto case 1;
                        }

                        break;

                    case 4:
                        if (condition)
                        {
                            Case4();
                        }
                        else
                        {
                            helper++;

                            goto case 1;
                        }

                        break;

                    case 5:
                        if (condition)
                        {
                            Case5();
                        }
                        else
                        {
                            helper++;

                            goto case 1;
                        }

                        break;

                    case 6:
                        if (condition)
                        {
                            Case6();
                        }
                        else
                        {
                            helper++;

                            goto case 1;
                        }

                        break;

                    case 7:
                        if (condition)
                        {
                            Case7();
                        }
                        else
                        {
                            helper++;

                            goto case 1;
                        }

                        break;

                    case 8:
                        Case8();

                        break;

                    case 9:
                        Environment.Exit(0);

                        break;
                }

                helper++;
            }
        }
        #endregion

        /// <summary>
        /// Greeting output.
        /// </summary>
        #region ShowGreeting
        static void ShowGreeting()
        {
            // Greeting output.
            // Output of the inscription approximately to the middle of the window.
            Console.Write("\t\t");

            var greeting = "Hello! Welcome to the string program.";

            // Change font and background color
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Green;

            Console.WriteLine(greeting);

            // Return color and background
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine();
        }
        #endregion

        /// <summary>
        /// Display the main menu.
        /// </summary>
        #region Menu
        static void Menu()
        {
            Console.Write("\t");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("MENU:");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine();

            Console.WriteLine("press 1 to read line from file;");
            Console.WriteLine("press 2 to find words with the maximum number of digits;");
            Console.WriteLine("press 3 to determine the longest word and its repetitions;");
            Console.WriteLine("press 4 to replace numbers with words;");
            Console.WriteLine("press 5 to display interrogative and exclamation sentences;");
            Console.WriteLine("press 6 to display sentences that do not contain commas;");
            Console.WriteLine("press 7 to display words starting and ending with one letter;");
            Console.WriteLine("press 8 for program information;");
            Console.WriteLine("press 9 to exit the program.");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("select the required action: ");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        #endregion

        /// <summary>
        /// Main menu number input.
        /// </summary>
        #region EnterNumberMenu
        static void EnterNumberMenu()
        {
            // Cycle until one of the menu item numbers is entered
            while (true)
            {
                // Entering the action number from the menu
                try
                {
                    numMenu = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                var condition = numMenu > 0 && numMenu < 10;

                // Ccheck for correspondence of the number from the menu to the entered number
                if (condition)
                {
                    break;
                }
                else
                {
                    var message = "\nenter a number from 1 to 9: ";

                    Console.Clear();

                    Menu();

                    Console.Write(message);

                    continue;
                }
            }
        }
        #endregion

        /// <summary>
        /// Reading from file.
        /// </summary>
        #region ReadFromFile
        static void ReadFromFile()
        {
            FileStream fin = null;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Enter adress of file:");
                Console.ForegroundColor = ConsoleColor.Gray;

                fileAddress = Console.ReadLine();

                try
                {
                    fin = new FileStream(fileAddress, FileMode.Open, FileAccess.Read);

                    break;

                }
                catch (IOException exc)
                {
                    Console.Clear();

                    Console.WriteLine("I/O error:\n" + exc.Message);

                    continue;
                }
                catch (Exception exc)
                {
                    Console.Clear();

                    Console.WriteLine(exc.Message);

                    continue;
                }
            }

            while (true)
            {
                try
                {
                    StreamReader fStrIn = new StreamReader(fin);

                    try
                    {
                        while (!fStrIn.EndOfStream)
                        {
                            allText += fStrIn.ReadLine();
                        }
                    }
                    catch (IOException exc)
                    {
                        Console.WriteLine("I/O error:\n" + exc.Message);

                        continue;
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine(exc.Message);

                        continue;
                    }
                    finally
                    {
                        if (fin != null)
                        {
                            fin.Close();
                        }
                    }
                    break;
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);

                    continue;
                }
            }
        }
        #endregion

        /// <summary>
        /// Output all text.
        /// </summary>
        #region OutAllText
        static void OutAllText()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All text:");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine(allText);
        }
        #endregion

        /// <summary>
        /// Breaking text into words.
        /// </summary>
        #region WordSplitting
        static void WordSplitting()
        {
            int index = 1;

            // Count how many words are in the text.
            for (var i = 0; i < allText.Length; i++)
            {
                if (allText[i] == ' ')
                {
                    index++;
                }
            }

            // Division of text into words, but periods and commas are counted.
            allWordsOfText = new string[index];

            // To continue walking through the text instead of starting over.
            var count = 0;

            for (var i = 0; i < index; i++)
            {
                for (var j = count; j < allText.Length; j++)
                {
                    count++;

                    if (allText[j] == ' ')
                    {
                        break;
                    }

                    allWordsOfText[i] += allText[j];
                }
            }

            // Now just words without punctuation.
            for (var i = 0; i < allWordsOfText.Length; i++)
            {
                for (var j = 0; j < allWordsOfText[i].Length; j++)
                {
                    if (char.IsPunctuation(allWordsOfText[i][j]))
                    {
                        allWordsOfText[i] = allWordsOfText[i].Substring(0, allWordsOfText[i].Length - 1);
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// Maximum number of digits.
        /// </summary>
        #region MaxNumOfDig
        static void MaxNumOfDig()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nWords with the most numbers:");
            Console.ForegroundColor = ConsoleColor.Gray;

            int[] numDigOfwords = new int[allWordsOfText.Length];

            for (var i = 0; i < allWordsOfText.Length; i++)
            {
                numDigOfwords[i] = 0;
            }

            // Check on presence of figures in words if figures are we increase value of a file for this word, 
            // how many figures in a word such and value of an element of a array.
            for (var i = 0; i < allWordsOfText.Length; i++)
            {
                for (var j = 0; j < allWordsOfText[i].Length; j++)
                {
                    if (char.IsDigit(allWordsOfText[i][j]))
                    {
                        numDigOfwords[i]++;
                    }
                }
            }

            // Search of the maximal value in a file.
            int max = numDigOfwords[0];

            for (var i = 1; i < allWordsOfText.Length; i++)
            {
                if (max < numDigOfwords[i])
                {
                    max = numDigOfwords[i];
                }
            }

            // Calculation of amount of words in the text with the maximal value of amount of figures.
            int counter = 0;

            for (var i = 0; i < allWordsOfText.Length; i++)
            {
                if (max > 0 && max == numDigOfwords[i])
                {
                    counter++;
                }
            }

            maxNumbers = new string[counter];

            // If words with figures in the text are, we display them 
            // if such words are not present the text message.
            if (counter > 0)
            {
                counter = 0;

                for (var i = 0; i < allWordsOfText.Length; i++)
                {
                    if (max == numDigOfwords[i])
                    {
                        maxNumbers[counter] = allWordsOfText[i];

                        Console.Write(maxNumbers[counter] + " ");

                        counter++;
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("In the text there is no word with numbers!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        #endregion

        /// <summary>
        /// Finding the longest word in the text.
        /// </summary>
        #region MaxWordOfText
        static void MaxWordOfText()
        {
            // Additional array in which the amount of symbols of each word of the text will be stored.
            int[] numDigOfwords = new int[allWordsOfText.Length];

            for (var i = 0; i < allWordsOfText.Length; i++)
            {
                numDigOfwords[i] = 0;
            }

            for (var i = 0; i < allWordsOfText.Length; i++)
            {
                for (var j = 0; j < allWordsOfText[i].Length; j++)
                {
                    numDigOfwords[i]++;
                }
            }

            int max = numDigOfwords[0];

            for (var i = 1; i < allWordsOfText.Length; i++)
            {
                if (max < numDigOfwords[i])
                {
                    max = numDigOfwords[i];
                }
            }

            for (var i = 0; i < allWordsOfText.Length; i++)
            {
                if (max == numDigOfwords[i])
                {
                    maxWord = allWordsOfText[i];
                }
            }

            // Calculation of amount of these words in the text.
            int counter = 0;

            for (var i = 0; i < allWordsOfText.Length; i++)
            {
                if (maxWord == allWordsOfText[i])
                {
                    counter++;
                }
            }

            Console.Write("\nLongest word in the text: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(maxWord);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" it is repeated ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(counter);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" times.");
        }
        #endregion

        /// <summary>
        /// Find numbers and replace them with words.
        /// </summary>
        #region RepNumWord
        static void RepNumWord()
        {
            // The array will contain amount of figures in each word of the text.
            int[] numDigOfwords = new int[allWordsOfText.Length];

            for (var i = 0; i < numDigOfwords.Length; i++)
            {
                numDigOfwords[i] = 0;
            }

            // We run by all words.
            for (var i = 0; i < allWordsOfText.Length; i++)
            {
                // We run on all symbols in words.
                for (var j = 0; j < allWordsOfText[i].Length; j++)
                {
                    // If the symbol is figure we increase value of an element of a array.
                    if (char.IsDigit(allWordsOfText[i][j]))
                    {
                        numDigOfwords[i]++;
                    }
                }
            }

            // We count how many words with figures.
            int counter = 0;

            for (var i = 0; i < allWordsOfText.Length; i++)
            {
                if (numDigOfwords[i] > 0)
                {
                    counter++;
                }
            }

            // We allocate memory under a array of words with figures.
            numbersIntoWords = new string[counter];

            counter = 0;

            if (numbersIntoWords.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nWords with numbers:");
                Console.ForegroundColor = ConsoleColor.Gray;

                for (var i = 0; i < allWordsOfText.Length; i++)
                {
                    // If in a word there are figures it is given this word to a array.
                    if (numDigOfwords[i] > 0)
                    {
                        numbersIntoWords[counter] = allWordsOfText[i];

                        Console.Write(numbersIntoWords[counter] + ", ");

                        counter++;
                    }
                }

                StringBuilder[] wordsWithNumbersNew = new StringBuilder[numbersIntoWords.Length];

                for (var i = 0; i < wordsWithNumbersNew.Length; i++)
                {
                    wordsWithNumbersNew[i] = new StringBuilder(numbersIntoWords[i]);
                }

                for (var i = 0; i < wordsWithNumbersNew.Length; i++)
                {
                    for (var j = 0; j < wordsWithNumbersNew[i].Length; j++)
                    {
                        if (char.IsDigit(wordsWithNumbersNew[i][j]))
                        {
                            switch (wordsWithNumbersNew[i][j])
                            {
                                case '0':
                                    wordsWithNumbersNew[i].Replace(wordsWithNumbersNew[i][j].ToString(), "zero");
                                    break;
                                case '1':
                                    wordsWithNumbersNew[i].Replace(wordsWithNumbersNew[i][j].ToString(), "one");
                                    break;
                                case '2':
                                    wordsWithNumbersNew[i].Replace(wordsWithNumbersNew[i][j].ToString(), "two");
                                    break;
                                case '3':
                                    wordsWithNumbersNew[i].Replace(wordsWithNumbersNew[i][j].ToString(), "three");
                                    break;
                                case '4':
                                    wordsWithNumbersNew[i].Replace(wordsWithNumbersNew[i][j].ToString(), "four");
                                    break;
                                case '5':
                                    wordsWithNumbersNew[i].Replace(wordsWithNumbersNew[i][j].ToString(), "five");
                                    break;
                                case '6':
                                    wordsWithNumbersNew[i].Replace(wordsWithNumbersNew[i][j].ToString(), "six");
                                    break;
                                case '7':
                                    wordsWithNumbersNew[i].Replace(wordsWithNumbersNew[i][j].ToString(), "seven");
                                    break;
                                case '8':
                                    wordsWithNumbersNew[i].Replace(wordsWithNumbersNew[i][j].ToString(), "eight");
                                    break;
                                case '9':
                                    wordsWithNumbersNew[i].Replace(wordsWithNumbersNew[i][j].ToString(), "nine");
                                    break;
                            }
                            continue;
                        }
                    }
                }

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nWords in which numbers are replaced:");
                Console.ForegroundColor = ConsoleColor.Gray;

                for (var i = 0; i < wordsWithNumbersNew.Length; i++)
                {
                    Console.Write(wordsWithNumbersNew[i] + ", ");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("In the text there is no number!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        #endregion

        /// <summary>
        /// Find all sentences.
        /// </summary>
        #region Sentences
        static void Sentences()
        {
            int index = 1;

            // We count sentences in the text.
            for (var i = 0; i < allText.Length; i++)
            {
                var condition = allText[i] == '.' || allText[i] == '!' || allText[i] == '?';

                if (condition)
                {
                    index++;
                }
            }

            // We allocate memory under a file of sentences.
            sentences = new string[index - 1];

            // We fill a file of sentences.
            var count = 0;

            for (var i = 0; i < sentences.Length; i++)
            {
                for (var j = count; j < allText.Length; j++)
                {
                    count++;

                    var condition = allText[j] == '.' || allText[j] == '!' || allText[j] == '?';

                    if (condition)
                    {
                        count++;
                        sentences[i] += allText[j];
                        break;
                    }

                    sentences[i] += allText[j];
                }
            }

            // Output of all sentens.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nAll sentens:");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine();

            for (var i = 0; i < sentences.Length; i++)
            {
                Console.WriteLine(sentences[i]);
            }
        }
        #endregion

        /// <summary>
        /// Output all over again interrogative and then exclamatory sentences of the text.
        /// </summary>
        #region OutInterAndExcl
        static void OutInterAndExcl()
        {
            var count = 0;

            Sentences();

            for (var i = 0; i < sentences.Length; i++)
            {
                if (sentences[i].EndsWith("?"))
                {
                    count++;
                }
            }

            string[] interrogative = new string[count];

            if (interrogative.Length > 0)
            {
                count = 0;

                for (var i = 0; i < sentences.Length; i++)
                {
                    if (sentences[i].EndsWith("?"))
                    {
                        interrogative[count] = sentences[i];

                        count++;
                    }
                }

                // Output of questions.
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nQuestions:");
                Console.ForegroundColor = ConsoleColor.Gray;

                for (var i = 0; i < interrogative.Length; i++)
                {
                    Console.WriteLine(interrogative[i]);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nIn the text there is no question!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            count = 0;

            for (var i = 0; i < sentences.Length; i++)
            {
                if (sentences[i].EndsWith("!"))
                {
                    count++;
                }
            }

            string[] exclamatory = new string[count];

            if (exclamatory.Length > 0)
            {
                count = 0;

                for (var i = 0; i < sentences.Length; i++)
                {
                    if (sentences[i].EndsWith("!"))
                    {
                        exclamatory[count] = sentences[i];

                        count++;
                    }
                }

                // Output of exclamatory sentences.
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nExclamatory sentences:");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine();

                for (var i = 0; i < exclamatory.Length; i++)
                {
                    Console.WriteLine(exclamatory[i]);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nIn the text there is no exclamatory sentence!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        #endregion

        /// <summary>
        /// Search of sentences without commas.
        /// </summary>
        #region NonComSent
        static void NonComSent()
        {
            var count = 0;

            // Output of all offers of the text.
            Sentences();

            // Search in each sentence of commas.
            for (var i = 0; i < sentences.Length; i++)
            {
                for (var j = 0; j < sentences[i].Length; j++)
                {
                    var condition = sentences[i][j] == ',';

                    if (condition)
                    {
                        count++;
                        break;
                    }
                }
            }

            // Allocation of memory only on sentences where there are no commas.
            nonComSent = new string[sentences.Length - count];

            // If sentences without commas are, else a output of an information inscription.
            // Record of sentences without commas in a array.
            if (nonComSent.Length > 0)
            {
                count = 0;

                for (var i = 0; i < sentences.Length; i++)
                {
                    var condition = sentences[i].IndexOf(',') > 0;

                    if (condition)
                    {
                        continue;
                    }
                    else
                    {
                        nonComSent[count] = sentences[i];

                        count++;
                    }
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nSentences without commas:");
                Console.ForegroundColor = ConsoleColor.Gray;

                for (var i = 0; i < nonComSent.Length; i++)
                {
                    Console.WriteLine(nonComSent[i]);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nIn the text there is no sentence without commas!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        #endregion

        /// <summary>
        /// Display all words.
        /// </summary>
        #region OutAllWords
        static void OutAllWords()
        {
            WordSplitting();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nOutput of all words:");
            Console.ForegroundColor = ConsoleColor.Gray;

            for (var i = 0; i < allWordsOfText.Length; i++)
            {
                Console.Write(allWordsOfText[i] + " ");
            }

            Console.WriteLine();
        }
        #endregion

        /// <summary>
        /// Search of words with identical letters in the beginning and in the end.
        /// </summary>
        #region FindWordsWithIndLet
        static void FindWordsWithIndLet()
        {
            WordSplitting();

            var count = 0;

            // We search how many for all of words begin and come to an end on one letter.
            for (var i = 0; i < allWordsOfText.Length; i++)
            {
                string start = allWordsOfText[i][0].ToString();

                string end = allWordsOfText[i][allWordsOfText[i].Length - 1].ToString();

                var condition = string.Compare(start.ToLower(), end.ToLower()) == 0;

                if (condition)
                {
                    count++;
                }
            }

            wordOnSammeLet = new string[count];

            if (wordOnSammeLet.Length > 0)
            {
                count = 0;

                for (var i = 0; i < allWordsOfText.Length; i++)
                {
                    string start = allWordsOfText[i][0].ToString();

                    string end = allWordsOfText[i][allWordsOfText[i].Length - 1].ToString();

                    var condition = string.Compare(start.ToLower(), end.ToLower()) == 0;

                    if (condition)
                    {
                        wordOnSammeLet[count] = allWordsOfText[i];

                        count++;
                    }
                }

                for (var i = 0; i < wordOnSammeLet.Length; i++)
                {
                    wordOnSammeLet[i] = wordOnSammeLet[i].ToLower();
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nOutput of the words which are beginning and coming to an \nend on same letter and amounts of their recurrences:");
                Console.ForegroundColor = ConsoleColor.Gray;

                int[] countRec = new int[wordOnSammeLet.Length];

                for (var i = 0; i < countRec.Length; i++)
                {
                    countRec[i] = 1;
                }

                for (var i = 0; i < wordOnSammeLet.Length; i++)
                {
                    for (var j = i + 1; j < wordOnSammeLet.Length; j++)
                    {
                        if (wordOnSammeLet[i].ToLower() == wordOnSammeLet[j].ToLower())
                        {
                            countRec[i]++;
                        }
                    }
                }

                count = 0;

                for (var i = 0; i < countRec.Length; i++)
                {
                    if (countRec[i] > 1)
                    {
                        count++;
                    }
                }

                for (var i = 0; i < wordOnSammeLet.Length; i++)
                {
                    for (var j = i + 1; j < wordOnSammeLet.Length; j++)
                    {
                        if (wordOnSammeLet[i].ToLower() == wordOnSammeLet[j].ToLower())
                        {
                            wordOnSammeLet[j] = "";
                        }
                    }
                }

                string[] wordOnSammeLetNew = new string[wordOnSammeLet.Length - count];

                int[] countRecNew = new int[wordOnSammeLet.Length - count];

                for (var i = 0; i < countRecNew.Length; i++)
                {
                    countRecNew[i] = 1;
                }

                count = 0;

                for (var i = 0; i < wordOnSammeLet.Length; i++)
                {
                    for (var j = i; j < wordOnSammeLet.Length; j++)
                    {
                        if (wordOnSammeLet[i] == "")
                        {
                            continue;
                        }
                        if (wordOnSammeLet[i].ToLower() == wordOnSammeLet[j].ToLower())
                        {
                            countRecNew[count] = countRec[i];

                            wordOnSammeLetNew[count] = wordOnSammeLet[i];

                            count++;

                            break;
                        }
                    }

                    if (count == wordOnSammeLetNew.Length)
                    {
                        break;
                    }
                }


                for (var i = 0; i < wordOnSammeLetNew.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(wordOnSammeLetNew[i]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" - there is ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(countRecNew[i]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(" time");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nIn the text there is no word which begins and comes to an end on the same letter!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        #endregion

        #region OutAllTextAndWordSplitting
        static void OutAllTextAndWordSplitting()
        {
            OutAllText();

            WordSplitting();
        }
        #endregion

        /// <summary>
        /// Displaying information about the program.
        /// </summary>
        #region AboutProgram
        static void AboutProgram()
        {
            Console.WriteLine("A program for processing strings. Version 1.0");
            Console.WriteLine();
            Console.WriteLine("Allows you to perform the following operations:");
            Console.WriteLine("- read line from file;");
            Console.WriteLine("- search for words containing the maximum number of digits;");
            Console.WriteLine("- search for the longest word in the string and the number of times it is repeated;");
            Console.WriteLine("- replace numbers with their uppercase counterparts;");
            Console.WriteLine("- display first interrogative and then exclamation sentences of the text;");
            Console.WriteLine("- display only sentences that do not contain commas;");
            Console.WriteLine("- search for words starting and ending with the same letter and their number in the text.");
            Console.WriteLine();
            Console.WriteLine("Developer - Yarmalkevich V.I.");

            Console.WriteLine();
        }
        #endregion

        #region Case 1
        static void Case1()
        {
            ReadFromFile();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("This file contains the following text:");
            Console.ForegroundColor = ConsoleColor.Gray;

            OutAllText();

            Console.ReadKey();
        }
        #endregion

        #region Case 2
        static void Case2()
        {
            Console.Clear();

            OutAllTextAndWordSplitting();

            MaxNumOfDig();

            Console.ReadKey();
        }
        #endregion

        #region Case 3
        static void Case3()
        {
            Console.Clear();

            OutAllTextAndWordSplitting();

            MaxWordOfText();

            Console.ReadKey();
        }
        #endregion

        #region Case 4
        static void Case4()
        {
            Console.Clear();

            OutAllTextAndWordSplitting();

            RepNumWord();

            Console.ReadKey();
        }
        #endregion

        #region Case 5
        static void Case5()
        {
            Console.Clear();

            OutAllText();

            OutInterAndExcl();

            Console.ReadKey();
        }
        #endregion

        #region Case 6
        static void Case6()
        {
            Console.Clear();

            OutAllText();

            NonComSent();

            Console.ReadKey();
        }
        #endregion

        #region Case 7
        static void Case7()
        {
            Console.Clear();

            OutAllText();

            OutAllWords();

            FindWordsWithIndLet();

            Console.ReadKey();
        }
        #endregion

        #region Case 8
        static void Case8()
        {
            Console.Clear();

            AboutProgram();

            Console.ReadKey();
        }
        #endregion
    }
}
