using System;

namespace Nivel1
{
    /// <summary>
    /// Class that holds the entire program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// First method invoked in the program.
        /// </summary>
        /// <param name="args">arguments passed in runtime</param>
        static void Main(string[] args)
        {
            MutantDetector detector = new MutantDetector();
            Console.WriteLine("DNA:");
            foreach (string line in args)
            {
                Console.WriteLine(line);
            }

            try
            {
                bool isMutant = detector.IsMutant(args);

                Console.WriteLine("\nIs Mutant? " + isMutant);
            }
            catch (DnaInvalidException ex)
            {
                Console.WriteLine("Invalid arguments: " + ex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("A not expected exception has been thrown, please contact with David Leone for support");
            }
            finally
            {
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
