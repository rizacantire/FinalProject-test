using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal prodcutDal)
        {
            _productDal = prodcutDal;
        }

        
        public IResult Add(Product product)
        {
            
            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Add(product);

            return new Result(true,Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //if(DateTime.Now.Hour==23)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }


        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryID == id),Messages.ProductListed);
        }

        public IDataResult<List<ProductDetailDTO>> GetProductDetails()
        {
            if(DateTime.Now.Hour == 10)
             {
                return new ErrorDataResult<List<ProductDetailDTO>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDTO>>(_productDal.GetProductDetails());
        }

        public IDataResult<List<Product>> GetById(int productId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.ProductId == productId), Messages.ProductListed);
        }
    }
}
