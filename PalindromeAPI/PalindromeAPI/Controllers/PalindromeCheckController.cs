using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PalindromeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalindromeCheckController : ControllerBase
    {
        MyDbContext _dbContext;

        public PalindromeCheckController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            List<string> result = _dbContext.tbl.Select(x=>x.Desc).ToList();
            return result;
        }        

        [HttpPost]
        public bool Post([FromBody] string value)
        {
            if (!ModelState.IsValid)
            {
                return false;
            }

            if (string.IsNullOrEmpty(value))    //empty string
                return false;
            if (value.Length <= 1)              //input only contains 1 character
                return false;

            bool result = false;

            string ValueWithoutSpecialChar = "";
            string ValueRotated = "";

            List<char> lsSkipCharacter = new List<char>() {' ','.','?','\\',',','/','?','<','>',';',':','\'','"','[',']','{','}','`','~','!','@','#','$','%','^','&','*','(',')','-','=','_','+' };

            for(int i = 0; i < value.Length;i++)
            {
                if (lsSkipCharacter.Contains(value[i]))
                    continue;
                ValueWithoutSpecialChar = ValueWithoutSpecialChar + value[i];
            }

            for(int i = value.Length - 1; i >= 0; i--)
            {
                if (lsSkipCharacter.Contains(value[i]))
                    continue;
                //ValueRotated = ValueRotated + value.Substring(i, 1);
                ValueRotated = ValueRotated + value[i];
            }

            if (ValueWithoutSpecialChar.ToLower() == ValueRotated.ToLower())
            {
                result = true;

                //TODO: persist into DB here
                _dbContext.tbl.Add(new Tbl() { Desc = value });
                _dbContext.SaveChanges();
            }
            

            return result;

        }
    }
}