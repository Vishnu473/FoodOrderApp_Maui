using System;
using System.Collections.ObjectModel;
using FoodOrderApp.Model;
namespace FoodOrderApp.Services.Interfaces
{
	public interface ICategory
	{
		Task<List<Category>> GetCategoriesAsync();
    }
}

