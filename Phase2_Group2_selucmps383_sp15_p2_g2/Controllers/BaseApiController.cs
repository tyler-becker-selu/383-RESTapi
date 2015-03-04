﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Phase2_Group2_selucmps383_sp15_p2_g2.Enums;
using Phase2_Group2_selucmps383_sp15_p2_g2.Models;

namespace Phase2_Group2_selucmps383_sp15_p2_g2.Controllers
{
    public class BaseApiController : ApiController
    {
        public User storeUser;
        public IGameStoreRepository _repo ;
        public ModelFactory _modelFactory;

        public BaseApiController(IGameStoreRepository repo)
        {
            _repo = repo;
            storeUser = new User();
        }

        protected IGameStoreRepository TheRepository
        {
            get { return _repo; }
        }

        protected ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(Request, TheRepository);
                }
                return _modelFactory;
            }
        }

        protected bool IsStoreAdmin()
        {
            return Enum.GetName(typeof(Role), storeUser.Role)==("StoreAdmin");
        }

        protected bool IsEmployee()
        {
            if (IsStoreAdmin())
            {
                return true;
            }

            return Enum.GetName(typeof (Role), storeUser.Role) == ("StoreEmployee");
        }

        protected bool IsCustomer()
        {
            return Enum.GetName(typeof (Role), storeUser.Role) == ("StoreCustomer");
        }
    }
}