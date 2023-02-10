﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;
using Microsoft.EntityFrameworkCore;
namespace MMAGlobalDAL.Database.DB_Helper

{
    public class DB_call_character
    {
        private EF_MMADatabaseContext _DataContext;
        public DB_call_character(EF_MMADatabaseContext DataContext)
        {
            _DataContext = DataContext;
        }
        public bool Savecallcharacter(call_character call_character)

        {
            bool isSuccess = false;
            try
            {
                _DataContext.call_character.Add(call_character);
                if (call_character.callcharacter_id > 0)
                {
                    _DataContext.Entry(call_character).State = EntityState.Modified;
                }
                _DataContext.SaveChanges();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSuccess;
        }
        public List<call_character> Getdata()
        {
            return _DataContext.call_character.ToList();
        }
    }
}


