using LMS.Models;
using LMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.LearningManagement.viewmodels
{
    class ItemDialogViewModel
    {
        private Course? course;
        private Module? module;
        private Item? item;
        public string Name
        {
            get { return item?.Name ?? string.Empty; }
            //value keyword, when R-value = getter, when L-value = setter
            set
            {
                if (item == null)
                    item = new Item();
                item.Name = value;
            }
        }
        public string Description
        {
            get { return item?.Description ?? string.Empty; }
            set
            {
                if (item == null)
                    item = new Item();
                item.Description = value;
            }
        }
        public string Path
        {
            get
            { return item?.Path ?? string.Empty; }

        }
        public void AddItem()
        {
            if (course != null && module != null && item != null)
            {
                CourseService.Current.AddOrUpdateItem(course, module, item);
            }
        }
        public ItemDialogViewModel(string code, string moduleName)
        {
            if (code == string.Empty || code == null
                || moduleName == string.Empty || moduleName == null)
            {
                course = new Course();
                module = new Module();
            }
            else
            {
                course = CourseService.Current.Get(code) ?? new Course();
                module = course?.Modules?.Where(m => m.Name == moduleName).FirstOrDefault();
            }
        }
    }
}
