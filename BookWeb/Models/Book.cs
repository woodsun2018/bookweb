using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Book
    {
        public int ID { get; set; }

        //书名
        public string Name { get; set; }

        //出版日期
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        //作者
        public string Author { get; set; }

        //价格
        public float Price { get; set; }
    }

}
