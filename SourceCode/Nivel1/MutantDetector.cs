﻿using System;
using System.Linq;

namespace Nivel1
{
    /// <summary>
    /// Detector of Mutants. This class has methods to detect mutants through its dna.
    /// </summary>
    public class MutantDetector
    {
        /// <summary>
        /// Number of correlative letters that dna should have to be a mutant.
        /// </summary>
        private const int k_QuantitySecuence = 4;

        /// <summary>
        /// Set of letters that the dna should have.
        /// </summary>
        private readonly char[] k_ValidLetters = { 'A', 'a', 'T', 't', 'C', 'c', 'G', 'g' };

        /// <summary>
        /// Detects a mutant through its dna chain.
        /// </summary>
        /// <exception cref="DnaInvalidException">Thrown when dna chain is not valid.</exception>
        /// <param name="dna">Dna chain.</param>
        /// <returns>True if it's mutant; false if not.</returns>
        public bool IsMutant(string[] dna)
        {
            //first at all, I have to validate the dna
            if (IsDnaValid(dna))
            {
                //I create my variables once here before the iterations
                string keyword, horizontal, vertical, diagonalRight, diagonalLeft;
                
                //then, I iterate the multi array in order to evaluate each position
                for (int row = 0; row < dna.Length; row++)
                {
                    for (int col = 0; col < dna[row].Length; col++)
                    {
                        //I set the expected word to match
                        keyword = new String(dna[row][col], k_QuantitySecuence).ToUpper();

                        //I get the possible values in the different axis
                        horizontal = GetHorizontal(dna[row], col);
                        vertical = GetVertical(dna, row, col);
                        diagonalRight = GetDiagonalRight(dna, row, col, string.Empty);
                        diagonalLeft = GetDiagonalLeft(dna, row, col, string.Empty);
                        
                        //finally, if one "axis" match with the keyword, then it's a mutant dna
                        if (horizontal.Contains(keyword) || vertical.Contains(keyword) || diagonalRight.Contains(keyword) || diagonalLeft.Contains(keyword))
                        {
                            return true;
                        }
                    }
                }
            }
            
            return false;
        }

        /// <summary>
        /// This method validates the dna chain. To be valid it cannot be null or empty, it cannot has nulls or empty strings
        /// as members, it must be a NxN table and it must only contains valid letters.
        /// </summary>
        /// <exception cref="DnaInvalidException">Thrown when dna chain is not valid.</exception>
        /// <param name="dna">Dna chain.</param>
        /// <returns>True if dna is valid; ArgumentException if it's invalid.</returns>
        public bool IsDnaValid(string[] dna)
        {
            //dna cannot be null
            if (dna == null)
            {
                throw new DnaInvalidException(ErrorMessages.k_DnaCannotBeNull);
            }

            //dna cannot be empty
            if (dna.Length == 0)
            {
                throw new DnaInvalidException(ErrorMessages.k_DnaCannotBeEmpty);
            }
            
            foreach (string line in dna)
            {
                //dna cannot has nulls or empty strings as members
                if (String.IsNullOrWhiteSpace(line))
                {
                    throw new DnaInvalidException(ErrorMessages.k_DnaCannotHasNullsOrEmpty);
                }

                //dna must be a NxN table
                if (line.Length != dna.Length)
                {
                    throw new DnaInvalidException(ErrorMessages.k_DnaMustBeNxN);
                }

                //dna must only contains letters A,T,C,G
                if (!line.All(x => k_ValidLetters.Contains(x)))
                {
                    throw new DnaInvalidException(ErrorMessages.k_DnaMustContainsValidLetters);
                }
            }
            
            return true;
        }

        #region Auxiliar Methods

        /// <summary>
        /// Assembles a substring of "line" from the "col" position up to the end.
        /// </summary>
        /// <param name="line">Original string</param>
        /// <param name="col">From position</param>
        /// <returns>Horizontal axis string</returns>
        private string GetHorizontal(string line, int col)
        {
            return line.Substring(col).ToUpper();
        }

        /// <summary>
        /// Assembles a string with the vertical values contains in dna,
        /// from the "row" and "col" position up to the end of dna chain.
        /// </summary>
        /// <param name="dna">Dna chain</param>
        /// <param name="row">From position X</param>
        /// <param name="col">From position Y</param>
        /// <returns>Vertical axis string</returns>
        private string GetVertical(string[] dna, int row, int col)
        {
            string result = string.Empty;
            for (int i = row; i < dna.Length; i++)
            {
                result += dna[i][col];
            }
            return result.ToUpper();
        }

        /// <summary>
        /// Assembles a string with the diagonal "down-right" values contains in dna,
        /// from the "row" and "col" position up to the end of dna chain.
        /// </summary>
        /// <param name="dna">Dna chain</param>
        /// <param name="row">From position X</param>
        /// <param name="col">From position Y</param>
        /// <param name="buffer">Values kept through recursive calls</param>
        /// <returns>Diagonal "down-right" axis string</returns>
        private string GetDiagonalRight(string[] dna, int row, int col, string buffer)
        {
            if (row >= dna.Length || col >= dna.Length)
            {
                return buffer.ToUpper();
            }
            else
            {
                buffer += dna[row][col];
                return GetDiagonalRight(dna, row + 1, col + 1, buffer);
            }
        }

        /// <summary>
        /// Assembles a string with the diagonal "down-left" values contains in dna,
        /// from the "row" and "col" position up to the end of dna chain.
        /// </summary>
        /// <param name="dna">Dna chain</param>
        /// <param name="row">From position X</param>
        /// <param name="col">From position Y</param>
        /// <param name="buffer">Values kept through recursive calls</param>
        /// <returns>Diagonal "down-left" axis string</returns>
        private string GetDiagonalLeft(string[] dna, int row, int col, string buffer)
        {
            if (row >= dna.Length || col < 0)
            {
                return buffer.ToUpper();
            }
            else
            {
                buffer += dna[row][col];
                return GetDiagonalLeft(dna, row + 1, col - 1, buffer);
            }
        }

        #endregion Auxiliar Methods
    }
}
