namespace CommonLogic
{
    public static class Utils
    {
        private static readonly Random random = new Random();

        public static int[] GenerateArray(int numberOfElements)
        {
            int[] array = new int[numberOfElements];

            for(int i = 0; i < numberOfElements; i++)
            {
                array[i] = random.Next(int.MinValue, int.MaxValue);
            }

            return array;
        }

        public static void PrintTable<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        public static double CalculateMedian<T>(T[] array) where T : struct
        {
            int size = array.Length;
            int mid = size / 2;
            double median = 0;

            if (size % 2 != 0)
            {
                median = Convert.ToDouble(array[mid]);
            }
            else
            {
                median = (Convert.ToDouble(array[mid]) + Convert.ToDouble(array[mid - 1])) / 2;
            }

            return median;
        }

        public static string PromptForString(string promptMessage,  string errorMessage)
        {
            string input;
            bool isValidInput;

            do
            {
                Console.WriteLine(promptMessage);
                input = Console.ReadLine();
                isValidInput = String.IsNullOrEmpty(input);

                if (isValidInput)
                {
                    Console.WriteLine(errorMessage);
                }
            }
            while (isValidInput);

            return input;

        }

        public static T PromptForNumber<T>(string promptMessage, Func<T, bool> validation, string errorMessage) where T : struct
        {
            T number;
            bool isValidInput;

            do
            {
                Console.WriteLine(promptMessage);
                string input = Console.ReadLine();
                isValidInput = TryParse<T>(input, out number);

                if (!isValidInput || (validation != null && !validation(number)))
                {
                    Console.WriteLine(errorMessage);
                    isValidInput = false;
                }
            }
            while (!isValidInput);

            return number;
        }

        private static bool TryParse<T>(string input, out T value) where T : struct
        {
            value = default;
            try
            {
                value = (T)Convert.ChangeType(input, typeof(T));
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}