using System;
using System.Text;

namespace NumeralSystems
{
    public static class Converter
    {
        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in the octal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the octal numeral systems.</returns>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveOctal(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number is less than zero!");
            }

            return GetRadix(number, 8);
        }

        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in the decimal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the decimal numeral systems.</returns>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveDecimal(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number is less than zero!");
            }

            return GetRadix(number, 10);
        }

        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in the hexadecimal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the hexadecimal numeral systems.</returns>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveHex(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number is less than zero!");
            }

            return GetRadix(number, 16);
        }

        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in a specified radix.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <param name="radix">Base of the numeral systems.</param>
        /// <returns>The equivalent string representation of the number in a specified radix.</returns>
        /// <exception cref="ArgumentException">Thrown if radix is not equal 8, 10 or 16.</exception>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveRadix(this int number, int radix)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number is less than zero!");
            }

            return GetRadix(number, radix);
        }

        /// <summary>
        /// Gets the value of a signed integer to its equivalent string representation in a specified radix.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <param name="radix">Base of the numeral systems.</param>
        /// <returns>The equivalent string representation of the number in a specified radix.</returns>
        /// <exception cref="ArgumentException">Thrown if radix is not equal 8, 10 or 16.</exception>
        public static string GetRadix(this int number, int radix)
        {
            if (!(radix == 8 || radix == 10 || radix == 16))
            {
                throw new ArgumentException($"{nameof(radix)} is 8, 10 and 16 only.");
            }

            switch (radix)
            {
                case 8:
                    {
                        uint undignedNumber = number < 0 ? 0u + (uint)number : (uint)number;
                        long result = 0, count = 1;

                        while (undignedNumber != 0)
                        {
                            result += (undignedNumber % 8) * count;
                            undignedNumber /= 8;
                            count *= 10;
                        }

                        return string.Empty + result;
                    }

                case 10: 
                    return string.Empty + number;
                case 16:
                    {
                        StringBuilder res = new StringBuilder();
                        uint undignedNumber = number < 0 ? 0u + (uint)number : (uint)number;

                        while (undignedNumber != 0)
                        {
                            switch (undignedNumber % 16)
                            {
                                case 0:
                                    res.Insert(0, "0");
                                    break;
                                case 1:
                                    res.Insert(0, "1");
                                    break;
                                case 2:
                                    res.Insert(0, "2");
                                    break;
                                case 3:
                                    res.Insert(0, "3");
                                    break;
                                case 4:
                                    res.Insert(0, "4");
                                    break;
                                case 5:
                                    res.Insert(0, "5");
                                    break;
                                case 6:
                                    res.Insert(0, "6");
                                    break;
                                case 7:
                                    res.Insert(0, "7");
                                    break;
                                case 8:
                                    res.Insert(0, "8");
                                    break;
                                case 9:
                                    res.Insert(0, "9");
                                    break;
                                case 10:
                                    res.Insert(0, "A");
                                    break;
                                case 11:
                                    res.Insert(0, "B");
                                    break;
                                case 12:
                                    res.Insert(0, "C");
                                    break;
                                case 13:
                                    res.Insert(0, "D");
                                    break;
                                case 14:
                                    res.Insert(0, "E");
                                    break;
                                case 15:
                                    res.Insert(0, "F");
                                    break;
                            }

                            undignedNumber /= 16;
                        }

                        return res.ToString();
                    }

                default:
                    return string.Empty;
            }
        }
    }
}
