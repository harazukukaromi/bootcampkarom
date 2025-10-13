using FluentValidation;
using PenjualanBarangApi.DTOs;
using PenjualanBarangApi.Interfaces;

namespace PenjualanBarangApi.Validators
{
    //validator untuk ProductCreateDTO supaya tidak boleh ada nama produk duplikat dan harga bersera stok tidak boleh negatif
    public class ProductCreateValidator : AbstractValidator<ProductCreateDTO>
    {
        private readonly IProductRepository _repository;

        public ProductCreateValidator(IProductRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nama produk tidak boleh kosong.")
                .MustAsync(async (name, cancellation) =>
                {
                    var existing = await _repository.GetAllAsync();
                    return !existing.Any(p => p.Name.ToLower() == name.ToLower());
                })
                .WithMessage("Produk dengan nama ini sudah ada.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Harga harus lebih besar dari 0.");

            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("Stok tidak boleh negatif.");
        }
    }
}
