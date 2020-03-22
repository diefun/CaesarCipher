using System;

namespace CaesarCipher
{
  class Program
  {
    static void Main(string[] args)
    {
      char[] alphabet = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
      char[] specialChars = new char[] {'!', '?', '*', '@', ' '};
      
      Console.Write("Type the message to encrypt: ");
      string userMessage = Console.ReadLine();
      
      string encryptMsg = Encrypt(userMessage, alphabet, specialChars);
      Console.WriteLine(encryptMsg);
      string decryptMsg = Decrypt(encryptMsg, alphabet, specialChars);
      Console.WriteLine(decryptMsg);
      
    }
    
    static string Encrypt(string userMessage, char[] alphabet, char[] specialChars)
    {
      char[] secretMessage = userMessage.ToLower().ToCharArray();
      char[] encryptedMessage = new char[secretMessage.Length];
      
      for (int i = 0; i < secretMessage.Length; i++)
      {
        char newChar = secretMessage[i];
        
        if (Array.IndexOf(specialChars, newChar) > -1)
        {
          encryptedMessage[i] = newChar;          
        }
        else
        {
          int indexChar = Array.IndexOf(alphabet, newChar);
          indexChar = (indexChar + 3) % 26;
          newChar = alphabet[indexChar];
          encryptedMessage[i] = newChar;
        } 
      }
      string messageString = String.Join("", encryptedMessage);
      return messageString;
    }
    
    static string Decrypt(string userEncryptedMessage, char[] alphabet, char[] specialChars)
    {
      char[] secretMessage = userEncryptedMessage.ToLower().ToCharArray();
      char[] decryptedMessage = new char[secretMessage.Length];
      
      for (int i = 0; i < secretMessage.Length; i++)
      {
        char newChar = secretMessage[i];
        
        if (Array.IndexOf(specialChars, newChar) > -1)
        {
          decryptedMessage[i] = newChar;          
        }
        else
        {
          int indexChar = Array.IndexOf(alphabet, newChar);
          indexChar = indexChar - 3;
          if (indexChar < 0)
          {
            indexChar = indexChar + 26;
          }
          else
          {
            indexChar = indexChar % 26;
          }
          newChar = alphabet[indexChar];
          decryptedMessage[i] = newChar;
        } 
      }
      string messageString = String.Join("", decryptedMessage);
      return messageString;
    }
  }
}
