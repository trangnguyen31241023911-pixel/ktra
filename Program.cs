using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rút_gọn
{
    internal class Program
    {
        static int[] mang;
        static int[,] matran;
        static Random r = new Random();
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Menu();
        }
        //10. Tao menu
        static void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n=====MENU=====");
                Console.WriteLine("1. Phat sinh mang");
                Console.WriteLine("2. In mang");
                Console.WriteLine("3. Tim so");
                Console.WriteLine("4. In so nguyen to");
                Console.WriteLine("5. Kiem tra sap xep mang");
                Console.WriteLine("6. Sap xep mang giam dan");
                Console.WriteLine("7. Phat sinh ma tran");
                Console.WriteLine("8. In ma tran");
                Console.WriteLine("9. Tinh tong 1 cot");
                Console.WriteLine("0. Thoat chuong trinh");
                Console.WriteLine("Chon [0-9]: ");

                int chon = int.Parse(Console.ReadLine());

                switch(chon)
                {
                    case 1: Taomang(); break;
                    case 2: Inmang(); break;
                    case 3: Timso(); break;
                    case 4: Innguyento(); break;
                    case 5: Kiemtrasapxep(); break;
                    case 6: Sapxepgiam(); break;
                    case 7: Taomatran(); break;
                    case 8: Inmatran(); break;
                    case 9: Tongcot(); break;
                    case 0: Console.WriteLine("Cam on da dung chuong trinh"); return;
                    default: Console.WriteLine("Nhap so hop le"); break;
                }
            }
        }
        //1. Tao mang
        static void Taomang()
        {
            Console.WriteLine("Nhap so phan tu N: ");
            int phantu = int.Parse(Console.ReadLine());
            mang = new int[phantu];
            for(int i = 0; i < phantu; i++)
            {
                mang[i] = r.Next(1, 101);
            }
        }
        //2. In mang
        static void Inmang()
        {
            if(mang == null)
            {
                Console.WriteLine("Chua tao mang, chon 1 de tao mang");
                return; //Thoat khoi ngay lap tuc
            }
            foreach(int x in mang)
            {
                Console.Write(x +"\t");
            }
        }
        //3. Tim so
        static int Coso(int X)
        {
            for(int i = 0;i < mang.Length;i++)
            {
                if (mang[i] == X)
                {
                    return i;
                }
            }
            return -1;
        }
        static void Timso()
        {
            Console.WriteLine("Nhap so X can tim: ");
            int X = int.Parse(Console.ReadLine());
            int kq = Coso(X);
            if(kq != -1)
            {
                Console.WriteLine($"Tim thay so {X} o vi tri {kq}");
            }
            if(kq == -1)
            { 
                Console.WriteLine($"Khong tim thay so {X} trong mang"); 
            }
        }
        //4. In so nguyen to
        static bool Languyento(int x)
        {
            if(x < 2) return false;
            for(int i = 2; i <= Math.Sqrt(x); i++)
            {
                if(x % i == 0) return false;
            }
            return true;
        }
        static void Innguyento()
        {
            if (mang == null)
            {
                Console.WriteLine("Chua tao mang, chon 1 de tao mang");
                return; //Thoat khoi ngay lap tuc
            }
            foreach(int x in mang)
            {
                if(Languyento(x))
                {
                    Console.Write($"{x} la so nguyen to\t");
                }
                if (!Languyento(x))
                {
                    Console.WriteLine("Khong co so nguyen to trong mang");
                }
            }
        }
        //5. Kiem tra sap xep mang
        static bool Kt()
        {
            if (mang == null || mang.Length < 2) return true;

            bool tang = true;
            bool giam = true;

            // kiểm tra tăng
            for (int i = 0; i < mang.Length - 1; i++)
            {
                if (mang[i] > mang[i + 1])
                {
                    tang = false;
                    break;
                }
            }

            // kiểm tra giảm
            for (int i = 0; i < mang.Length - 1; i++)
            {
                if (mang[i] < mang[i + 1])
                {
                    giam = false;
                    break;
                }
            }

            return tang || giam;
        }

        static void Kiemtrasapxep()
        {
            if (mang == null || mang.Length < 2)
            {
                Console.WriteLine("Mang chua du phan tu de kiem tra.");
                return;
            }

            bool kqkt = Kt();
            Console.WriteLine(kqkt ? "Mang da sap xep" : "Mang chua sap xep");
        }
        //6. Sap xep giam
        static void Sapxepgiam()
        {
            for (int i = 0; i < mang.Length - 1; ++i)
            {
                for(int j = 0; j < mang.Length - i - 1; ++j)
                {
                    if (mang[j] < mang[j + 1])
                    {
                        int tam = mang[j];
                        mang[j] = mang[j + 1];
                        mang[j + 1] = tam;
                    }
                }
                Console.WriteLine();
            }
            foreach(int s in mang)
            {
                Console.Write(s + "\t");
            }
        }
        //7. Tao ma tran
        static void Taomatran()
        {
            Console.WriteLine("Nhap so dong: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap so cot: ");
            int m = int.Parse(Console.ReadLine());
            matran = new int[n,m];

            int dong = matran.GetLength(0);
            int cot = matran.GetLength(1);
            for (int i = 0; i < dong; i++)
            {
                for ( int j = 0;j < cot; j++)
                matran[i,j] = r.Next(1, 101);
            }
            Console.WriteLine();
        }
        //8. In ma tran
        static void Inmatran()
        {
            for(int i = 0;i < matran.GetLength(0);i++)
            {
                for (int j = 0;  j < matran.GetLength(1);j++)
                {
                    Console.Write($"{matran[i,j]}\t");
                }
                Console.WriteLine();
            }
        }
        //9. Tinh tonh 1 cot
        static void Tongcot()
        {
            Console.WriteLine("Nhap vao chi so cot: ");
            int c = int.Parse(Console.ReadLine());
            int tong = 0;
            if (c < 0 || c > matran.GetLength(1))
            {
                Console.WriteLine("Nhap chi so hop le");
            }
            for(int i = 0;i < matran.GetLength(0); i++)
            {
                tong += matran[i, c];
            }
            Console.WriteLine($"Tong cot {c} la {tong}");
        }
    }
}
