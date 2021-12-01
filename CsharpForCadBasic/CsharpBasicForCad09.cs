using System;
using System.IO;

namespace CsharpBasicForCad09
{
    class Program
    {
        static void Main(string[] args)
        {
            //DivideByZeroExceptionExercise();
            //IndexOutOfBounceExceptionExercise();
            string contents = FileNotFoundExceptionExercise(@"C:\test.txt");
            Console.WriteLine(contents);
            Console.ReadKey();
        }

        private static string FileNotFoundExceptionExercise(string filename)
        {
            FileStream stream = null;
            StreamReader file = null;
            string contents = "";
            try
            {
                stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                file = new StreamReader(stream);
                contents = file.ReadToEnd();
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine("File not found " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error 발생함 " + ex.Message);
            }
            finally
            {
                //Memory 관리를 위해 stream 제거 
                if(stream!= null)
                {
                    stream.Dispose();
                }
                if(file != null)
                {
                    file.Dispose();
                }
            }

            return contents;
        }

        private static void IndexOutOfBounceExceptionExercise()
        {
            try
            {
                int[] numbers = new int[3];
                numbers[0] = 2;
                numbers[1] = 4;
                numbers[2] = 5;
                numbers[3] = 7;
                foreach (int i in numbers)
                {
                    Console.Write("num " + i);
                }

            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Array 배열 에러 : "+ ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error 발생함 "+ ex.Message);
            }
            finally
            {
                Console.WriteLine("프로그램을 종료합니다.");
            }

        }

        private static void DivideByZeroExceptionExercise()
        {
            try
            {
                int i = 0;
                int result = 12 / i;
                Console.WriteLine("result " + result.ToString());
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine( "You are dividing by zero"+ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error " + ex.Message);
            }

        }
    }
}
