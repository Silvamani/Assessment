﻿using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IAuthRL
    {
        public Task<BasicResponse> SignUp(SignUpRequest request);
        public Task<SignInResponse> SignIn(SignInRequest request);
    }
}
