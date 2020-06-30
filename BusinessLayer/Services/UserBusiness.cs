﻿using BusinessLayer.Interface;
using CommanLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserBusiness : IUserBL
    {
        private IUserRL _UserRepository;

        public UserBusiness(IUserRL UserRepository)
        {
            _UserRepository = UserRepository;
        }

        /// <summary>
        ///  API for Registration
        /// </summary>
        /// <param name="info"> store the Complete Employee information</param>
        /// <returns></returns>
        public async Task<bool> UserRegister(UserDetails info)
        {
            try
            {
                var Result = await _UserRepository.UserRegister(info);
                //if result is not equal null then return true
                if (!Result.Equals(null))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> UserLogin(UserDetails info)
        {
            try
            {
                var Result = await _UserRepository.UserLogin(info);
                //if result is not equal null then return true
                if (!Result.Equals(null))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}