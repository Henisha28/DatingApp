﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
            private readonly AppDataContext _context;
            public ValuesController(AppDataContext context) 
            {
                 _context = context;
            }
            
            //Get api/values
            [HttpGet]
            public async Task<IActionResult>GetValues()
            {
                var values = await _context.Values.ToListAsync();
                return Ok(values);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult>  GetValue(int id)
            {
                var value = await _context.Values.FirstOrDefaultAsync(x=>x.Id == id);
                return Ok(value);
            }

            [HttpPost]
            public void Post([FromBody] string value)
            {

            }
        }
    }
