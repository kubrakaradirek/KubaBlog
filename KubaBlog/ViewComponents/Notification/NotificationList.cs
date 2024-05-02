﻿using KubaBlog.BusinessLayer.Concrete;
using KubaBlog.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace KubaBlog.ViewComponents.Notification
{
    public class NotificationList:ViewComponent
    {
        WriterManager vm = new WriterManager(new EfWriterRepository());
        public IViewComponentResult Invoke()
        {
            var values = vm.GetWriterById(2);
            return View(values);
        }
    }
}
