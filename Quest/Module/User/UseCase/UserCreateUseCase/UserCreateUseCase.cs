using Quest.Entities;
using Quest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Quest.UseCase
{


	public class UserCreateUseCase
	{
		private readonly IUserRepository _repository;
		public UserCreateUseCase(IUserRepository repo)
		{
			_repository = repo;
		}

		public async Task<IEnumerable<User>> GetUser()
		{
			return await _repository.GetUser();
		}

		public async Task<dynamic> NewUser(User user)
		{
			

			if (await this.IsExistEmail(user.Email))
				throw new Exception("Usuario ja cadastrado");

			if (!this.IsValidEmail(user.Email))
				throw new Exception("Email invalido");


			if (string.IsNullOrWhiteSpace(user.Password) && user.Password.Length >= 6)
				throw new Exception("Senha invalido");


			return await _repository.NewUser(user);
		}

		private bool IsValidEmail(string email)
		{
			if (string.IsNullOrWhiteSpace(email))
				return false;

			try
			{
				return Regex.IsMatch(email,
					@"^[^@\s]+@[^@\s]+\.[^@\s]+$",
					RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
			}
			catch (RegexMatchTimeoutException)
			{
				return false;
			}

		}

		private async Task<bool> IsExistEmail(string email)
		{
			var user = await _repository.GetByEmail(email);
			if (user == null) return false;
			else return true;
		}


	}
}
