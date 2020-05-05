using System;
using System.IO;
namespace hello
{
    class Program
    {
        static void Main(string[] args)
        {
            if (RleToText("01£") == "£")
            {
                Console.WriteLine("Test 1 Passed");

            }
            else Console.WriteLine("Test 1 Failed");
            if (RleToText("00T") == "")
            {
                Console.WriteLine("Test 2 Passed");
            }
            else Console.WriteLine("Test 2 Failed");

            if (RleToText("03Y01e04R") == "YYYeRRRR")
            {
                Console.WriteLine("Test 3 Passed");
            }
            else Console.WriteLine("Test 3 Failed");

            // Harder Test
            if (RleToText("03Y06E89U") == "")
            {
                Console.WriteLine("Test 4 Failed");
            }
            else Console.WriteLine("Test 4 Passed");

            // Tests for TextToRLE
            if (TextToRle("ttt") == "03t")
            {
                Console.WriteLine("Test 5 Passed");
            }
            else Console.WriteLine("Test 5 Failed");

            if (TextToRle("tttvuuuu") == "03t01v04u")
            {
                Console.WriteLine("Test 6 Passed");
            }
            else Console.WriteLine("Test 6 Failed");

            if (TextToRle("tttuuuuuuuuuuu") == "03t11u")
            {
                Console.WriteLine("Test 7 Passed");
            }
            else Console.WriteLine("Test 7 Failed");


            // Test 8 - you should see an ASCII Art Image !!!
            printUnCompressedRLE();
        }


        // This function should take a string in RLE and return an uncompressed string
        // so 01T05a would return Taaaaa
        // If the string passed is not in valid rle format ie <digit><digit><any character>
        // and empty string should be returned 
        // e.g. 15E7j should return "" as the run length for j is only represented by one digit
        static string RleToText(string s)
        {
            string text = "";
             int digits;
            string factor;
            for (int x = 0; x < s.Length; x = x + 3)
            {
                digits = Int32.Parse(s.Substring(x, 2));
                factor = "" + s[x + 2];
                for (int z = 0; z < digits; z++)
                {
                    text = text + factor;
                }
            }

            return text;
        }


        // This function should take a string of text and convert it to RLE
        // 2 digits should be used for the run length and one digit for the character
        // so RRRt   would be converted to 03R01t
        static string TextToRle(string s)
        {
            
            int count = 1;
            
            string temp = "";
            string rle = "";
            for(int x = 0; x < s.Length - 1; x = x + (count))
            {
                count = 1;
                for(int z = x; z < s.Length - 1; z++)
                {
                    if (s[z] == s[z + 1])
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                    
                }


                temp = Convert.ToString(count);
                if (count < 10)
                    {
                        temp = "0" + temp;
                    }
                    

                rle = rle + (temp + s[x]);
                    
                
                 
                      
                
            }


            return rle;
        }


        // This subroutine should open the LogoRLE.txt file 
        // Read the file one line at a time
        // Uncompress the line read from the file and print it out
        // this should happen until the end of the file is reached
        static void printUnCompressedRLE()
        {
            StreamReader sr = new StreamReader("C:/Users/AFS/LogoRLE.txt");

            try
            {
                
                while(sr.Peek() != -1)
                {
                    Console.WriteLine(RleToText(sr.ReadLine()));
                }
                sr.Close();


            }
            catch
            {
                Console.WriteLine("File IO Error");
            }


        }
    }
}
