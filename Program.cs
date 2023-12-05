using System;

class Program
{
	static void Main()
	{
		Console.WriteLine("Enter your numbers separated by commas(,):");
		string input = Console.ReadLine();

		// we will use commas to Split the input string into an array 
		string[] numbers_In_String = input.Split(',');
		int[] numbers = Array.ConvertAll(numbers_In_String, int.Parse);

		// here we Call the sortAndFindMedian function
		double median = sortAndFindMedian(numbers);

		// Show the result to the user
		Console.WriteLine($"Median: {median:F1}"); //give us the median in one decimal place
	}

	static double sortAndFindMedian(int[] numbers)
	{
		// Call the function to iterate thru the array
		sort(numbers);

		int n = numbers.Length; //counts and validates the number of items in the list

		if (n % 2 == 0)
		{
			// If the array has an even number of elements(IF n MOD 2 = 0), return the average of the middle two
			return (double)(numbers[n / 2 - 1] + numbers[n / 2]) / 2;
		}
		else
		{
			// If the array has an odd number of elements, return the middle element
			return numbers[n / 2];
		}
	}

	static void sort(int[] numbers)
	{
		// Use the QuickSort algorithm for sorting
		quickSort(numbers, 0, numbers.Length - 1);
	}

	static void quickSort(int[] numbers, int lowest_index, int highest_index)
	{
		if (lowest_index < highest_index)
		{
			int partitionIndex = partition_level(numbers, lowest_index, highest_index);

			// Recursively sort elements before and after the partition index
			quickSort(numbers, lowest_index, partitionIndex - 1);
			quickSort(numbers, partitionIndex + 1, highest_index);
		}
	}

	static int partition_level(int[] numbers, int lowest_index, int highest_index)
	{
		int pivot = numbers[highest_index]; //the index of the last number in the list will be chose as the pivot
		int i = lowest_index - 1;

		for (int j = lowest_index; j < highest_index; j++)
		{
			if (numbers[j] < pivot)
			{
				i++;
				// Swap numbers[i] and numbers[j] index positions to help partition array around the pivot
				int temp = numbers[i];
				numbers[i] = numbers[j];
				numbers[j] = temp;
			}
		}

		// Swap numbers[i+1] and pivot
		int tempPivot = numbers[i + 1];
		numbers[i + 1] = numbers[highest_index];
		numbers[highest_index] = tempPivot;

		return i + 1;
	}
}
