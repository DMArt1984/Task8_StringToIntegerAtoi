using System;

namespace Task8_StringToIntegerAtoi
{
    class Program
    {
        // https://leetcode.com/problems/string-to-integer-atoi/
        static void Main(string[] args)
        {
            Console.WriteLine("Task 8 - String to Integer (atoi)");
            Console.WriteLine($"42 = {MyAtoi("42")}");
            Console.WriteLine($"   -42 = {MyAtoi("   -42")}");
            Console.WriteLine($"4193 with words = {MyAtoi("4193 with words")}");
            Console.WriteLine($"words and 987 = {MyAtoi("words and 987")}");
            Console.WriteLine($"-91283472332 = {MyAtoi("-91283472332")}");
            Console.WriteLine($"  -0012a42 = {MyAtoi("  -0012a42")}");
            Console.WriteLine($"-5- = {MyAtoi("-5-")}");
            Console.WriteLine($"123- = {MyAtoi("123-")}");
            Console.WriteLine($"    -88827   5655  U = {MyAtoi("    -88827   5655  U")}");
            Console.WriteLine($"1234567890123456789012345678901234567890 = {MyAtoi("1234567890123456789012345678901234567890")}");
            Console.WriteLine($"  0000000000012345678 = {MyAtoi("  0000000000012345678")}");
            Console.WriteLine($"00000-42a1234 = {MyAtoi("00000-42a1234")}");
            Console.WriteLine($"0  123 = {MyAtoi("0  123")}");
            Console.ReadKey();
        }

        // Implement the myAtoi(string s) function, which converts a string to a 32-bit signed integer(similar to C/C++'s atoi function).
        // The algorithm for myAtoi(string s) is as follows:
        // Read in and ignore any leading whitespace.
        // Check if the next character (if not already at the end of the string) is '-' or '+'. Read this character in if it is either.This determines if the final result is negative or positive respectively. Assume the result is positive if neither is present.
        // Read in next the characters until the next non-digit character or the end of the input is reached.The rest of the string is ignored.
        // Convert these digits into an integer (i.e. "123" -> 123, "0032" -> 32). If no digits were read, then the integer is 0. Change the sign as necessary (from step 2).
        // If the integer is out of the 32-bit signed integer range[-231, 231 - 1], then clamp the integer so that it remains in the range.Specifically, integers less than -231 should be clamped to -231, and integers greater than 231 - 1 should be clamped to 231 - 1.
        // Return the integer as the final result.

        // Example 1:
        // Input: s = "42"
        // Output: 42
        // Explanation: The underlined characters are what is read in, the caret is the current reader position.
        // Step 1: "42" (no characters read because there is no leading whitespace)
        // Step 2: "42" (no characters read because there is neither a '-' nor '+')
        // Step 3: "42" ("42" is read in)
        // The parsed integer is 42.
        // Since 42 is in the range[-231, 231 - 1], the final result is 42.

        // Example 2:
        // Input: s = "   -42"
        // Output: -42
        // Explanation:
        // Step 1: "   -42" (leading whitespace is read and ignored)
        // Step 2: "   -42" ('-' is read, so the result should be negative)
        // Step 3: "   -42" ("42" is read in)
        // The parsed integer is -42.
        // Since -42 is in the range[-231, 231 - 1], the final result is -42.

        // Example 3:
        // Input: s = "4193 with words"
        // Output: 4193
        // Explanation:
        // Step 1: "4193 with words" (no characters read because there is no leading whitespace)
        // Step 2: "4193 with words" (no characters read because there is neither a '-' nor '+')
        // Step 3: "4193 with words" ("4193" is read in; reading stops because the next character is a non-digit)
        // The parsed integer is 4193.
        // Since 4193 is in the range[-231, 231 - 1], the final result is 4193.

        static public int MyAtoi(string s)
        {
            string s2 = "";
            bool exit = false;
            bool num = false;
            bool dec = false;
            bool zero = false;
            for (var i=0; i< s.Length; i++)
            {
                switch(s[i])
                {
                    case '+':
                    case '-':
                        if (s2.Contains('+') || s2.Contains('-') || num || zero)
                        {
                            exit = true;
                        }
                        else
                        {
                            s2 += s[i];
                        }
                        break;

                    case ' ':
                        if (num || zero)
                        {
                            exit = true;
                            break;
                        }
                        //s2 += s[i];
                        break;
                    case '0':
                        zero = true;
                        if (dec)
                            s2 += s[i];
                        break;
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        dec = true;
                        num = true;
                        s2 += s[i];
                        break;
                    default:
                        exit = true;
                        break;
                }
                if (exit)
                    break;
            }

            //s2 = s2.TrimStart();

            if (s2.Length > 12)
            {
                if (s2[0] == '-')
                    return int.MinValue;
                return int.MaxValue;
            }
                
            var OK = decimal.TryParse(s2, out decimal retvalItem);
            if (OK)
            {
                if (retvalItem > int.MaxValue)
                    return int.MaxValue;

                if (retvalItem < int.MinValue)
                    return int.MinValue;

                return Convert.ToInt32(retvalItem);
            }

            return 0;
        }

    }
}
