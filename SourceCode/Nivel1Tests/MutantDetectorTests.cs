using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nivel1;

namespace Nivel1Tests
{
    /// <summary>
    /// Unit Tests for MutantDetector class.
    /// </summary>
    [TestClass]
    public class MutantDetectorTests
    {
        #region IsMutant(string[])
        
        /// <summary>
        /// DNA no-mutant 5x5.
        /// </summary>
        [TestMethod]
        public void MutantDetector_IsMutant_DnaNoMutant5x5_Succeeds()
        {
            //Arrange
            MutantDetector detector = new MutantDetector();
            string[] dna = {
                "AACCT",
                "ACTGC",
                "CCTGG",
                "GATCC",
                "TTCGA",
            };

            //Action
            bool result = detector.IsMutant(dna);

            //Asserts
            Assert.IsFalse(result);
        }

        /// <summary>
        /// DNA mutant 5x5 (horizontal case)
        /// </summary>
        [TestMethod]
        public void MutantDetector_IsMutant_DnaMutant5x5Horizontal_Succeeds()
        {
            //Arrange
            MutantDetector detector = new MutantDetector();
            string[] dna = {
                "AAAAT",
                "ACTGC",
                "CCTGG",
                "GATCC",
                "TTCGA",
            };

            //Action
            bool result = detector.IsMutant(dna);

            //Asserts
            Assert.IsTrue(result);
        }

        /// <summary>
        /// DNA mutant 5x5 (vertical case)
        /// </summary>
        [TestMethod]
        public void MutantDetector_IsMutant_DnaMutant5x5Vertical_Succeeds()
        {
            //Arrange
            MutantDetector detector = new MutantDetector();
            string[] dna = {
                "AACCT",
                "ACTGC",
                "CCTGG",
                "GATCC",
                "TATGA",
            };

            //Action
            bool result = detector.IsMutant(dna);

            //Asserts
            Assert.IsTrue(result);
        }

        /// <summary>
        /// DNA mutant 5x5 (diagonal down-right case)
        /// </summary>
        [TestMethod]
        public void MutantDetector_IsMutant_DnaMutant5x5DiagonalRight_Succeeds()
        {
            //Arrange
            MutantDetector detector = new MutantDetector();
            string[] dna = {
                "AACCT",
                "TCTGC",
                "CTAGG",
                "GATCC",
                "TTCTA",
            };

            //Action
            bool result = detector.IsMutant(dna);

            //Asserts
            Assert.IsTrue(result);
        }

        /// <summary>
        /// DNA mutant 5x5 (diagonal down-left case)
        /// </summary>
        [TestMethod]
        public void MutantDetector_IsMutant_DnaMutant5x5DiagonalLeft_Succeeds()
        {
            //Arrange
            MutantDetector detector = new MutantDetector();
            string[] dna = {
                "AACCT",
                "ACTGT",
                "CCATG",
                "GATCC",
                "TTCGA",
            };

            //Action
            bool result = detector.IsMutant(dna);

            //Asserts
            Assert.IsTrue(result);
        }

        /// <summary>
        /// DNA mutant 5x5 (horizontal case and with lower letters)
        /// </summary>
        [TestMethod]
        public void MutantDetector_IsMutant_DnaMutant5x5LowerLetters_Succeeds()
        {
            //Arrange
            MutantDetector detector = new MutantDetector();
            string[] dna = {
                "AACCT",
                "ACTGC",
                "ccccG",
                "GATCC",
                "TTCGA",
            };

            //Action
            bool result = detector.IsMutant(dna);

            //Asserts
            Assert.IsTrue(result);
        }

        #endregion IsMutant(string[])

        #region IsDnaValid(string[])

        /// <summary>
        /// DNA in null.
        /// </summary>
        [TestMethod]
        public void MutantDetector_IsDnaValid_DnaInNull_Fails()
        {
            //Arrange
            MutantDetector detector = new MutantDetector();
            string[] dna = null;

            //Action & Asserts
            DnaInvalidException ex = Assert.ThrowsException<DnaInvalidException>(() => detector.IsDnaValid(dna));
            Assert.AreEqual(ErrorMessages.k_DnaCannotBeNull, ex.Message);
        }

        /// <summary>
        /// DNA as empty array.
        /// </summary>
        [TestMethod]
        public void MutantDetector_IsDnaValid_DnaEmpty_Fails()
        {
            //Arrange
            MutantDetector detector = new MutantDetector();
            string[] dna = { };

            //Action & Asserts
            DnaInvalidException ex = Assert.ThrowsException<DnaInvalidException>(() => detector.IsDnaValid(dna));
            Assert.AreEqual(ErrorMessages.k_DnaCannotBeEmpty, ex.Message);
        }

        /// <summary>
        /// DNA with a null value in the middle of the array.
        /// </summary>
        [TestMethod]
        public void MutantDetector_IsDnaValid_DnaNullInMiddle_Fails()
        {
            //Arrange
            MutantDetector detector = new MutantDetector();
            string[] dna = { "AGA", null, "CCT" };

            //Action & Asserts
            DnaInvalidException ex = Assert.ThrowsException<DnaInvalidException>(() => detector.IsDnaValid(dna));
            Assert.AreEqual(ErrorMessages.k_DnaCannotHasNullsOrEmpty, ex.Message);
        }

