using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Quest.Entities;
using System.Globalization;
using System.Security.Cryptography;

namespace Quest.Services
{
	public class HashValue
	{

		public static string GenerateHash(string value)
		{
			UnicodeEncoding encoding = new UnicodeEncoding();
			byte[] hashBytes;
			using (HashAlgorithm hash = SHA1.Create())
				hashBytes = hash.ComputeHash(encoding.GetBytes(value));

			StringBuilder hashValue = new StringBuilder(hashBytes.Length * 2);
			foreach (byte b in hashBytes)
			{
				hashValue.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", b);
			}
			return hashValue.ToString();
		}
	}
}
