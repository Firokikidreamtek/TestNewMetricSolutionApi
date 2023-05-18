using AutoMapper;
using NewMetricSolution.DB.DBContexts;

namespace NewMetricSolution.BL
{
    public class HomeServices : IHomeServices
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _databaseContext;

        public HomeServices(IMapper mapper, ApplicationDbContext databaseContext)
        {
            _mapper = mapper;
            _databaseContext = databaseContext;
        }

        public void IncreaseNumberOfEmployees(int id, string department)
        {
            throw new NotImplementedException();
        }

        //private string GetDepartment(string department) 
        //{
        //    var listOfDepartment = typeof()
        //}

        //public Cart TryGetByUserId(string userId)
        //{
        //    return _mapper.Map<Cart>(_cartBase.TryGetByUserId(userId));
        //}

        //public Cart TryGetByUserName(string userName)
        //{
        //    return _mapper.Map<Cart>(_cartBase.TryGetByUserName(userName));
        //}

        //public bool CheckForAvailability(Product product, string userId)
        //{
        //    var existingCart = _cartBase.AllCarts().FirstOrDefault(x => x.UserId == userId);
        //    if (existingCart != null)
        //    {
        //        var CartItemsWithNecessaryProduct = existingCart.Items.Where(x => x.Product.Id == product.Id);
        //        var amountOfProductInCart = CartItemsWithNecessaryProduct.Select(x => x.Amount).Sum();
        //        if (product.AmountInDb > 0)
        //        {
        //            return amountOfProductInCart < product.AmountInDb ? true : false;
        //        }
        //        else return false;

        //    }
        //    else
        //    {
        //        return product.AmountInDb == 0 ? false : true;
        //    }
        //}

    }
}
