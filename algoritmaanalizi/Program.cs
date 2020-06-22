using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algoritmaanalizi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Uygulamaya hoşgeldiniz!");

            Console.WriteLine("Kaç Tane Rastgele Sayı Üretilsin?");
            int rastgelesayilar = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Sayıların Başlangıç değeri kaç olsun?");
            int baslangicdeger = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Sayıların Bitiş değeri kaç olsun?");
            int bitisdeger = Convert.ToInt32(Console.ReadLine());
            int[] dizimiz = new int[rastgelesayilar];
            Random rnd = new Random();
            for (int i = 0; i < rastgelesayilar; i++)
            {
                dizimiz[i] = rnd.Next(baslangicdeger, bitisdeger);
            }
            int[] tmpdizimiz = new int[rastgelesayilar];//hafızaya alınır ilk oluşturulan dizi
            tmpdizimiz = dizimiz;
            List<int> listemiz = new List<int>();
        tekrar:
            dizimiz = tmpdizimiz;//hafızadaki dizi tekrar kullanıma  sunulur
            listemiz = tmpdizimiz.ToList();

            Console.WriteLine("\t1)Quick Sort\n\t2)Bubble Sort\n\t3)Selection Sort\n\t4)Insortion Sort\n\t5)Binary Search\n\t6)Merge Sort");
            int secim = Convert.ToInt32(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    DateTime date3 = DateTime.Now;
                    QuickSort(dizimiz, 0, dizimiz.Length-1);
                    DateTime date4 = DateTime.Now;
                    TimeSpan fark1= date4 - date3;
                    //diziYazdir(dizimiz);
                    Console.WriteLine("Quick Sort Algoritmasının Çalışma Süresi : {0} saniyedir.", Convert.ToString(fark1.TotalSeconds));
                    Console.WriteLine("Maksimum Değer = {0}", dizimiz[dizimiz.Length-1]);
                    goto tekrar;
                case 2:
                    DateTime date1 = DateTime.Now;
                    kabarcikSirala(dizimiz);
                    DateTime date2 = DateTime.Now;
                    //diziYazdir(dizimiz);
                    TimeSpan fark = date2 - date1;
                    Console.WriteLine("Bubble Sort Algoritmasının Çalışma Süresi : {0} saniyedir.", Convert.ToString(fark.TotalSeconds));
                    Console.WriteLine("Maksimum Değer = {0}", dizimiz[dizimiz.Length - 1]);

                    goto tekrar;
                case 3:
                    DateTime date5 = DateTime.Now;
                    secmelisiralama(dizimiz);
                    DateTime date6 = DateTime.Now;
                    TimeSpan fark2 = date6 - date5;
                    Console.WriteLine("Selection Sort Algoritmasının Çalışma Süresi : {0} saniyedir.", Convert.ToString(fark2.TotalSeconds));
                    Console.WriteLine("Maksimum Değer = {0}", dizimiz[dizimiz.Length - 1]);

                    //diziYazdir(dizimiz);
                    goto tekrar;
                case 4:
                    DateTime date7 = DateTime.Now;
                    InsertionSort(dizimiz);
                    DateTime date8 = DateTime.Now;
                    //diziYazdir(dizimiz);
                    TimeSpan fark3 = date8 - date7;
                    Console.WriteLine("Insortion Sort Algoritmasının Çalışma Süresi : {0} saniyedir.", Convert.ToString(fark3.TotalSeconds));
                    Console.WriteLine("Maksimum Değer = {0}", dizimiz[dizimiz.Length - 1]);

                    goto tekrar;
                case 5:
                    DateTime date9 = DateTime.Now;
                    listemiz.Sort();
                    DateTime date10 = DateTime.Now;
                    TimeSpan fark4 = date10 - date9;
                    Console.WriteLine("Binary Search Algoritmasının Çalışma Süresi : {0} saniyedir.", Convert.ToString(fark4.TotalSeconds));
                    Console.WriteLine("Maksimum Değer = {0}", dizimiz[dizimiz.Length - 1]);

                    goto tekrar;
                case 6:
                    DateTime date11 = DateTime.Now;
                    MergeSort(dizimiz, 0, dizimiz.Length - 1);
                    DateTime date12 = DateTime.Now;
                    //diziYazdir(dizimiz);
                    TimeSpan fark5 = date12 - date11;
                    Console.WriteLine("Merge Algoritmasının Çalışma Süresi : {0} saniyedir.", Convert.ToString(fark5.TotalSeconds));
                    Console.WriteLine("Maksimum Değer = {0}", dizimiz[dizimiz.Length - 1]);

                    goto tekrar;

                default:
                    Console.WriteLine("Geçersiz Seçim Lütfen Doğru Sıralama Algoritmasını Seçin");
                    goto tekrar;
            }


        }
        /***********************QUICKSORT*****************************/
        public static void QuickSort(int[] dizi, int baslangic, int bitis)
        {
            int l;
            if (baslangic < bitis)
            {
                l = Parca(dizi, baslangic, bitis);
                QuickSort(dizi, baslangic, l - 1);
                QuickSort(dizi, l + 1, bitis);
            }
        }
        public static int Parca(int[] A, int baslangic, int bitis)
        {
            int gecici;
            int x = A[bitis];
            int f = baslangic - 1;
            for (int j = baslangic; j <= bitis - 1; j++)
            {
                if (A[j] <= x)
                {
                    f++;
                    gecici = A[f];
                    A[f] = A[j];
                    A[j] = gecici;
                }
            }
            gecici = A[f + 1];
            A[f + 1] = A[bitis];
            A[bitis] = gecici;
            return f + 1;
        }
        /***********************BİTİS QUICKSORT***********************/


        /***********************SELECTIONSORT*************************/
        public static int[] secmelisiralama(int[] dizi)
        {
            int n = dizi.Length;
            int yedek;
            int minindex;
            for (int i = 0; i < n - 1; i++)
            {
                minindex = i;
                for (int j = i; j < n; j++)
                {
                    if (dizi[j] < dizi[minindex]) minindex = j;
                }
                yedek = dizi[i];
                dizi[i] = dizi[minindex];
                dizi[minindex] = yedek;

            }
            return dizi;
        }
        /***********************BİTİS SELECTIONSORT*******************/


        /***********************BUBBLESORT****************************/
        public static void kabarcikSirala(int[] siralanacakDizi)
        {

            int i = 1, j, deger;
            int diziAdet = siralanacakDizi.Length;
            while (i < diziAdet)
            {
                j = diziAdet - 1;
                while (j >= 1)
                {
                    if (siralanacakDizi[j - 1] > siralanacakDizi[j])
                    {
                        deger = siralanacakDizi[j];
                        siralanacakDizi[j] = siralanacakDizi[j - 1];
                        siralanacakDizi[j - 1] = deger;
                    }
                    j--;
                }
                i++;
            }
        }
        /***********************BİTİS BUBBLESORT**********************/


        /***********************INSERTIONSORT*************************/
        static int[] InsertionSort(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (inputArray[j - 1] > inputArray[j])
                    {
                        int temp = inputArray[j - 1];
                        inputArray[j - 1] = inputArray[j];
                        inputArray[j] = temp;
                    }
                }
            }
            return inputArray;
        }
        /***********************BİTİS INSERTIONSORT*******************/

        /***********************MERGESORT*****************************/
        public static void Merge(int[] input, int left, int middle, int right)
        {
            int[] leftArray = new int[middle - left + 1];
            int[] rightArray = new int[right - middle];

            Array.Copy(input, left, leftArray, 0, middle - left + 1);
            Array.Copy(input, middle + 1, rightArray, 0, right - middle);

            int i = 0;
            int j = 0;
            for (int k = left; k < right + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    input[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else if (leftArray[i] <= rightArray[j])
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else
                {
                    input[k] = rightArray[j];
                    j++;
                }
            }
        }

        public static void MergeSort(int[] input, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSort(input, left, middle);
                MergeSort(input, middle + 1, right);

                Merge(input, left, middle, right);
            }
        }
        /***********************BİTİS MERGESORT***********************/

        /***********************DİZİ YAZDIR***************************/
        public static void diziYazdir(int[] dizi)
        {
            foreach (int a in dizi)
            {
                Console.WriteLine(a);
            }
        }
        /***********************BİTİS DİZİ YAZDİR*********************/
    }
}
