/* Giorgi Tediashvili
 * CodeAuthority Assesment
 * Task #3
 * The Requirement:
 *  Using your favorite .NET programming language, decrypt a TripleDES Encrypted, and Base64 encoded String.
 *  This portion of the task is absolutely optional and is only supplied to observe the candidate’s way of 
 *  solving and approaching a complex problem.
 *  Encryption Algorithm:        TripleDES
 *  TripleDES KeySize:             128
 *  TripleDES Key:             “0123456789ABCDEF”
 *  TripleDES Initilzation Vector (IV):    “ABCDEFGH”
 *  Encrypted and Base64 Encoded Input:
 *      ABvAsOKcGXqc5uQ4O5Z53isJaH31Pa8+PeddljE4mSU=
 *  Decrypted Result:
 *  The result you should provide is the clear text version of the above TripleDES encrypted then Base64 
 *  encoded String.
 */

using System;
using System.Security.Cryptography;
using System.Text;


namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string base64Encoded = "ABvAsOKcGXqc5uQ4O5Z53isJaH31Pa8+PeddljE4mSU="; 
            string key = "0123456789ABCDEF";
            string initVect = "ABCDEFGH";

                //create a new 3DES crypt
            TripleDESCryptoServiceProvider encrypt = new TripleDESCryptoServiceProvider();
            encrypt.KeySize = 128;                  //assign the key
            encrypt.BlockSize = 64;                 //assign the size
            encrypt.Padding = PaddingMode.None;     //assign the padding, no padding necessary since 
                                                    //encrypted string is fixed 64bit
            encrypt.Mode = CipherMode.;          //assign the mode
            encrypt.Key = Encoding.ASCII.GetBytes(key);          //convert the key to bytes
            encrypt.IV  = Encoding.ASCII.GetBytes(initVect);     //convert the IV to bytes

            byte[] encryptedData = Convert.FromBase64String(base64Encoded); //convert string to byte[]
            ICryptoTransform transform = encrypt.CreateDecryptor();         //create the decryptor
            byte[] plainText = transform.TransformFinalBlock(encryptedData, 0, encryptedData.Length); //decrypt
            string message = Encoding.ASCII.GetString(plainText);           //convert back to string
            Console.Write(message + "\n");
        }

        
    }
}
