﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restuarant.Services.ProductAPI.Models.Dtos
{
    public class ResponseDto
    {
        public bool isSuccess { get; set; } = true;

        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "";

        public List<string> ErrorMessages { get; set; }
    }
}
