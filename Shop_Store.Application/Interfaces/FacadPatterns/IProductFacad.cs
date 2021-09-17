using Shop_Store.Application.Services.Products.Commands.AddNewCategory;
using Shop_Store.Application.Services.Products.Commands.AddNewProduct;
using Shop_Store.Application.Services.Products.Queries.GetAllCategories;
using Shop_Store.Application.Services.Products.Queries.GetCategories;
using Shop_Store.Application.Services.Products.Queries.GetProductDetailForAdmin;
using Shop_Store.Application.Services.Products.Queries.GetProductDetailForSite;
using Shop_Store.Application.Services.Products.Queries.GetProductForAdmin;
using Shop_Store.Application.Services.Products.Queries.GetProductForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Store.Application.Interfaces.FacadPatterns
{
    public interface IProductFacad
    {
        AddNewCategoryService AddNewCategoryService { get; }
        IGetCategoriesService GetCategoriesService { get; }
        AddNewProductService AddNewProductService { get; }
        IGetAllCategoriesService GetAllCategoriesService { get; }
        /// <summary>
        /// دریافت لیست محصولات
        /// </summary>
        IGetProductForAdminService GetProductForAdminService { get; }
        IGetProductDetailForAdminService GetProductDetailForAdminService { get; }
        IGetProductForSiteService GetProductForSiteService { get; }
        IGetProductDetailForSiteService GetProductDetailForSiteService { get; }
    }
}
