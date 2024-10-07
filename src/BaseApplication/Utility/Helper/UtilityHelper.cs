using Domain.DataTransferObjects.Collection.Enum;
using Domain.DataTransferObjects.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Utility.Security;

namespace Utility.Helper
{
    public class UtilityHelper
    {
        public static string PasswordEncrypt(string password, string salt = SecurityConstants.Salt)
        {
            using (SHA512 hash = SHA512.Create())
            {
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(salt + password);
                byte[] hashBytes = hash.ComputeHash(plainTextBytes);

                return Convert.ToBase64String(hashBytes);
            }
        }

       

        public static List<CollectionResultMessage> AddSuccessToCollectionResultMessage(string result)
        {
            return new List<CollectionResultMessage>() { new CollectionResultMessage(ResultMessageType.Success, result) };
        }

        public static List<CollectionResultMessage> AddWarningToCollectionResultMessage(string result)
        {
            return new List<CollectionResultMessage>() { new CollectionResultMessage(ResultMessageType.Warning, result) };
        }

        public static List<CollectionResultMessage> AddDangerToCollectionResultMessage(string result)
        {
            return new List<CollectionResultMessage>() { new CollectionResultMessage(ResultMessageType.Danger, result) };
        }

        public static List<CollectionResultMessage> AddInfoToCollectionResultMessage(string result)
        {
            return new List<CollectionResultMessage>() { new CollectionResultMessage(ResultMessageType.Info, result) };
        }


        public static List<CollectionResultMessage> AddErrorToCollectionResultMessage(string result)
        {
            return new List<CollectionResultMessage>() { new CollectionResultMessage(ResultMessageType.Danger, result) };
        }

        public static List<CollectionResultMessage> AddErrorToCollectionResultMessage(List<string> result)
        {
            var lst = new List<CollectionResultMessage>();

            foreach (var error in result)
            {
                lst.Add(new CollectionResultMessage(ResultMessageType.Danger, error));
            }

            return lst;
        }

    }
}
