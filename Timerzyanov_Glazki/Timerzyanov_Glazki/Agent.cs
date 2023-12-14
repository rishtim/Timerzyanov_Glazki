//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Timerzyanov_Glazki
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Media;

    public partial class Agent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Agent()
        {
            this.AgentPriorityHistory = new HashSet<AgentPriorityHistory>();
            this.ProductSale = new HashSet<ProductSale>();
            this.Shop = new HashSet<Shop>();
        }

        public int ID { get; set; }
        public int AgentTypeID { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Logo { get; set; }
        public string Address { get; set; }
        public int Priority { get; set; }
        public string DirectorName { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }

        public virtual AgentType AgentType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AgentPriorityHistory> AgentPriorityHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductSale> ProductSale { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shop> Shop { get; set; }

        public string AgentTypeString
        {
            get
            {
                return AgentType.Title;
            }
        }
        public int AgentProductSaleCount
        {
            get
            {
                int count = 0;
                var context = Timerzyanov_GlazkiEntities.GetContext().ProductSale.Where(p => p.AgentID == ID).ToList();
                foreach (var productSale in context)
                {
                    count += productSale.ProductCount;
                }

                return count;
            }
        }
        public double AgentProductSaleSum
        {
            get
            {
                double SaleSum = 0;
                var context = Timerzyanov_GlazkiEntities.GetContext().ProductSale.Where(p => p.AgentID == ID).ToList();
                var prod = Timerzyanov_GlazkiEntities.GetContext().Product.ToList();
                foreach (var productSale in context)
                {
                    foreach (var productCount in prod)
                    {
                        if (productSale.ProductID == productCount.ID)
                        {
                            SaleSum += Convert.ToDouble(productSale.ProductCount) * Convert.ToDouble(productCount.MinCostForAgent);
                        }
                    }

                }
                return SaleSum;
            }
        }
        public int getDiscount()
        {
            double summa = AgentProductSaleSum;
            if (summa < 10000)
            {
                return 0;
            }
            else if (summa >= 10000 && summa < 50000)
            {
                return 5;
            }
            else if (summa >= 50000 && summa < 150000)
            {
                return 10;
            }
            else if (summa >= 150000 && summa < 500000)
            {
                return 20;
            }
            else
            {
                return 25;
            }
        }
        public string Discount
        {
            get
            {
                return getDiscount().ToString() + '%';
            }
        }

        public SolidColorBrush FonStyle
        {
            get
            {
                if (getDiscount() >= 5)
                {
                    return (SolidColorBrush)new BrushConverter().ConvertFromString("LightGreen");
                }
                else
                {
                    return (SolidColorBrush)new BrushConverter().ConvertFromString("White");
                }
            }
        }
    }
}
