using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{

    class Program
    {
        static int[] array;
        static int[,] matrix;
        static Random random = new Random();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ShowMenu();
        }

        static void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n========== MENU CHƯƠNG TRÌNH ==========");
                Console.WriteLine("1. Phát sinh mảng ngẫu nhiên");
                Console.WriteLine("2. In mảng");
                Console.WriteLine("3. Tìm kiếm phần tử trong mảng");
                Console.WriteLine("4. In các số nguyên tố trong mảng");
                Console.WriteLine("5. Kiểm tra mảng đã sắp xếp chưa");
                Console.WriteLine("6. Sắp xếp mảng giảm dần");
                Console.WriteLine("7. Phát sinh ma trận ngẫu nhiên");
                Console.WriteLine("8. In ma trận");
                Console.WriteLine("9. Tính tổng một cột của ma trận");
                Console.WriteLine("0. Thoát chương trình");
                Console.WriteLine("========================================");
                Console.Write("Nhập lựa chọn của bạn (0-9): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        GenerateRandomArray();
                        break;
                    case "2":
                        PrintArray();
                        break;
                    case "3":
                        SearchElement();
                        break;
                    case "4":
                        PrintPrimeNumbers();
                        break;
                    case "5":
                        CheckSorted();
                        break;
                    case "6":
                        SortArrayDescending();
                        break;
                    case "7":
                        GenerateRandomMatrix();
                        break;
                    case "8":
                        PrintMatrix();
                        break;
                    case "9":
                        SumColumn();
                        break;
                    case "0":
                        Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình!");
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ! Vui lòng chọn lại.");
                        break;
                }
            }
        }

        // 1. Phát sinh mảng ngẫu nhiên
        static void GenerateRandomArray()
        {
            Console.Write("Nhập số lượng phần tử N: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                array = new int[n];
                for (int i = 0; i < n; i++)
                {
                    array[i] = random.Next(1, 101); // Số ngẫu nhiên từ 1 đến 100
                }
                Console.WriteLine($"Đã tạo mảng với {n} phần tử ngẫu nhiên.");
            }
            else
            {
                Console.WriteLine("Vui lòng nhập một số nguyên dương hợp lệ!");
            }
        }

        // 2. In mảng
        static void PrintArray()
        {
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("Mảng chưa được khởi tạo! Vui lòng chọn chức năng 1 trước.");
                return;
            }

            Console.WriteLine("Các phần tử trong mảng:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}\t");
                if ((i + 1) % 10 == 0) Console.WriteLine(); // Xuống dòng mỗi 10 phần tử
            }
            Console.WriteLine();
        }

        // 3. Tìm kiếm phần tử
        static void SearchElement()
        {
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("Mảng chưa được khởi tạo! Vui lòng chọn chức năng 1 trước.");
                return;
            }

            Console.Write("Nhập số X cần tìm: ");
            if (int.TryParse(Console.ReadLine(), out int x))
            {
                int lastPosition = FindLastOccurrence(x);
                if (lastPosition != -1)
                {
                    Console.WriteLine($"Số {x} xuất hiện cuối cùng tại vị trí: {lastPosition}");
                }
                else
                {
                    Console.WriteLine($"Số {x} không tồn tại trong mảng.");
                }
            }
            else
            {
                Console.WriteLine("Vui lòng nhập một số nguyên hợp lệ!");
            }
        }

        static int FindLastOccurrence(int x)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] == x)
                {
                    return i;
                }
            }
            return -1;
        }

        // 4. In các số nguyên tố
        static void PrintPrimeNumbers()
        {
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("Mảng chưa được khởi tạo! Vui lòng chọn chức năng 1 trước.");
                return;
            }

            Console.WriteLine("Các số nguyên tố trong mảng:");
            bool hasPrime = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (IsPrime(array[i]))
                {
                    Console.Write($"{array[i]}\t");
                    hasPrime = true;
                }
            }
            if (!hasPrime)
            {
                Console.Write("Không có số nguyên tố nào trong mảng.");
            }
            Console.WriteLine();
        }

        static bool IsPrime(int n)
        {
            if (n < 2) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            for (int i = 3; i * i <= n; i += 2)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        // 5. Kiểm tra mảng đã sắp xếp
        static void CheckSorted()
        {
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("Mảng chưa được khởi tạo! Vui lòng chọn chức năng 1 trước.");
                return;
            }

            bool result = IsSorted();
            Console.WriteLine($"Mảng đã được sắp xếp: {result}");
        }

        static bool IsSorted()
        {
            if (array.Length <= 1) return true;

            // Kiểm tra sắp xếp tăng dần
            bool ascending = true;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[i - 1])
                {
                    ascending = false;
                    break;
                }
            }

            // Kiểm tra sắp xếp giảm dần
            bool descending = true;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[i - 1])
                {
                    descending = false;
                    break;
                }
            }
            return ascending || descending;
        }

        // 6. Sắp xếp mảng giảm dần (Bubble Sort)
        static void SortArrayDescending()
        {
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("Mảng chưa được khởi tạo! Vui lòng chọn chức năng 1 trước.");
                return;
            }

            // Bubble Sort giảm dần
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        // Hoán đổi
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("Đã sắp xếp mảng theo thứ tự giảm dần.");
        }

        // 7. Phát sinh ma trận ngẫu nhiên
        static void GenerateRandomMatrix()
        {
            Console.Write("Nhập số hàng N: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Vui lòng nhập một số nguyên dương hợp lệ!");
                return;
            }

            Console.Write("Nhập số cột M: ");
            if (!int.TryParse(Console.ReadLine(), out int m) || m <= 0)
            {
                Console.WriteLine("Vui lòng nhập một số nguyên dương hợp lệ!");
                return;
            }

            matrix = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = random.Next(1, 101); // Số ngẫu nhiên từ 1 đến 100
                }
            }
            Console.WriteLine($"Đã tạo ma trận {n}x{m} với các phần tử ngẫu nhiên.");
        }

        // 8. In ma trận
        static void PrintMatrix()
        {
            if (matrix == null)
            {
                Console.WriteLine("Ma trận chưa được khởi tạo! Vui lòng chọn chức năng 7 trước.");
                return;
            }

            Console.WriteLine("Ma trận:");
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j],4}");
                }
                Console.WriteLine();
            }
        }

        // 9. Tính tổng một cột
        static void SumColumn()
        {
            if (matrix == null)
            {
                Console.WriteLine("Ma trận chưa được khởi tạo! Vui lòng chọn chức năng 7 trước.");
                return;
            }

            int cols = matrix.GetLength(1);
            Console.Write($"Nhập số cột cần tính tổng (0-{cols - 1}): ");

            if (int.TryParse(Console.ReadLine(), out int col) && col >= 0 && col < cols)
            {
                int sum = 0;
                int rows = matrix.GetLength(0);

                for (int i = 0; i < rows; i++)
                {
                    sum += matrix[i, col];
                }

                Console.WriteLine($"Tổng các phần tử ở cột {col}: {sum}");
            }
            else
            {
                Console.WriteLine($"Vui lòng nhập số cột hợp lệ từ 0 đến {cols - 1}!");
            }
        }
    }
}



