using PizzaShoppe.Domain.Concrete;
using System.Collections.Generic;

namespace PizzaShoppe.WebUI.Models
{
    public class MenuItemListViewModel
    {
        private List<MenuItem> _MenuList;
        
        public MenuItemListViewModel(List<MenuItem> list)
        {
            _MenuList = list;
        }
        public MenuItem CurrentItem { get; set; }
        public List<MenuItem> MenuList { get { return _MenuList; } }
    }
}