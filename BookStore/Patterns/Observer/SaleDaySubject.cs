using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Patterns.Observer_Pattern
{
    public class SaleDaySubject
    {
        protected static DateTime saleDay = new DateTime(0);

        private List<IBookObserver> listBook = new List<IBookObserver>();

        public SaleDaySubject() { }

        // Phương thức set ngày giảm giá cho class
        public void SetDateSale(int year, int month, int day)
        {
            saleDay = new DateTime(year, month, day);
        }

        // Phương thức thêm đối tượng IBookOBserver vào danh sách listBook
        public void AddBook(IBookObserver bookObserver)
        {
            listBook.Add(bookObserver);
        }

        // Phương thức xóa đối tượng IBookOBserver khỏi danh sách listBook
        public void RemoveBook(IBookObserver bookObserver)
        {
            listBook.Remove(bookObserver);
        }

        // Phương thức cập nhật giá khi truyền vào danh sách sản phẩm vào và thực hiện thay đổi giá
        public void MakeSale(List<Product> products)
        {           
            if (saleDay.Date == DateTime.Now.Date)
            {
                foreach (IBookObserver bookObserver in listBook)
                {
                    bookObserver.Update(products);
                }
            }        
        }

        // Phương thức cập nhật giá khi truyền vào sản phẩm vào và thực hiện thay đổi giá (Cho trang chi tiết sản phẩm)
        public void MakeSaleForPro(Product product)
        {
            if (saleDay.Date == DateTime.Now.Date)
            {
                foreach (IBookObserver bookObserver in listBook)
                {
                    bookObserver.UpdateForPro(product);
                }
            }
        }
    }
}