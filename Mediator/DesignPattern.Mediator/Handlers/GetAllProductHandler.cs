using DesignPattern.Mediator.Data;
using DesignPattern.Mediator.Queries;
using DesignPattern.Mediator.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.Mediator.Handlers
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, List<GetAllProductResult>>
    {
        private readonly Context _context;

        public GetAllProductHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetAllProductResult>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.Select(x => new GetAllProductResult
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductCategory = x.ProductCategory,
                ProductPrice = x.ProductPrice,
                ProductStock = x.ProductStock,
                ProductStockType = x.ProductStockType,
            }).AsNoTracking().ToListAsync();

            #region AÇIKLAMA AsNoTracking();

            //Entity Framework Core'da, Change Tracker mekanizması vardır.
            //Yani entity'ler ve property'ler üzerinde uygulanan değişikliklerin veri tabanına,
            //doğru bir şekilde uygulanıp uygulanmadığının takibini / kontrolünü yapan mekanizmadır.
            //Veritabanında yapılan sorgulama durumunda sonucun change tracker mekanizması tarafından izlenmesini kırıyor.
            //Bu da belleğimizi gereksiz yüklerden kurtarıyor, performans sağlıyor.
            //Veri tabanında ekleme güncelleme silme işlemi yapmayacaksak yani veri üzerinde yalnızca okuma işlemi yapacaksak AsNoTracking metodu kullanımı önerilir.

            #endregion
        }
    }
}
