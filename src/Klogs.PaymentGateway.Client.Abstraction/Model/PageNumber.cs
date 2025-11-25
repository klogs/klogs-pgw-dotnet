using System.Collections.Generic;

namespace Klogs.PaymentGateway.Client.Abstraction.Model
{
    /// <summary>
    /// source: https://github.com/DataTables/Plugins/blob/master/pagination/full_numbers_no_ellipses.js
    /// </summary>
    static class PageNumber
    {
        const int BUTTONS = 5;
        const int MAX_OEPN_BUTTONS = 10;
        const int FIRST_PAGE = 1;
        const int CORNER_LENGTH = 4;
        const int LEFT_RIGHT_LENGTH = 2;

        static List<int?> Range(int start, int length)
        {
            var numbers = new List<int?>();

            for (var i = 0; i < length; i++)
            {
                numbers.Add(start + i);
            }

            return numbers;
        }

        public static int?[] Numbers(int currentPage, int pageCount)
        {
            List<int?> numbers = new List<int?>();

            //Sayfa sayısı maximum buton sayısından küçükse
            if (pageCount <= MAX_OEPN_BUTTONS)
            {
                numbers = Range(1, pageCount);
            }
            else if (currentPage - CORNER_LENGTH < FIRST_PAGE)
            {
                numbers = Range(1, BUTTONS);

                if (currentPage + CORNER_LENGTH == pageCount)
                {
                    numbers.Add(currentPage + 3);
                    numbers.Add(currentPage + 4);
                }
                else if (currentPage + CORNER_LENGTH < pageCount)
                {
                    numbers.Add(null);
                    numbers.Add(pageCount);
                }
            }
            else if (currentPage - CORNER_LENGTH == FIRST_PAGE)
            {
                numbers = Range(1, BUTTONS);

                if (currentPage + CORNER_LENGTH == pageCount)
                {
                    numbers.Add(currentPage + 3);
                    numbers.Add(currentPage + 4);
                }
                else if (currentPage + CORNER_LENGTH < pageCount)
                {
                    numbers.Add(null);
                    numbers.Add(pageCount);
                }
            }
            else if (currentPage - CORNER_LENGTH > 1)
            {
                numbers.Add(1);
                numbers.Add(null);

                var x = BUTTONS - (currentPage + LEFT_RIGHT_LENGTH - pageCount);

                if (x == 7)
                {
                    numbers.AddRange(
                        Range(currentPage - LEFT_RIGHT_LENGTH, BUTTONS - (currentPage + LEFT_RIGHT_LENGTH - pageCount))
                    );
                }
                else if (x > 7)
                {
                    numbers.AddRange(
                        Range(currentPage - LEFT_RIGHT_LENGTH, BUTTONS)
                    );

                    numbers.Add(null);
                    numbers.Add(pageCount);
                }
                else
                {
                    numbers.AddRange(
                        Range(pageCount - 6, BUTTONS)
                    );

                    numbers.Add(pageCount - 1);
                    numbers.Add(pageCount);
                }
            }

            return numbers.ToArray();
        }
    }
}