        /// <summary>
        /// DNA with a string empty value in the middle of the array.
        /// </summary>
        [TestMethod]
        public void MutantDetector_IsDnaValid_DnaEmptyInMiddle_Fails()
        {
            //Arrange
            MutantDetector detector = new MutantDetector();
            string[] dna = { "AGA", "   ", "CCT" };

            //Action & Asserts
            DnaInvalidException ex = Assert.ThrowsException<DnaInvalidException>(() => detector.IsDnaValid(dna));
            Assert.AreEqual(ErrorMessages.k_DnaCannotHasNullsOrEmpty, ex.Message);
        }

        /// <summary>
        /// DNA with values as NxM table.
        /// </summary>
        [TestMethod]
        public void MutantDetector_IsDnaValid_DnaNxM_Fails()
        {
            //Arrange
            MutantDetector detector = new MutantDetector();
            string[] dna = { "AGA", "AT", "CCT" };

            //Action & Asserts
            DnaInvalidException ex = Assert.ThrowsException<DnaInvalidException>(() => detector.IsDnaValid(dna));
            Assert.AreEqual(ErrorMessages.k_DnaMustBeNxN, ex.Message);
        }

        /// <summary>
        /// DNA with an invalid letter ("W") at the beginning of the first line.
        /// </summary>
        [TestMethod]
        public void MutantDetector_IsDnaValid_OneInvalidLetterAtTheBeginning_Fails()
        {
            //Arrange
            MutantDetector detector = new MutantDetector();
            string[] dna = { "WAG", "ATC", "CCT" }; //==> W is invalid

            //Action & Asserts
            DnaInvalidException ex = Assert.ThrowsException<DnaInvalidException>(() => detector.IsDnaValid(dna));
            Assert.AreEqual(ErrorMessages.k_DnaMustContainsValidLetters, ex.Message);
        }

        /// <summary>
        /// DNA with an invalid letter ("W") in the middle of the second line.
        /// </summary>
        [TestMethod]
        public void MutantDetector_IsDnaValid_OneInvalidLetterInTheMiddle_Fails()
        {
            //Arrange
            MutantDetector detector = new MutantDetector();
            string[] dna = { "AGT", "AWC", "CCT" }; //==> W is invalid

            //Action & Asserts
            DnaInvalidException ex = Assert.ThrowsException<DnaInvalidException>(() => detector.IsDnaValid(dna));
            Assert.AreEqual(ErrorMessages.k_DnaMustContainsValidLetters, ex.Message);
        }

        /// <summary>
        /// DNA with an invalid letter ("W") at the end of the last line.
        /// </summary>
        [TestMethod]
        public void MutantDetector_IsDnaValid_OneInvalidLetterAtTheEnd_Fails()
        {
            //Arrange
            MutantDetector detector = new MutantDetector();
            string[] dna = { "AGT", "ATC", "CCW" }; //==> W is invalid

            //Action & Asserts
            DnaInvalidException ex = Assert.ThrowsException<DnaInvalidException>(() => detector.IsDnaValid(dna));
            Assert.AreEqual(ErrorMessages.k_DnaMustContainsValidLetters, ex.Message);
        }

        /// <summary>
        /// DNA with a white space in the middle of the second line.
        /// </summary>
        [TestMethod]
        public void MutantDetector_IsDnaValid_OneInvalidWhiteSpaceInTheMiddle_Fails()
        {
            //Arrange
            MutantDetector detector = new MutantDetector();
            string[] dna = { "AGT", "A C", "CCW" }; //==> " " is invalid

            //Action & Asserts
            DnaInvalidException ex = Assert.ThrowsException<DnaInvalidException>(() => detector.IsDnaValid(dna));
            Assert.AreEqual(ErrorMessages.k_DnaMustContainsValidLetters, ex.Message);
        }

        /// <summary>
        /// Valid DNA 2x2.
        /// </summary>
        [TestMethod]
        public void MutantDetector_IsDnaValid_ValidDna2x2_Succeeds()
        {
            //Arrange
            MutantDetector detector = new MutantDetector();
            string[] dna = { "AA", "AA" };

            //Action
            bool result = detector.IsDnaValid(dna);

            //Asserts
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Valid DNA 3x3.
        /// </summary>
        [TestMethod]
        public void MutantDetector_IsDnaValid_ValidDna3x3_Succeeds()
        {
            //Arrange
            MutantDetector detector = new MutantDetector();
            string[] dna = { "AGT", "ATC", "CCA" };

            //Action
            bool result = detector.IsDnaValid(dna);

            //Asserts
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Valid DNA 4x4.
        /// </summary>
        [TestMethod]
        public void MutantDetector_IsDnaValid_ValidDna4x4_Succeeds()
        {
            //Arrange
            MutantDetector detector = new MutantDetector();
            string[] dna = { "AGTA", "ATCA", "ACCA", "TGAC" };

            //Action
            bool result = detector.IsDnaValid(dna);

            //Asserts
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Valid DNA 5x5.
        /// </summary>
        [TestMethod]
        public void MutantDetector_IsDnaValid_ValidDna5x5_Succeeds()
        {
            //Arrange
            MutantDetector detector = new MutantDetector();
            string[] dna = {
                "AGATT",
                "TATGC",
                "CCAGT",
                "AACGT",
                "CCGGT"
            };

            //Action
            bool result = detector.IsDnaValid(dna);

            //Asserts
            Assert.IsTrue(result);
        }

        #endregion IsDnaValid(string[])
    }
}
